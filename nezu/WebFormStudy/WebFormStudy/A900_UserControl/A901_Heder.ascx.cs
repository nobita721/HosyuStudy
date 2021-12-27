using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
//using WebFormStudy.A950_BL;
using WebFormBL;

namespace WebFormStudy.A900_UserControl
{
    public partial class A901_Heder : System.Web.UI.UserControl
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            // リクエストパス
            // (例：Top画面だったら、/A001_Top/A001_Top/A001_Top.aspxを取得)
            String rPath = Request.Path;

            // ヘッタータイトル
            A903_UserControlUI cb = new A903_UserControlUI();
            A950_CommonPropertyBL cpb = cb.GetCommmonInfo(rPath, "header");
            lblHederTitle.Text = cpb.DisplayName;
        }
    }
}