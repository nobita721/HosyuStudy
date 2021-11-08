<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="A014_ShouhinUpdate.aspx.cs" Inherits="WebFormStudy.A010_Shouhin.A014_ShouhinUpdate" %>
<%@ Register Tagprefix="win" Tagname="NaviHeader" Src="~/A900_UserControl/A901_Heder.ascx" %>
<%@ Register Tagprefix="win" Tagname="NaviMenu" Src="~/A900_UserControl/A902_Menu.ascx" %>

<html>
<head runat="server">
<meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
    <title>商品編集</title>

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
                <asp:TextBox ID="txtShouhinName" runat="server" TabIndex="1" Height="30px" Width="700px"></asp:TextBox>
            </div>
            <div>
                <asp:Label ID="lblShouhinDetail" runat="server" Text="商品詳細" Font-Size="Medium" Height="40px" Width="200px"></asp:Label>
                <asp:TextBox ID="txtShouhinDetail" runat="server" TabIndex="2" Height="30px" Width="700px"></asp:TextBox>
            </div>
            <div>
                <asp:Label ID="lblZaikosuu" runat="server" Text="在庫数" Font-Size="Medium" Height="40px" Width="200px"></asp:Label>
                <asp:Label ID="lblZaikosuuDisp" runat="server" Height="30px" Width="700px"></asp:Label>
            </div>
            <div>
                <asp:Label ID="lblNyuuSyukka" runat="server" Text="入出荷選択" Font-Size="Medium" Height="40px" Width="200px"></asp:Label>
                <asp:RadioButton ID="rdobtnNyuuka" runat="server" TabIndex="3" Text="入荷" GroupName="Suuryou" Checked="true" />
                <asp:RadioButton ID="rdobtnSyukka" runat="server" TabIndex="4" Text="出荷" GroupName="Suuryou" Checked="false" />
            </div>
            <div>
                <asp:Label ID="lblSuuRyou" runat="server" Text="数量" Font-Size="Medium" Height="40px" Width="200px"></asp:Label>
                <asp:TextBox ID="txtSuuRyou" runat="server" TabIndex="5" Height="30px" Width="700px" MaxLength="2"></asp:TextBox>
            </div>
        </div>
        <div Class="Footer">
            <asp:Panel ID="PnlFooter" runat="server" BorderColor="Silver" BorderWidth="3px" Height="80px" Width="1650px" HorizontalAlign="Right">
                <P Class="FooterBtn">
                    <asp:Button ID="btnUpdate" runat="server" Text="更新" Font-Size="Medium" Height="35px" TabIndex="6" Width="100px" 
                        OnClick="btnInsert_Click" ValidationGroup="new"/>
                    <asp:Button ID="btnReturn" runat="server" Text="戻る" Font-Size="Medium" Height="35px" TabIndex="7" Width="100px" 
                        OnClick="btnReturn_Click"/>
                </P>
            </asp:Panel>
        </div>
    </form>
</body>
</html>

