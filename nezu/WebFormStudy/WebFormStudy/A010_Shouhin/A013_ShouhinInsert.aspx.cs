using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using WebFormBL;
using System.Data;

namespace WebFormStudy.A010_Shouhin
{
    public partial class A013_ShouhinInsert : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            // 入力エラーメッセージを設定
            // (エラーメッセージを一元管理するため(customValidatorは除く)、ページ表示時に設定)
            foreach (BaseValidator valid in Page.Validators)
            {
                switch (valid.GetType().Name)
                {
                    case "RequiredFieldValidator":
                        // 必須チェック
                        valid.ErrorMessage = String.Format(
                            "{0}は必須です。", valid.ErrorMessage);
                        break;
                    case "RegularExpressionValidator":
                        if (valid.UniqueID == "regShouhinId") 
                        {
                            // 桁チェック(商品IDのみ)
                            valid.ErrorMessage = String.Format(
                                "{0}は半角数字5桁で入力してください。", valid.ErrorMessage);
                        }
                        else 
                        {
                            // 数値チェック
                            valid.ErrorMessage = String.Format(
                                "{0}は半角数字で入力してください。", valid.ErrorMessage);
                        }
                        break;
                    case "RangeValidator":
                        // 範囲チェック
                        valid.ErrorMessage = String.Format(
                        "{0}は{1}～{2}の範囲で入力してください。",
                        valid.ErrorMessage,
                        ((RangeValidator)valid).MinimumValue,
                        ((RangeValidator)valid).MaximumValue);
                        break;
                }
            }
        }

        protected void btnInsert_Click(object sender, EventArgs e)
        {

            // 入力エラーがない場合
            if (Page.IsValid)
            {
                // 入力値をプロパティに設定
                A950_CommonPropertyBL cb = new A950_CommonPropertyBL();
                cb.ShouhinId = txtShouhinId.Text;
                cb.ShouhinName = txtShouhinName.Text;
                cb.ShouhinDetail = txtShouhinDetail.Text;
                cb.NyuukaSuu = int.Parse(txtNyuukaSuu.Text);

                // 登録処理実行
                A952_ShouhinBL sb = new A952_ShouhinBL();
                sb.ShouhinInsert(cb);

                // 商品検索画面に戻る
                Response.Redirect("A011_ShouhinSerch.aspx");
            }
        }

        protected void btnReturn_Click(object sender, EventArgs e)
        {
            // 商品検索画面に戻る
            Response.Redirect("A011_ShouhinSerch.aspx");
        }

        // 商品ID重複チェック
        protected void customValid_ServerValidate(object sender, ServerValidateEventArgs e)
        {
            // 入力値をプロパティに設定
            // (検索のメソッドを使い回すので商品名・商品詳細は、空文字設定)
            A950_CommonPropertyBL cb = new A950_CommonPropertyBL();
            cb.ShouhinId = txtShouhinId.Text;
            cb.ShouhinName = String.Empty;
            cb.ShouhinDetail = String.Empty;

            // 重複チェックして結果を設定
            A952_ShouhinBL sb = new A952_ShouhinBL();
            DataSet ds = new DataSet();
            DataTable dt;
            ds = sb.GetShouhinSelect(cb);
            dt = ds.Tables[0];

            if (dt.Rows.Count > 0)
            {
                e.IsValid = false;
                // CustomValidatorのエラーメッセージをValidationSummaryが走るタイミングで
                // 加えられないのでarertで表示
                ClientScriptManager cs = Page.ClientScript;
                string js = "";
                js += "<script language='JavaScript'>";
                js += "alert('商品ID：";
                js += cb.ShouhinId;
                js += "はすでに存在しています。')";
                js += "</script>";
                cs.RegisterStartupScript(this.Page.GetType(), "startup", js);
            }
            else 
            {
                e.IsValid = true;
            }
        }
    }
}