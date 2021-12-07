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
            lblZaikosuuDisp.Text = dtRow["ZaikoSuu"].ToString();

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

        }

        protected void btnReturn_Click(object sender, EventArgs e)
        {
            // 商品一覧画面に戻る
            Response.Redirect("A012_ShouhinList.aspx");
        }

    }
}