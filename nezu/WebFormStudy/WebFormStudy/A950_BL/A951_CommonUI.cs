using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.IO;

namespace WebFormStudy.A950_BL
{
    public class A951_CommonUI
    {
        public String GetHeaderTitle(String rPath)
        {
            // 画面ID取得
            String fileName = Path.GetFileName(rPath);
            String displayid = fileName.Substring(0, 4);
            String displayName = String.Empty;

            // ヘッダータイトル名を設定
            switch (displayid)
            {
                case "A001":    // トップ画面
                    displayName = "トップ";
                    break;
                case "A011":    // 商品検索画面
                    displayName = "商品検索";
                    break;
                case "A012":    // 商品一覧画面
                    displayName = "商品一覧";
                    break;
                default:
                    // なにもしない。空文字を返す
                    break;
            }

            return displayName;
        }
    }
}