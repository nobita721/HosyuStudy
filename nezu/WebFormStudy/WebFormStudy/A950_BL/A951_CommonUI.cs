using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.IO;

namespace WebFormStudy.A950_BL
{
    public class A951_CommonUI
    {
        // 課題：同じような記述は、共通化するべき

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

        public String GetMenuContens(String rPath)
        {
            // 画面ID取得
            String fileName = Path.GetFileName(rPath);
            String displayid = fileName.Substring(0, 4);
            String MenuName = String.Empty;

            // メニュー名を設定
            switch (displayid)
            {
                case "A001":    // トップ画面から遷移
                    MenuName = "商品情報検索";
                    break;
                case "A011":    // 商品検索画面から遷移
                    MenuName = "商品情報登録";
                    break;
                case "A012":    // 商品一覧画面
                    MenuName = "非表示にする(未着手)";
                    break;
                default:
                    // なにもしない。空文字を返す
                    break;
            }

            return MenuName;
        }
    }
}