@ModelType HoujinWeb.HoujinTbl

@Code
    ViewData("Title") = "法人情報削除"
    ViewData("ScreenName") = "法人情報削除"
    ViewData("ControlName") = "Houjin"
    ViewData("ActionName") = "HoujinInfoDelete"
    Layout = "~/Views/Shared/_LayoutHoujin.vbhtml"
End Code

@Section Menu
    @RenderPage("~/Views/Houjin/HoujinMenu.vbhtml")
End Section

<div>
    <h3>削除してもよろしいですか?</h3>
    <dl class="dl-horizontal">
        <dt>
            @Html.DisplayNameFor(Function(model) model.HoujinID)
        </dt>

        <dd>
            @Html.DisplayFor(Function(model) model.HoujinID)
        </dd>

        <dt>
            @Html.DisplayNameFor(Function(model) model.HoujinName)
        </dt>

        <dd>
            @Html.DisplayFor(Function(model) model.HoujinName)
        </dd>
    </dl>
</div>
