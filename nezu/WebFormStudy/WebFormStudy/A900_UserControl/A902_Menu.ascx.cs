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
        A950_CommonPropertyBL cpb;

        protected void Page_Load(object sender, EventArgs e)
        {
            lblHederTitle.Text = "メニュー";

            // メニュー制御
            // LinkMenuLeft:トップ画面・編集画面で表示
            // LinkMenuRight:トップ画面以外で表示
            A951_CommonBL cb = new A951_CommonBL();
            String rPath = Request.Path;
            string mode = Request.QueryString["Mode"];
            cpb = cb.GetCommmonInfo(rPath, "menu", mode);
            LinkMenuLeft.Text = cpb.MenuNameLeft;
            LinkMenuLeft.Visible = cpb.MenuLeftHide;
            LinkMenuLeft.Enabled = cpb.MenuLeftEnab;
            LinkMenuLeft.ForeColor = cpb.MenuLeftForeColor;
            LinkMenuRight.Text = cpb.MenuNameRight;
            LinkMenuRight.Visible = cpb.MenuRightHide;
            LinkMenuRight.Enabled = cpb.MenuRightEnab;
            LinkMenuRight.ForeColor = cpb.MenuRightForeColor;
        }

        // トップ画面以外
        protected void LinkMenuRight_Click(object sender, EventArgs e)
        {
            // 編集画面か編集画面以外(トップ画面除く)で遷移先制御
            switch (cpb.DisplayId)
            {
                case "A014":    // 編集画面
                    // 参照リンククリック時
                    cpb.Mode = "s";

                    // 同一ウィンドウで遷移する。(モードあり)
                    Response.Redirect(cpb.Url + cpb.Mode);
                    break;
                default:
                    // 同一ウィンドウで遷移する。(モードなし)
                    Response.Redirect(cpb.Url);
                    break;
            }
        }

        // トップ画面・リンクボタン2個画面
        protected void LinkMenuLeft_Click(object sender, EventArgs e)
        {
            // 別ウィンドウ表示か同一ウィンドウ表示で遷移先制御
            switch (cpb.DisplayId)
            {
                case "A001":    // トップ画面
                    // 別ウィンドウで遷移する。
                    ClientScriptManager cs = Page.ClientScript;
                    cs.RegisterStartupScript(this.Page.GetType(), "openWinMenu", "window.open('../A010_Shouhin/A011_ShouhinSerch.aspx', " +
                        "'ShouhinSerch','screenX=0,screenY=0,left=0,top=0," + 
                        "width=screen.width,height=screen.height,scrollbars=0,toolbar=0,menubar=0,staus=0,resizable=0');", true);
                    break;
                case "A014":    // 編集画面
                    // 編集リンククリック時
                    cpb.Mode = "h";

                    // 同一ウィンドウで遷移する。(モードあり)
                    Response.Redirect(cpb.Url + cpb.Mode);
                    break;
            }
        }
    }
}