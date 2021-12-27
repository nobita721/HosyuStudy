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
    public partial class A012_ShouhinList : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

            // パラメータの値をプロパティに設定
            A950_CommonPropertyBL cb = new A950_CommonPropertyBL();
            cb.ShouhinId = Request.QueryString["shouhinid"];
            cb.ShouhinName = Request.QueryString["shouhinname"];
            cb.ShouhinDetail = Request.QueryString["shouhindetail"];

            // 検索画面の入力値を保持したいため、hiddenFieldにも設定
            HiddenShouhinId.Value = cb.ShouhinId;
            HiddenShouhinName.Value = cb.ShouhinName;
            HiddenShouhinDetail.Value = cb.ShouhinDetail;

            // データ取得、グリッドビューに設定
            A952_ShouhinBL sb = new A952_ShouhinBL();
            ShouhinGridView.DataSource = sb.GetShouhinSelect(cb);
            ShouhinGridView.DataBind();

        }

        protected void btnReturn_Click(object sender, EventArgs e)
        {
            // 商品検索画面に戻る
            Response.Redirect("A011_ShouhinSerch.aspx");
        }

        protected void ShouhinGridView_SelectedIndexChanged(object sender, EventArgs e)
        {

            // GridViewの選択列の商品ID取得・編集画面に遷移
            String shouhinid = ShouhinGridView.SelectedDataKey.Values["ShouhinId"].ToString();
            Response.Redirect("A014_ShouhinUpdate.aspx?shouhinid=" + shouhinid + 
                                                    "&kshouhinid=" + HiddenShouhinId.Value + 
                                                    "&kshouhinname=" + HiddenShouhinName.Value + 
                                                    "&kshouhindetail=" + HiddenShouhinDetail.Value);

        }

        protected void ShouhinGridView_RowDeleting(Object sender, GridViewDeleteEventArgs e)
        {

            // GridViewの選択列の商品ID取得・削除画面に遷移
            String shouhinid = ShouhinGridView.Rows[e.RowIndex].Cells[0].Text;
            Response.Redirect("A015_ShouhinDelete.aspx?shouhinid=" + shouhinid +
                                                    "&kshouhinid=" + HiddenShouhinId.Value +
                                                    "&kshouhinname=" + HiddenShouhinName.Value +
                                                    "&kshouhindetail=" + HiddenShouhinDetail.Value);

        }
    }
}