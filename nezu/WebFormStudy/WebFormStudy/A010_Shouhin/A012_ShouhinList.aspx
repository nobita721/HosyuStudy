<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="A012_ShouhinList.aspx.cs" Inherits="WebFormStudy.A010_Shouhin.A012_ShouhinList" %>
<%@ Register Tagprefix="win" Tagname="NaviHeader" Src="~/A900_UserControl/A901_Heder.ascx" %>
<%@ Register Tagprefix="win" Tagname="NaviMenu" Src="~/A900_UserControl/A902_Menu.ascx" %>

<html>
<head runat="server">
<meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
    <title id="title">商品一覧</title>
    
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
            <asp:GridView ID="ShouhinGridView" runat="server" AllowSorting="True" AutoGenerateColumns="False" CellPadding="4" DataKeyNames="ShouhinId" ForeColor="#333333" GridLines="None" Width="1200px" OnSelectedIndexChanged="ShouhinGridView_SelectedIndexChanged" OnRowDeleting="ShouhinGridView_RowDeleting" ShowHeaderWhenEmpty="True">
                <AlternatingRowStyle BackColor="White" />
                <Columns>
                    <asp:BoundField DataField="ShouhinId" HeaderText="商品ID" ReadOnly="True" />
                    <asp:BoundField DataField="HistNo" HeaderText="" Visible="false" />
                    <asp:BoundField DataField="ShouhinName" HeaderText="商品名" />
                    <asp:BoundField DataField="ShouhinDetail" HeaderText="商品詳細"  />
                    <asp:BoundField DataField="ZaikoSuu" HeaderText="在庫数" >
                    <ItemStyle HorizontalAlign="Right" />
                    </asp:BoundField>
                    <asp:BoundField DataField="UpdateDate" HeaderText="更新日時" >
                    <ItemStyle HorizontalAlign="Right" />
                    </asp:BoundField>
                    <asp:CommandField ShowDeleteButton="True" ShowSelectButton="True" ButtonType="Button" >
                    <ItemStyle HorizontalAlign="Center" />
                    </asp:CommandField>
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
            <%--検索画面の入力値を保持するため設定--%>
            <asp:HiddenField id="HiddenShouhinId" runat="server" value=""/>
            <asp:HiddenField id="HiddenShouhinName" runat="server" value=""/>
            <asp:HiddenField id="HiddenShouhinDetail" runat="server" value=""/>
        </div>
        <div Class="Footer">
            <asp:Panel ID="PnlFooter" runat="server" BorderColor="Silver" BorderWidth="3px" Height="80px" Width="1650px" HorizontalAlign="Right">
                <P Class="FooterBtn">
                    <asp:Button ID="btnReturn" runat="server" Text="戻る" Font-Size="Medium" Height="35px" TabIndex="5" Width="100px" OnClick="btnReturn_Click" />
                </P>
            </asp:Panel>
        </div>
    </form>
</body>
</html>
