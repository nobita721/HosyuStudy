@ModelType HoujinWeb.HoujinTbl

@Code
    ViewData("Title") = "法人情報登録"
    ViewData("ScreenName") = "法人情報登録"
    ViewData("ControlName") = "Houjin"
    ViewData("ActionName") = "HoujinInfoCreate"
    Layout = "~/Views/Shared/_LayoutHoujin.vbhtml"
End Code

@Section Menu
    @RenderPage("~/Views/Houjin/HoujinMenu.vbhtml")
End Section


@Scripts.Render("~/bundles/jquery")
@Scripts.Render("~/bundles/jqueryval")

@Html.AntiForgeryToken()
<div class="form-horizontal">
    @Html.ValidationSummary(True, "", New With {.class = "text-danger"})
    <p>@ViewBag.Message</p>
    <div class="form-group">
        @Html.LabelFor(Function(model) model.HoujinID, htmlAttributes:=New With {.class = "control-label col-md-2"})
        <div class="col-md-10">
            @Html.EditorFor(Function(model) model.HoujinID, New With {.htmlAttributes = New With {.class = "form-control", .maxlength = 5}})
            @Html.ValidationMessageFor(Function(model) model.HoujinID, "", New With {.class = "text-danger"})
        </div>
    </div>

    <div class="form-group">
        @Html.LabelFor(Function(model) model.HoujinName, htmlAttributes:=New With {.class = "control-label col-md-2"})
        <div class="col-md-10">
            @Html.EditorFor(Function(model) model.HoujinName, New With {.htmlAttributes = New With {.class = "form-control", .maxlength = 20}})
            @Html.ValidationMessageFor(Function(model) model.HoujinName, "", New With {.class = "text-danger"})
        </div>
    </div>
</div>

<HttpPost()>
    <ValidateAntiForgeryToken()>
