
@Code
    Layout = Nothing
End Code

<script type="text/javascript">
    function openWinTab() {
        window.open(
            "/HoujinTab/HoujinTabList",
            "_blank",
            "menubar=0,width=2000,height=1200,top=100,left=100"
        );
    }
</script>

<div>
    @*法人メニュー*@
    @Select Case TempData("Display")
        Case "Serch"
            @<a href="@Url.Action("HoujinTabList", "HoujinTab")" target="_blank" onclick="openWinTab()">法人タブ付き</a>
        Case "TabList"
            @<p>@Html.ActionLink("法人タブ付き登録", "HoujinTabCreate")</p>
        Case "SerchDetails"
            @<p>@Html.ActionLink("法人情報登録", "HoujinInfoCreate")</p>
    End Select
</div>

