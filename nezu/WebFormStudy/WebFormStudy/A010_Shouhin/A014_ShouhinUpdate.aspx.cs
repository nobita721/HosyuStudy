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

    public partial class A014_ShouhinUpdate : System.Web.UI.Page
    {

        protected void Page_Load(object sender, EventArgs e)
        {
            // パラメータの値をプロパティに設定
            // (検索のメソッドを使い回すので商品名・商品詳細は、空文字設定)
            A950_CommonPropertyBL cb = new A950_CommonPropertyBL();
            cb.ShouhinId = Request.QueryString["shouhinid"];
            cb.ShouhinName = String.Empty;
            cb.ShouhinDetail = String.Empty;

            // モード取得
            string mode = Request.QueryString["Mode"];

            // 初期表示時
            if (!IsPostBack) 
            {

                // 検索画面の入力値を保持したいため、hiddenFieldにも設定
                HiddenShouhinId.Value = Request.QueryString["kshouhinid"];
                HiddenShouhinName.Value = Request.QueryString["kshouhinname"];
                HiddenShouhinDetail.Value = Request.QueryString["kshouhindetail"];

                // 対象データ取得、各画面項目に設定
                A952_ShouhinBL sb = new A952_ShouhinBL();
                DataSet ds = new DataSet();
                DataTable dt;
                DataRow dtRow;
                ds = sb.GetShouhinSelect(cb);
                dt = ds.Tables[0];
                dtRow = dt.Rows[0];
                lblShouhinIdDisp.Text = dtRow["ShouhinId"].ToString();
                txtShouhinName.Text = dtRow["ShouhinName"].ToString();
                txtShouhinDetail.Text = dtRow["ShouhinDetail"].ToString();
                txtZaikoSuu.Text = dtRow["Zaikosuu"].ToString();
            }


            // 各画面項目の活性非活性
            switch (mode)
            {
                case "s":   // 参照モード
                    // 入力項目及び更新ボタン非活性
                    txtShouhinName.Enabled = false;
                    txtShouhinDetail.Enabled = false;
                    rdobtnNyuuka.Enabled = false;
                    rdobtnSyukka.Enabled = false;
                    txtSuuRyou.Enabled = false;
                    btnUpdate.Enabled = false;
                    break;
                case "h":   // 編集モード
                    // 入力項目及び更新ボタン活性
                    txtShouhinName.Enabled = true;
                    txtShouhinDetail.Enabled = true;
                    rdobtnNyuuka.Enabled = true;
                    rdobtnSyukka.Enabled = true;
                    txtSuuRyou.Enabled = true;
                    btnUpdate.Enabled = true;
                    break;
                default:
                    // nullの場合、参照モードにしておく
                    txtShouhinName.Enabled = false;
                    txtShouhinDetail.Enabled = false;
                    rdobtnNyuuka.Enabled = false;
                    rdobtnSyukka.Enabled = false;
                    txtSuuRyou.Enabled = false;
                    btnUpdate.Enabled = false;
                    break;
            }
        }

        protected void btnUpdate_Click(object sender, EventArgs e)
        {

            // 入力エラーがない場合
            if (Page.IsValid)
            {
                // 更新に必要な項目をプロパティに設定
                A950_CommonPropertyBL cb = new A950_CommonPropertyBL();
                cb.ShouhinId = lblShouhinIdDisp.Text;
                cb.ShouhinName = txtShouhinName.Text;
                cb.ShouhinDetail = txtShouhinDetail.Text;
                cb.ZaikoSuu = int.Parse(txtZaikoSuu.Text);

                // 更新処理実行
                A952_ShouhinBL sb = new A952_ShouhinBL();
                sb.ShouhinUpdate(cb);

                // 商品一覧画面に戻る
                Response.Redirect("A012_ShouhinList.aspx?shouhinid=" + HiddenShouhinId.Value +
                                                    "&shouhinname=" + HiddenShouhinName.Value +
                                                    "&shouhindetail=" + HiddenShouhinDetail.Value);
            }

        }

        protected void btnReturn_Click(object sender, EventArgs e)
        {
            // 商品一覧画面に戻る
            Response.Redirect("A012_ShouhinList.aspx?shouhinid=" + HiddenShouhinId.Value +
                                                "&shouhinname=" + HiddenShouhinName.Value +
                                                "&shouhindetail=" + HiddenShouhinDetail.Value);
        }

        // 入荷選択
        protected void rdobtnNyuuka_CheckedChanged(object sender, EventArgs e)
        {
            SetZaikoSuuCalc();
            txtSuuRyou.Text = String.Empty;
        }

        // 出荷選択
        protected void rdobtnSyukka_CheckedChanged(object sender, EventArgs e)
        {
            SetZaikoSuuCalc();
            txtSuuRyou.Text = String.Empty;
        }

        // 数量変更・フォーカスアウト
        protected void txtSuuRyou_TextChanged(object sender, EventArgs e)
        {
            SetZaikoSuuCalc();
        }

        // 在庫数を計算した結果を表示
        private void SetZaikoSuuCalc() 
        {
            int suuyou;
            bool result = int.TryParse(txtSuuRyou.Text, out suuyou);
            if (result) 
            {
                suuyou = int.Parse(txtSuuRyou.Text);
            }
            else 
            {
                suuyou = 0;
            }
            int Zaikosuu = int.Parse(txtZaikoSuu.Text);

            if (rdobtnNyuuka.Checked == true)
            {
                // 入荷
                txtZaikoSuu.Text = (Zaikosuu + suuyou).ToString();
            }
            else
            {
                // 出荷
                txtZaikoSuu.Text = (Zaikosuu - suuyou).ToString();
            }
        }

        // 在庫数範囲チェック
        protected void customValid_ServerValidate(object sender, ServerValidateEventArgs e)
        {

            if (int.Parse(txtZaikoSuu.Text) < 0 || int.Parse(txtZaikoSuu.Text) > 20)
            {
                e.IsValid = false;
                ClientScriptManager cs = Page.ClientScript;
                string js = "";
                js += "<script language='JavaScript'>";
                js += "alert('在庫数が0～20の範囲では、ありません。数量を再入力してください。')";
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