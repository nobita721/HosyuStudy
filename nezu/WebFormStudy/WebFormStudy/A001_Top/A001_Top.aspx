<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="A001_Top.aspx.cs" Inherits="WebFormStudy.A001_Top.A001_Top" %>
<%@ Register Tagprefix="win" Tagname="NaviHeader" Src="~/A900_UserControl/A901_Heder.ascx" %>
<%@ Register Tagprefix="win" Tagname="NaviMenu" Src="~/A900_UserControl/A902_Menu.ascx" %>

<html>
<head runat="server">
<meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
    <title>トップ画面</title>

    <%--<asp:PlaceHolder runat="server">
        <%: Scripts.Render("~/bundles/modernizr") %>
    </asp:PlaceHolder>--%>
    <webopt:bundlereference runat="server" path="~/Content/Common.css" />

    <script type="text/javascript">
        function openWin() {
            var url = '../A010_Shouhin/A011_ShouhinSerch.aspx';
            // 画面サイズ測定
            x = (screen.width) / 1;
            y = (screen.height) / 1;
            window.open(
                url,
                "_blank",
                "screenX=0,screenY=0,left=0,top=0,width=" + x + ",height=" + y + ",scrollbars=0,toolbar=0,menubar=0,staus=0,resizable=0"
        );
      }
    </script>

</head>
<body>
    <form runat="server">
        <%--<asp:ScriptManager runat="server">
            <Scripts>
                <asp:ScriptReference Name="MsAjaxBundle" />
                <asp:ScriptReference Name="jquery" />
                <asp:ScriptReference Name="bootstrap" />
                <asp:ScriptReference Name="WebForms.js" Assembly="System.Web" Path="~/Scripts/WebForms/WebForms.js" />
                <asp:ScriptReference Name="WebUIValidation.js" Assembly="System.Web" Path="~/Scripts/WebForms/WebUIValidation.js" />
                <asp:ScriptReference Name="MenuStandards.js" Assembly="System.Web" Path="~/Scripts/WebForms/MenuStandards.js" />
                <asp:ScriptReference Name="GridView.js" Assembly="System.Web" Path="~/Scripts/WebForms/GridView.js" />
                <asp:ScriptReference Name="DetailsView.js" Assembly="System.Web" Path="~/Scripts/WebForms/DetailsView.js" />
                <asp:ScriptReference Name="TreeView.js" Assembly="System.Web" Path="~/Scripts/WebForms/TreeView.js" />
                <asp:ScriptReference Name="WebParts.js" Assembly="System.Web" Path="~/Scripts/WebForms/WebParts.js" />
                <asp:ScriptReference Name="Focus.js" Assembly="System.Web" Path="~/Scripts/WebForms/Focus.js" />
                <asp:ScriptReference Name="WebFormsBundle" />
            </Scripts>
        </asp:ScriptManager>--%>

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

        <%--ポップアップブロックされて無理。javascriptは、ページに直書き。jsを外部ファイルにする方法は、後で検討--%>
        <%--<asp:ImageButton ID="imgBtnSerch" runat="server" Height="830px" Width="1650px" ImageUrl="~/Images/bird.png" OnClick="imgBtnSerch_Click" />--%>
    </form>
</body>
</html>
