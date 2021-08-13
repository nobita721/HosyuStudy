@ModelType IEnumerable(Of HoujinWeb.HoujinTbl)
@Code
    ViewData("Title") = "法人情報一覧"
    ViewData("ScreenName") = "法人情報一覧"
    ViewData("ControlName") = "Houjin"
    ViewData("ActionName") = "HoujinSerchDetails"
    Layout = "~/Views/Shared/_LayoutHoujin.vbhtml"
End Code

@Section Menu
    @RenderPage("~/Views/Houjin/HoujinMenu.vbhtml")
End Section

<table class="table table-bordered table-hover table-responsive">
    <tr>
        <th scope="col">
            @Html.DisplayNameFor(Function(model) model.HoujinID)
        </th>
        <th scope="col">
            @Html.DisplayNameFor(Function(model) model.HoujinName)
        </th>
        <th></th>
    </tr>
    @For Each item In Model
        @<tr>
            <td>
                @Html.DisplayFor(Function(modelItem) item.HoujinID)
            </td>
            <td>
                @Html.DisplayFor(Function(modelItem) item.HoujinName)
            </td>
            <td>
                @Html.ActionLink("編集", "HoujinInfoEdit", New With {.houjinid = item.HoujinID}) |
                @Html.ActionLink("削除", "HoujinInfoDelete", New With {.houjinid = item.HoujinID})
            </td>
        </tr>
    Next
</table>

