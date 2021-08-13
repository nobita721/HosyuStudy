@ModelType IEnumerable(Of HoujinWeb.Prefecture)
@Code
    ViewData("Title") = "法人タブ付き一覧"
    ViewData("ScreenName") = "法人タブ付き一覧"
    ViewData("ControlName") = "HoujinTab"
    ViewData("ActionName") = "HoujinTabList"
    Layout = "~/Views/Shared/_LayoutHoujin.vbhtml"
End Code

@Section Menu
    @RenderPage("~/Views/Houjin/HoujinMenu.vbhtml")
End Section


登録画面作成したら実装
