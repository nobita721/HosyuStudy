@ModelType HoujinWeb.HoujinModel
@Code
    ViewData("Title") = "法人情報検索"
    ViewData("ScreenName") = "法人情報検索"
    ViewData("ControlName") = "Houjin"
    ViewData("ActionName") = "HoujinInfoList"
    Layout = "~/Views/Shared/_LayoutHoujin.vbhtml"
End Code

@Section Menu
    @RenderPage("~/Views/Houjin/HoujinMenu.vbhtml")
End Section

<div>
    <div class="form-group">
        <p>@ViewBag.Message</p>
        <div class="control-label col-md-3" style="font-size:larger">
            @Html.Label("法人ID")
        </div>
        <div class="col-md-9">
            @Html.TextBoxFor(Function(model) model.HoujinID, New With {.size = 80, .maxlength = 5})
        </div>
    </div>
    <div class="form-group">
        <div class="control-label col-md-3" style="font-size:larger">
            @Html.Label("法人名称")
        </div>
        <div class="col-md-9">
            @Html.TextBoxFor(Function(model) model.HoujinName, New With {.size = 80, .maxlength = 20})
        </div>
    </div>
</div>




