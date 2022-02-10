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
    public partial class A015_ShouhinDelete : System.Web.UI.Page
    {
        A950_CommonPropertyBL cb = new A950_CommonPropertyBL();

        protected void Page_Load(object sender, EventArgs e)
        {
            // パラメータの値をプロパティに設定
            // (検索のメソッドを使い回すので商品名・商品詳細は、空文字設定)
            cb.ShouhinId = Request.QueryString["shouhinid"];
            cb.ShouhinName = String.Empty;
            cb.ShouhinDetail = String.Empty;

            // 検索画面の入力値を保持したいため、hiddenFieldにも設定
            HiddenShouhinId.Value = Request.QueryString["kshouhinid"];
            HiddenShouhinName.Value = Request.QueryString["kshouhinname"];
            HiddenShouhinDetail.Value = Request.QueryString["kshouhindetail"];

            
            // 対象データ取得、各画面項目に設定
            A952_ShouhinBL sb = new A952_ShouhinBL();
            //DataSet ds = new DataSet();
            //DataTable dt;
            //DataRow dtRow;
            //ds = sb.GetShouhinSelect(cb);
            //dt = ds.Tables[0];
            //dtRow = dt.Rows[0];
            //lblShouhinIdDisp.Text = dtRow["ShouhinId"].ToString();
            //lblShouhinNameDisp.Text = dtRow["ShouhinName"].ToString();
            //lblShouhinDetailDisp.Text = dtRow["ShouhinDetail"].ToString();
            //lblZaikoSuuDisp.Text = dtRow["ZaikoSuu"].ToString();

            // クラスから取得
            List<V_Shouhin> shouhinlist = sb.GetShouhinSelect(cb);
            lblShouhinIdDisp.Text = shouhinlist[0].ShouhinId.ToString();
            HiddenHistNo.Value = shouhinlist[0].HistNo.ToString();
            lblShouhinNameDisp.Text = shouhinlist[0].ShouhinName.ToString();
            lblShouhinDetailDisp.Text = shouhinlist[0].ShouhinDetail.ToString();
            lblZaikoSuuDisp.Text = shouhinlist[0].ZaikoSuu.ToString();

            // 削除時の確認メッセージを表示
            btnDelete.Attributes["onclick"] = "return confirm('削除しますか ?')";

        }

        protected void btnDelete_Click(object sender, EventArgs e)
        {

            // 削除(論理削除)に必要な項目をプロパティに設定
            cb.ShouhinId = lblShouhinIdDisp.Text;
            cb.HistNo = int.Parse(HiddenHistNo.Value);

            // 削除処理実行
            A952_ShouhinBL sb = new A952_ShouhinBL();
            sb.ShouhinDelete(cb);

            //商品一覧画面に戻る
            Response.Redirect("A012_ShouhinList.aspx?shouhinid=" + HiddenShouhinId.Value +
                                                "&shouhinname=" + HiddenShouhinName.Value +
                                                "&shouhindetail=" + HiddenShouhinDetail.Value);

        }

        protected void btnReturn_Click(object sender, EventArgs e)
        {
            // 商品一覧画面に戻る
            Response.Redirect("A012_ShouhinList.aspx?shouhinid=" + HiddenShouhinId.Value +
                                                "&shouhinname=" + HiddenShouhinName.Value +
                                                "&shouhindetail=" + HiddenShouhinDetail.Value);
        }
    }
}