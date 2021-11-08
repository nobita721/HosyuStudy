<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="A011_ShouhinSerch.aspx.cs" Inherits="WebFormStudy.A010_Shouhin.A011_ShouhinSerch" %>
<%@ Register Tagprefix="win" Tagname="NaviHeader" Src="~/A900_UserControl/A901_Heder.ascx" %>
<%@ Register Tagprefix="win" Tagname="NaviMenu" Src="~/A900_UserControl/A902_Menu.ascx" %>

<html>
<head runat="server">
<meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
    <title>商品検索</title>

    <webopt:bundlereference runat="server" path="~/Content/Common.css" />

<%--    <script type="text/javascript">
        function openWin() {
            var url = 'A012_ShouhinList.aspx';
            var sid = document.forms.form1.txtShouhinId.value;
            var sname = document.forms.form1.txtShouhinName.value;
            var sdetail = document.forms.form1.txtShouhinDetail.value;
            var url = url + '?sid=' + sid + '&sname=' + sname + '&sdetail=' + sdetail;
            // 画面サイズ測定
            x = (screen.width) / 1;
            y = (screen.height) / 1;
            window.open(
                url,
                "_blank",
                "screenX=0,screenY=0,left=0,top=0,width=" + x + ",height=" + y + ",scrollbars=0,toolbar=0,menubar=0,staus=0,resizable=0"
            );
        }
    </script>--%>

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
                <asp:TextBox ID="txtShouhinId" runat="server" TabIndex="1" Height="30px" Width="700px"></asp:TextBox>
            </div>
            <div>
                <asp:Label ID="lblShouhinName" runat="server" Text="商品名称" Font-Size="Medium" Height="40px" Width="200px"></asp:Label>
                <asp:TextBox ID="txtShouhinName" runat="server" TabIndex="2" Height="30px" Width="700px"></asp:TextBox>
            </div>
            <div>
                <asp:Label ID="lblShouhinDetail" runat="server" Text="商品詳細" Font-Size="Medium" Height="40px" Width="200px"></asp:Label>
                <asp:TextBox ID="txtShouhinDetail" runat="server" TabIndex="3" Height="30px" Width="700px"></asp:TextBox>
            </div>
        </div>
        <div Class="Footer">
            <asp:Panel ID="PnlFooter" runat="server" BorderColor="Silver" BorderWidth="3px" Height="80px" Width="1650px" HorizontalAlign="Right">
                <P Class="FooterBtn">
                    <%--<asp:Button ID="btnSerch" runat="server" Text="検索" Font-Size="Medium" Height="35px" TabIndex="4" Width="100px" OnClientClick="openWin()" />--%>
                    <asp:Button ID="btnSerch" runat="server" Text="検索" Font-Size="Medium" Height="35px" TabIndex="4" Width="100px" OnClick="btnSerch_Click"/>
                    <asp:Button ID="btnClose" runat="server" Text="閉じる" Font-Size="Medium" Height="35px" TabIndex="5" Width="100px" OnClientClick="window.close()" />
                </P>
            </asp:Panel>
        </div>
    </form>
</body>
</html>
