using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Common;
using System.IO;
using System.Text;

namespace WebFormStudy
{
    public partial class errorinfo : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack) 
            {
                lblDisplay.Text = errorinfoBase.diplayname;
                lblDateTime.Text = errorinfoBase.occurredDt.Substring(0, 19);
                lblProgram.Text = errorinfoBase.program;
                lblErrInfo.Text = errorinfoBase.message.ToString();

                // 例外情報ログ出力
                string occurredDate = errorinfoBase.occurredDt.Replace("/","").Substring(0, 8);
                StreamWriter objSw = new StreamWriter(Server.MapPath("/Log/" + occurredDate + "_err.log"), true, Encoding.GetEncoding("Shift_JIS"));
                objSw.WriteLine(errorinfoBase.message.ToString());
                objSw.Close();

                // errorinfoBaseの各情報を初期化
                errorinfoBase.errorInfoClear();
            }
        }
        
        protected void btnErrInfoSave_Click(object sender, EventArgs e)
        {
            // エラー画面をhtmlで保存する。→苦戦中。一旦後回し。

            //var filename = @"test.aspx.html";
            //Response.Clear();
            //Response.ContentType = "text/html";
            //Response.HeaderEncoding = Encoding.GetEncoding("Shift_JIS");
            //Response.ContentEncoding = Encoding.GetEncoding("Shift_JIS");
            //Response.AddHeader("Content-Disposition", "attachment;filename=" + Server.UrlEncode(filename));
            //Response.End();

            //string filepath = Request.PhysicalPath;
            //fileDownload(filepath, "text/html");
        }

        // エラー画面をhtmlでダウンロードする
        private void fileDownload(string filepath, string type)
        {
            Response.Clear();
            Response.Buffer = true;
            Response.ContentType = type;
            Response.AddHeader("Content-Disposition", String.Format("attachment;filename={0}", "errorinfo.html"));

            // ファイルを書き出し
            Response.WriteFile(filepath);
            Response.Flush();
            Response.End();

        }
    }
}