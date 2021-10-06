using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using WebFormStudy.A950_BL;

namespace WebFormStudy.A900_UserControl
{
    public partial class A903_Menu : System.Web.UI.UserControl
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            lblHederTitle.Text = "メニュー";

            // メニュー制御
            String rPath = Request.Path;
            A951_CommonUI cu = new A951_CommonUI();
            LinkMenu.Text = cu.GetMenuContens(rPath);



            //課題：未着手。リンクボタンの表示制御と遷移先URLの制御
            //LinkMenu.Enabled = false;
            //LinkMenu.PostBackUrl = "";
        }
    }
}