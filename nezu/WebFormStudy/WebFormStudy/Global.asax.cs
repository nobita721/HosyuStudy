using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Optimization;
using System.Web.Routing;
using System.Web.Security;
using System.Web.SessionState;
using System.Text;
using Common;

namespace WebFormStudy
{
    public class Global : HttpApplication
    {
        void Application_Start(object sender, EventArgs e)
        {
            // アプリケーションのスタートアップで実行するコードです
            RouteConfig.RegisterRoutes(RouteTable.Routes);
            BundleConfig.RegisterBundles(BundleTable.Bundles);
        }

        void Application_Error(object sender, EventArgs e)
        {
            // ハンドルされなかった例外情報を取得する
            Exception ex =
                    this.Server.GetLastError() is HttpUnhandledException ?
                    this.Server.GetLastError().InnerException :
                    this.Server.GetLastError();
            //this.Server.ClearError();
            if (ex != null)
            {
                // 画面名やプログラムは出力しない。
                errorinfoBase.errlocation = "アプリケーション例外情報";
                errorinfoBase.setErrorInfo(ex);

                // エラーページに遷移
                Response.Redirect("/errorinfo.aspx");
            }
        }
    }
}