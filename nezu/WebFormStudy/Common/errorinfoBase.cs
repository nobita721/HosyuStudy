using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Common
{
    public static class errorinfoBase
    {
        public static string diplayname;
        public static string occurredDt;
        public static string program;
        public static string errlocation;
        public static string innerStackTrace;
        public static StringBuilder message = new StringBuilder();

        // エラー画面に表示及びログ出力する各情報を編集する。
        public static void setErrorInfo(Exception ex)
        {
            // 発生日時を設定
            DateTime dt = DateTime.Now;
            occurredDt = dt.ToString("yyyy/MM/dd HH:mm:ss.fff");

            // エラー内容を見やすいように整形。これをログにも出力する
            message.AppendLine("～～～～～～～ " + errlocation + " ～～～～～～～");
            message.AppendLine("[例外発生日時]:" + occurredDt);
            message.AppendLine("[例外種類]:" + ex.GetType().FullName);
            message.AppendLine("[例外メッセージ]:" + ex.Message);
            message.AppendLine("[例外オブジェクト]:" + ex.Source);
            message.AppendLine("[例外メソッド]:" + ex.TargetSite);
            message.AppendLine("[例外スタックトレース]:");
            // BLで例外が発生した場合、innerStackTraceに設定したスタックトレースも出力
            // (UIに例外を投げたタイミングでBLの例外発生行が消えてしまうため)
            if (innerStackTrace != null) 
            {
                message.AppendLine("   ::::::: InnerException Start :::::::");
                message.AppendLine(innerStackTrace);
                message.AppendLine("   ::::::: InnerException End   :::::::");
            }
            message.AppendLine(ex.StackTrace);
        }

        // エラー情報初期化
        public static void errorInfoClear()
        {
            diplayname = null;
            occurredDt = null;
            program = null;
            errlocation = null;
            innerStackTrace = null;
            message = new StringBuilder();
        }
    }
}