<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="A015_ShouhinDelete.aspx.cs" Inherits="WebFormStudy.A010_Shouhin.A015_ShouhinDelete" %>
<%@ Register Tagprefix="win" Tagname="NaviHeader" Src="~/A900_UserControl/A901_Heder.ascx" %>
<%@ Register Tagprefix="win" Tagname="NaviMenu" Src="~/A900_UserControl/A902_Menu.ascx" %>

<html>
<head runat="server">
<meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
    <title>商品削除</title>

    <webopt:bundlereference runat="server" path="~/Content/Common.css" />

</head>
<body>
    <form id="form1" runat="server">
        <div Class="Menu">
            <win:NaviMenu id="navimenu" runat="Server" />
        </div>
        <div Class="Header">
            <win:NaviHeader id="navihead" runat="Server" />
        </div>
        <div Class="Content">
            <div>
                <asp:Label ID="lblShouhinId" runat="server" Text="商品ID" Font-Size="Medium" Height="40px" Width="200px"></asp:Label>
                <asp:Label ID="lblShouhinIdDisp" runat="server" Height="30px" Width="700px"></asp:Label>
            </div>
            <div>
                <asp:Label ID="lblShouhinName" runat="server" Text="商品名称" Font-Size="Medium" Height="40px" Width="200px"></asp:Label>
                <asp:Label ID="lblShouhinNameDisp" runat="server" Height="30px" Width="700px"></asp:Label>
            </div>
            <div>
                <asp:Label ID="lblShouhinDetail" runat="server" Text="商品詳細" Font-Size="Medium" Height="40px" Width="200px"></asp:Label>
                <asp:Label ID="lblShouhinDetailDisp" runat="server" Height="30px" Width="700px"></asp:Label>
            </div>
            <div>
                <asp:Label ID="lblZaikoSuu" runat="server" Text="在庫数" Font-Size="Medium" Height="40px" Width="200px"></asp:Label>
                <asp:Label ID="lblZaikoSuuDisp" runat="server" Height="30px" Width="700px"></asp:Label>
            </div>
            <%--検索画面の入力値を保持するため設定--%>
            <asp:HiddenField id="HiddenShouhinId" runat="server" value=""/>
            <asp:HiddenField id="HiddenShouhinName" runat="server" value=""/>
            <asp:HiddenField id="HiddenShouhinDetail" runat="server" value=""/>
            <%--履歴Noを保持するため設定--%>
            <asp:HiddenField id="HiddenHistNo" runat="server" value=""/>
        </div>
        <div Class="Footer">
            <asp:Panel ID="PnlFooter" runat="server" BorderColor="Silver" BorderWidth="3px" Height="80px" Width="1650px" HorizontalAlign="Right">
                <P Class="FooterBtn">
                    <asp:Button ID="btnDelete" runat="server" Text="削除" Font-Size="Medium" Height="35px" TabIndex="5" Width="100px" OnClick="btnDelete_Click" />
                    <asp:Button ID="btnReturn" runat="server" Text="戻る" Font-Size="Medium" Height="35px" TabIndex="6" Width="100px" OnClick="btnReturn_Click"/>
                </P>
            </asp:Panel>
        </div>
    </form>
</body>
</html>
