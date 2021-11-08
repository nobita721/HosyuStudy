<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="A001_Top.aspx.cs" Inherits="WebFormStudy.A001_Top.A001_Top" %>
<%@ Register Tagprefix="win" Tagname="NaviHeader" Src="~/A900_UserControl/A901_Heder.ascx" %>
<%@ Register Tagprefix="win" Tagname="NaviMenu" Src="~/A900_UserControl/A902_Menu.ascx" %>

<html>
<head runat="server">
<meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
    <title>トップ画面</title>

    <webopt:bundlereference runat="server" path="~/Content/Common.css" />

    <script type="text/javascript">
        // アンロード時にサブ画面を閉じる
        window.onunload = function () {
            closeWindow();
        }

        function openWin() {
            var url = '../A010_Shouhin/A011_ShouhinSerch.aspx';
            // 画面サイズ測定
            x = screen.width;
            y = screen.height;
            var subWindow = window.open(
                            url,
                            'ShouhinSerch',
                            "screenX=0,screenY=0,left=0,top=0,width=" + x + ",height=" + y + ",scrollbars=0,toolbar=0,menubar=0,staus=0,resizable=0"
            );
            window.focus();
            subWindow.focus();
        }

        // すでに開いているかチェックする
        window.addEventListener('unload', function (event) {
            if (typeof subWindow != "undefined") {
                subWindow.close();
            }
        });

    </script>

</head>
<body>
    <form runat="server">
        <div Class="Menu">
            <win:NaviMenu id="navimenu" runat="Server" />
        </div>
        <div Class="Header">
            <win:NaviHeader id="navihead" runat="Server" />
        </div>
        <div Class="ContentTop">
            <a href="javascript:void(0);" onclick="openWin()">
                <asp:Image ID="btnImgSerch" runat="server" Height="830px" Width="1650px" ImageUrl="~/Images/bird.png" />
            </a>
        </div>
    </form>
</body>
</html>
