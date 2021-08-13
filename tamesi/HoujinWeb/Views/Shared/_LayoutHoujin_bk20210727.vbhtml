<!DOCTYPE html>
<html>
<head>
    <meta http-equiv="Content-Type" content="text/html; charset=utf-8" />
    <meta charset="utf-8" />
    <meta name="viewport" content="width=device-width, initial-scale=1.0">
    <title>@ViewBag.Title - 法人WEBポータル</title>
    @Styles.Render("~/Content/css")
    @Scripts.Render("~/bundles/modernizr")
    @RenderSection("Top", False)
    @RenderSection("Close", False)
</head>

<body class="bg-success">
    <div class="col-md-1">
        <div id="Menu">
            @RenderSection("Menu", False)
        </div>
        @*トップ画面の境界線線が下に移動されてしまう。解決できないので一旦あきらめる。。*@
        @*<div Class="LayoutRight"></div>*@
        @If ViewData("ScreenName") IsNot "法人WEBポータル" Then
            @<div Class="LayoutRight"></div>
        End If
    </div>
    <div class="col-md-11">
        <div class="navbar text-center">
            <div class="container">
                <h1>@ViewBag.ScreenName</h1>
            </div>
        </div>
        <form action="/@ViewBag.ControlName/@ViewBag.ActionName" id="@ViewBag.ActionName" method="post">
            <div id="wrap">
                <div class="container body-content form-horizontal">
                    @RenderBody()
                </div>
                <div Class="footer">
                    <div Class="container">
                        <div Class="pull-right">
                            @Select Case ViewData("ScreenName")
                                Case "法人情報検索"
                                    @<div class="form-group">
                                        <input type="submit" name="SerchBtn" value="検索実行" />
                                        <input type="button" name="CloseBtn" value="閉じる" onclick="window.close()" />
                                    </div>
                                Case "法人情報一覧"
                                    @<div class="form-group">
                                        <input type="submit" name="HoujinListBack" value="戻る" />
                                    </div>
                                Case "法人情報登録"
                                    @<div class="form-group">
                                        <input type="submit" name="CreateBtn" value="登録" />
                                        <input type="button" value="戻る" onclick="location.href='@Url.Action("HoujinSerchDetails", "Houjin")'" />
                                    </div>
                                Case "法人情報編集"
                                    @<div class="form-group">
                                        <input type="submit" name="EditBtn" value="編集" />
                                        <input type="button" value="戻る" onclick="location.href='@Url.Action("HoujininfoList", "Houjin")'" />
                                    </div>
                                Case "法人情報削除"
                                    @<div class="form-group">
                                        <input type="submit" name="DeleteBtn" value="削除" />
                                        <input type="button" value="戻る" onclick="location.href='@Url.Action("HoujininfoList", "Houjin")'" />
                                    </div>
                                Case Else
                                    '何も表示しない
                            End Select
                        </div>
                    </div>
                </div>
            </div>
        </form>
    </div>


    @Scripts.Render("~/bundles/jquery")
    @Scripts.Render("~/bundles/bootstrap")
    @RenderSection("scripts", required:=False)


</body>
</html>