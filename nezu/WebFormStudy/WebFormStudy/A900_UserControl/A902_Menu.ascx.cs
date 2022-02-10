using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Drawing;
using WebFormBL;

namespace WebFormStudy.A900_UserControl
{
    public partial class A903_Menu : System.Web.UI.UserControl
    {
        // 設定後のプロパティクラス
        A950_CommonPropertyBL cb;

        protected void Page_Load(object sender, EventArgs e)
        {
            lblHederTitle.Text = "メニュー";

            // メニュー制御
            // LinkMenuLeft:トップ画面・詳細画面で表示
            // LinkMenuRight:トップ画面以外で表示
            A903_UserControlUI uc = new A903_UserControlUI();
            String rPath = Request.Path;
            string shouhinId = Request.QueryString["shouhinid"];
            string mode = Request.QueryString["mode"];
            cb = uc.GetCommmonInfo(rPath, "menu", shouhinId, mode);
            LinkMenuLeft.Text = cb.MenuNameLeft;
            LinkMenuLeft.Visible = cb.MenuLeftHide;
            LinkMenuLeft.Enabled = cb.MenuLeftEnab;
            LinkMenuLeft.ForeColor = cb.MenuLeftForeColor;
            LinkMenuRight.Text = cb.MenuNameRight;
            LinkMenuRight.Visible = cb.MenuRightHide;
            LinkMenuRight.Enabled = cb.MenuRightEnab;
            LinkMenuRight.ForeColor = cb.MenuRightForeColor;

            // 検索画面の入力値を保持したいため、hiddenFieldにも設定
            HiddenShouhinId.Value = Request.QueryString["kshouhinid"];
            HiddenShouhinName.Value = Request.QueryString["kshouhinname"];
            HiddenShouhinDetail.Value = Request.QueryString["kshouhindetail"];
        }

        // トップ画面以外
        protected void LinkMenuRight_Click(object sender, EventArgs e)
        {
            // 詳細画面か詳細画面以外(トップ画面除く)で遷移先制御
            switch (cb.DisplayId)
            {
                case "A014":    // 詳細画面
                    // 参照リンククリック時
                    cb.Mode = "s";

                    // 同一ウィンドウで遷移する。(モード及び値保持用パラメータあり)
                    Response.Redirect(cb.Url + cb.Mode + "&kshouhinid=" + HiddenShouhinId.Value +
                                    "&kshouhinname=" + HiddenShouhinName.Value +
                                    "&kshouhindetail=" + HiddenShouhinDetail.Value);
                    break;
                default:
                    // 同一ウィンドウで遷移する。(モード及び値保持用パラメータなし)
                    Response.Redirect(cb.Url);
                    break;
            }
        }

        // トップ画面・リンクボタン2個画面
        protected void LinkMenuLeft_Click(object sender, EventArgs e)
        {
            // 別ウィンドウ表示か同一ウィンドウ表示で遷移先制御
            switch (cb.DisplayId)
            {
                case "A001":    // トップ画面
                    // 別ウィンドウで遷移する。
                    ClientScriptManager cs = Page.ClientScript;
                    cs.RegisterStartupScript(this.Page.GetType(), "openWinMenu", "window.open('../A010_Shouhin/A011_ShouhinSerch.aspx', " +
                        "'ShouhinSerch','screenX=0,screenY=0,left=0,top=0," + 
                        "width=screen.width,height=screen.height,scrollbars=0,toolbar=0,menubar=0,staus=0,resizable=0');", true);
                    break;
                case "A014":    // 詳細画面
                    // 編集リンククリック時
                    cb.Mode = "h";

                    // 同一ウィンドウで遷移する。(モード及び値保持用パラメータあり)
                    Response.Redirect(cb.Url + cb.Mode + "&kshouhinid=" + HiddenShouhinId.Value +
                                    "&kshouhinname=" + HiddenShouhinName.Value +
                                    "&kshouhindetail=" + HiddenShouhinDetail.Value);
                    break;
            }
        }
    }
}