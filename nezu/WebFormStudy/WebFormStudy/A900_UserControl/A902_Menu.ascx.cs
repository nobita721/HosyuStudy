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
            String rPath = Request.Path;
            A951_CommonBL cb = new A951_CommonBL();
            cpb = cb.GetCommmonInfo(rPath, "menu");
            LinkMenuLeft.Text = cpb.MenuNameLeft;
            LinkMenuLeft.Visible = cpb.MenuLeftHide;
            LinkMenuLeft.Enabled = cpb.MenuLeftEnab;
            LinkMenuRight.Text = cpb.MenuNameRight;
            LinkMenuRight.Visible = cpb.MenuRightHide;
            LinkMenuRight.Enabled = cpb.MenuRightEnab;

            // 編集画面表示の制御
            if (cpb.DisplayId == "A014") 
            {
                //リンクボタン色制御
                if (LinkMenuLeft.Enabled == false) 
                {
                    LinkMenuLeft.ForeColor = Color.Gray;
                    LinkMenuRight.ForeColor = Color.Blue;
                }
                else 
                {
                    LinkMenuLeft.ForeColor = Color.Blue;
                    LinkMenuRight.ForeColor = Color.Gray;
                }
            }
        }

        // トップ画面以外・リンクボタン1個画面
        protected void LinkMenuRight_Click(object sender, EventArgs e)
        {
            // 同一ウィンドウで遷移する。
            Response.Redirect(cpb.Url);
        }

        // トップ画面・リンクボタン2個画面
        protected void LinkMenuLeft_Click(object sender, EventArgs e)
        {
            // 別ウィンドウ表示か同一ウィンドウ表示で遷移先制御
            switch (cpb.DisplayId)
            {
                case "A001":    // トップ画面
                    // 別ウィンドウで遷移する。
                    // 課題：トップ画面の画像クリックと同様の位置に表示できない。
                    ClientScriptManager cs = Page.ClientScript;
                    cs.RegisterStartupScript(this.Page.GetType(), "openWinMenu", "window.open('../A010_Shouhin/A011_ShouhinSerch.aspx', " +
                        "'ShouhinSerch','screenX=0,screenY=0,left=0,top=0," + 
                        "width=screen.width,height=screen.height,scrollbars=0,toolbar=0,menubar=0,staus=0,resizable=0');", true);
                    break;
                case "A014":    // 編集画面
                    // 同一ウィンドウで遷移する。
                    Response.Redirect(cpb.Url);
                    break;
            }
        }
    }
}