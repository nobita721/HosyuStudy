using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.IO;
using WebFormBL;
using System.Drawing;

namespace WebFormStudy.A900_UserControl
{
    public class A903_UserControlUI
    {
        // 各共通設定
        public A950_CommonPropertyBL GetCommmonInfo(String rPath, String info, String shouhinid = null, String mode = null)
        {
            // 画面ID取得・設定
            String fileName = Path.GetFileName(rPath);
            String displayid = fileName.Substring(0, 4);
            A950_CommonPropertyBL cb = new A950_CommonPropertyBL();
            cb.DisplayId = displayid;

            // ヘッダーかメニューかにより処理を切り分ける
            switch (info)
            {
                case "header":
                    SetHeaderTitle(cb);
                    break;
                case "menu":
                    SetMenuContens(cb, shouhinid, mode);
                    break;
                default:
                    // なにもしない。
                    break;
            }
            return cb;
        }

        // ヘッダー情報設定
        private void SetHeaderTitle(A950_CommonPropertyBL cb)
        {
            // ヘッダータイトル名を設定
            switch (cb.DisplayId)
            {
                case "A001":    // トップ画面
                    cb.DisplayName = "トップ";
                    break;
                case "A011":    // 商品検索画面
                    cb.DisplayName = "商品検索";
                    break;
                case "A012":    // 商品一覧画面
                    cb.DisplayName = "商品一覧";
                    break;
                case "A013":    // 商品登録画面
                    cb.DisplayName = "商品登録";
                    break;
                case "A014":    // 商品詳細画面
                    cb.DisplayName = "商品詳細";
                    break;
                case "A015":    // 商品削除画面
                    cb.DisplayName = "商品削除";
                    break;
                default:
                    // なにもしない。
                    break;
            }
        }

        // メニュー情報設定
        private void SetMenuContens(A950_CommonPropertyBL cb, String shouhinId = null, String mode = null)
        {
            // メニュー名設定、表示非表示設定、遷移先URL設定
            switch (cb.DisplayId)
            {
                case "A001":    // トップ画面から遷移
                    cb.MenuNameLeft = "商品情報検索";
                    cb.MenuNameRight = String.Empty;
                    cb.MenuLeftHide = true;
                    cb.MenuRightHide = false;
                    cb.MenuLeftEnab = true;
                    cb.MenuLeftForeColor = Color.Blue;
                    cb.Url = ".. /A010_Shouhin/A011_ShouhinSerch.aspx";
                    break;
                case "A011":    // 商品検索画面から遷移
                    cb.MenuNameLeft = String.Empty;
                    cb.MenuNameRight = "商品情報登録";
                    cb.MenuLeftHide = false;
                    cb.MenuRightHide = true;
                    cb.MenuRightEnab = true;
                    cb.MenuRightForeColor = Color.Blue;
                    cb.Url = "A013_ShouhinInsert.aspx";
                    break;
                case "A012":    // 商品一覧画面、商品登録画面、商品削除画面
                case "A013":
                case "A015":
                    // メニュー非表示
                    cb.MenuLeftHide = false;
                    cb.MenuRightHide = false;
                    cb.Url = String.Empty;
                    break;
                case "A014":    // 商品詳細画面から遷移
                    cb.MenuNameLeft = "編集";
                    cb.MenuLeftHide = true;
                    cb.MenuNameRight = "／参照";
                    cb.MenuRightHide = true;


                    // 編集／参照リンク活性非活性設定
                    switch (mode)
                    {
                        case "h":   // 編集モード
                            // 編集リンク活性、参照リンク非活性
                            cb.MenuLeftEnab = false;
                            cb.MenuLeftForeColor = Color.Gray;
                            cb.MenuRightEnab = true;
                            cb.MenuRightForeColor = Color.Blue;
                            break;
                        case "s":   // 参照モード及び初期表示
                        default:
                            // 参照モード設定及び編集リンク活性、参照リンク非活性
                            cb.MenuLeftEnab = true;
                            cb.MenuLeftForeColor = Color.Blue;
                            cb.MenuRightEnab = false;
                            cb.MenuRightForeColor = Color.Gray;
                            break;
                    }

                    cb.Url = "A014_ShouhinUpdate.aspx?shouhinId=" + shouhinId + "&mode=";
                    break;
                default:
                    // なにもしない。
                    break;
            }
        }
    }
}