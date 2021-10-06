<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="A012_ShouhinList.aspx.cs" Inherits="WebFormStudy.A010_Shouhin.A012_ShouhinList" %>
<%@ Register Tagprefix="win" Tagname="NaviHeader" Src="~/A900_UserControl/A901_Heder.ascx" %>
<%@ Register Tagprefix="win" Tagname="NaviMenu" Src="~/A900_UserControl/A902_Menu.ascx" %>

<html>
<head runat="server">
<meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
    <title>商品一覧</title>
    
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
            <asp:GridView ID="ShouhinGridView" runat="server" AllowSorting="True" AutoGenerateColumns="False" CellPadding="4" DataKeyNames="ShouhinId" DataSourceID="sds" ForeColor="#333333" GridLines="None" Width="1200px">
                <AlternatingRowStyle BackColor="White" />
                <Columns>
                    <asp:BoundField DataField="ShouhinId" HeaderText="商品ID" ReadOnly="True" SortExpression="ShouhinId" />
                    <asp:BoundField DataField="ShouhinName" HeaderText="商品名" SortExpression="ShouhinName" />
                    <asp:BoundField DataField="ShouhinDetail" HeaderText="商品詳細" SortExpression="ShouhinDetail" />
                    <asp:BoundField DataField="ZaikoSuu" HeaderText="在庫数" SortExpression="ZaikoSuu" />
                    <asp:BoundField DataField="UpdateDate" HeaderText="更新日時" SortExpression="UpdateDate" />
                    <asp:CommandField ShowDeleteButton="True" ShowSelectButton="True" ButtonType="Button" />
                </Columns>
                <EditRowStyle BackColor="#2461BF" />
                <FooterStyle BackColor="#507CD1" Font-Bold="True" ForeColor="White" />
                <HeaderStyle BackColor="#507CD1" Font-Bold="True" ForeColor="White" />
                <PagerStyle BackColor="#2461BF" ForeColor="White" HorizontalAlign="Center" />
                <RowStyle BackColor="#EFF3FB" />
                <SelectedRowStyle BackColor="#D1DDF1" Font-Bold="True" ForeColor="#333333" />
                <SortedAscendingCellStyle BackColor="#F5F7FB" />
                <SortedAscendingHeaderStyle BackColor="#6D95E1" />
                <SortedDescendingCellStyle BackColor="#E9EBEF" />
                <SortedDescendingHeaderStyle BackColor="#4870BE" />
            </asp:GridView>
            <asp:SqlDataSource ID="sds" runat="server" ConnectionString="<%$ ConnectionStrings:HosyuStudy %>" ></asp:SqlDataSource>
        </div>
        <div Class="Footer">
            <asp:Panel ID="PnlFooter" runat="server" BorderColor="Silver" BorderWidth="3px" Height="80px" Width="1650px" HorizontalAlign="Right">
                <P Class="FooterBtn">
                    <asp:Button ID="btnClose" runat="server" Text="閉じる" Font-Size="Medium" Height="35px" TabIndex="5" Width="100px" OnClientClick="window.close()" />
                </P>
            </asp:Panel>
        </div>
    </form>
</body>
</html>
