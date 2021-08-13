
@Code
    ViewData("ScreenName") = "法人WEBポータル"
    Layout = "~/Views/Shared/_LayoutHoujin.vbhtml"
End Code

@Section Menu
    @RenderPage("~/Views/Houjin/HoujinMenu.vbhtml")
    <script type="text/javascript">
        function openWin() {
            window.open(
                "HoujinSerchDetails",
                "_blank",
                "menubar=0,width=2000,height=1200,top=100,left=100"
            );
        }
    </script>
End Section

<div>
    @*javascriptだけだと呼び出し元も遷移先の画面で変わってしまうのでhrefタグでも指定する。 無駄な実装っぽいがこの方法しかおもいつかないのでこれで妥協。。。*@
    <a href="@Url.Action("HoujinSerchDetails", "Houjin")" target="_blank" onclick="openWin()">
        <img src="/images/image_doraemon2.png" alt="画像適当" width="1300" height="800">
    </a>
</div>
