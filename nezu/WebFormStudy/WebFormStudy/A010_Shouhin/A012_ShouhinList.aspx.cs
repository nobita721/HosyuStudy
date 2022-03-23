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
    public partial class A012_ShouhinList : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            try
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

                // データ取得、グリッドビューに設定(クラス)
                A952_ShouhinBL sb = new A952_ShouhinBL();
                ShouhinGridView.DataSource = sb.GetShouhinSelect(cb);
                ShouhinGridView.DataBind();
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

        protected void btnReturn_Click(object sender, EventArgs e)
        {
            // 商品検索画面に戻る
            Response.Redirect("A011_ShouhinSerch.aspx");
        }

        protected void ShouhinGridView_SelectedIndexChanged(object sender, EventArgs e)
        {

            // GridViewの選択列の商品ID取得・詳細画面に遷移
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