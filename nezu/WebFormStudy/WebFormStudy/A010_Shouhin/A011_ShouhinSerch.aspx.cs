using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace WebFormStudy.A010_Shouhin
{
    public partial class A011_ShouhinSerch : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void btnSerch_Click(object sender, EventArgs e)
        {
            // 同一ウィンドウでページ遷移
            String shouhinid = HttpUtility.UrlEncode(txtShouhinId.Text);
            String shouhinname = HttpUtility.UrlEncode(txtShouhinName.Text);
            String shouhindetail = HttpUtility.UrlEncode(txtShouhinDetail.Text);
            Response.Redirect("A012_ShouhinList.aspx?shouhinid=" + shouhinid + 
                                                "&shouhinname=" + shouhinname + 
                                                "&shouhindetail=" + shouhindetail);

        }
    }
}