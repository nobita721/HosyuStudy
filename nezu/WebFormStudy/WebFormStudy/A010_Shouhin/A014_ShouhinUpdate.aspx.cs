using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Common;
using WebFormBL;

namespace WebFormStudy.A010_Shouhin
{

    public partial class A014_ShouhinUpdate : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            try 
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
                    // 数量ドロップダウンリスト初期設定
                    ListItem list = new ListItem("");
                    ddlSuuRyou.Items.Add(list);
                    for (int i = 1; i <= 20; i++)
                    {
                        list = new ListItem(i.ToString());
                        ddlSuuRyou.Items.Add(list);
                    }

                    // 検索画面の入力値を保持したいため、hiddenFieldにも設定
                    HiddenShouhinId.Value = Request.QueryString["kshouhinid"];
                    HiddenShouhinName.Value = Request.QueryString["kshouhinname"];
                    HiddenShouhinDetail.Value = Request.QueryString["kshouhindetail"];

                    // 対象データ取得、各画面項目に設定
                    A952_ShouhinBL sb = new A952_ShouhinBL();
                    List<V_Shouhin> shouhinlist = sb.GetShouhinSelect(cb);
                    lblShouhinIdDisp.Text = shouhinlist[0].ShouhinId.ToString();
                    HiddenHistNo.Value = shouhinlist[0].HistNo.ToString();
                    txtShouhinName.Text = shouhinlist[0].ShouhinName.ToString();
                    txtShouhinDetail.Text = shouhinlist[0].ShouhinDetail.ToString();
                    txtZaikoSuu.Text = shouhinlist[0].ZaikoSuu.ToString();

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
                        ddlSuuRyou.Enabled = false;
                        btnUpdate.Enabled = false;
                        break;
                    case "h":   // 編集モード
                        // 入力項目及び更新ボタン活性
                        txtShouhinName.Enabled = true;
                        txtShouhinDetail.Enabled = true;
                        rdobtnNyuuka.Enabled = true;
                        rdobtnSyukka.Enabled = true;
                        ddlSuuRyou.Enabled = true;
                        btnUpdate.Enabled = true;
                        break;
                    default:
                        // nullの場合、参照モードにしておく
                        txtShouhinName.Enabled = false;
                        txtShouhinDetail.Enabled = false;
                        rdobtnNyuuka.Enabled = false;
                        rdobtnSyukka.Enabled = false;
                        ddlSuuRyou.Enabled = false;
                        btnUpdate.Enabled = false;
                        break;
                }
            }
            catch (Exception ex)
            {
                // エラー情報を設定する
                errorinfoBase.diplayname = title.Text;
                errorinfoBase.program = Request.Path;

                // UIで発生した場合エラー発生箇所を設定する。
                if (errorinfoBase.errlocation == null)
                {
                    errorinfoBase.errlocation = "【UI】Page_Loadイベント例外情報";
                }
                errorinfoBase.setErrorInfo(ex);

                // エラーページに遷移
                Response.Redirect("/errorinfo.aspx");

            }
        }

        protected void btnUpdate_Click(object sender, EventArgs e)
        {
            try 
            {
                // 入力エラーがない場合
                if (Page.IsValid)
                {
                    // 更新に必要な項目をプロパティに設定
                    A950_CommonPropertyBL cb = new A950_CommonPropertyBL();
                    cb.ShouhinId = lblShouhinIdDisp.Text;
                    cb.HistNo = int.Parse(HiddenHistNo.Value);
                    cb.ShouhinName = txtShouhinName.Text;
                    cb.ShouhinDetail = txtShouhinDetail.Text;
                    cb.ZaikoSuu = int.Parse(txtZaikoSuu.Text);

                    // 更新処理実行
                    // 最新レコードに削除フラグを立てて、新規レコード追加
                    A952_ShouhinBL sb = new A952_ShouhinBL();
                    sb.ShouhinDelete(cb);
                    cb.HistNo = cb.HistNo + 1;
                    sb.ShouhinInsert(cb);

                    // 商品一覧画面に戻る
                    Response.Redirect("A012_ShouhinList.aspx?shouhinid=" + HiddenShouhinId.Value +
                                                        "&shouhinname=" + HiddenShouhinName.Value +
                                                        "&shouhindetail=" + HiddenShouhinDetail.Value, false);
                }
            }
            catch (Exception ex)
            {
                // エラー情報を設定する
                errorinfoBase.diplayname = title.Text;
                errorinfoBase.program = Request.Path;

                // UIで発生した場合エラー発生箇所を設定する。
                if (errorinfoBase.errlocation == null)
                {
                    errorinfoBase.errlocation = "【UI】btnUpdate_Clickイベント例外情報";
                }
                errorinfoBase.setErrorInfo(ex);

                // エラーページに遷移
                Response.Redirect("/errorinfo.aspx");
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
            ddlSuuRyou.SelectedIndex = 0;
        }

        // 出荷選択
        protected void rdobtnSyukka_CheckedChanged(object sender, EventArgs e)
        {
            SetZaikoSuuCalc();
            ddlSuuRyou.SelectedIndex = 0;
        }

        // 数量変更
        protected void ddlSuuRyou_SelectedIndexChanged(object sender, EventArgs e)
        {
            SetZaikoSuuCalc();
        }

        // 在庫数を計算した結果を表示
        private void SetZaikoSuuCalc() 
        {
            int suuyou;
            
            bool result = int.TryParse(ddlSuuRyou.SelectedValue, out suuyou);
            if (result) 
            {
                suuyou = int.Parse(ddlSuuRyou.SelectedValue);
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
    }
}