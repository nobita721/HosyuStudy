<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="A013_ShouhinInsert.aspx.cs" Inherits="WebFormStudy.A010_Shouhin.A013_ShouhinInsert" %>
<%@ Register Tagprefix="win" Tagname="NaviHeader" Src="~/A900_UserControl/A901_Heder.ascx" %>
<%@ Register Tagprefix="win" Tagname="NaviMenu" Src="~/A900_UserControl/A902_Menu.ascx" %>

<html>
<head runat="server">
<meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
    <title>商品登録</title>

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
                <asp:TextBox ID="txtShouhinId" runat="server" TabIndex="1" Height="30px" Width="700px" MaxLength="6"></asp:TextBox>
                <asp:RequiredFieldValidator ID="reqShouhinId" runat="server" 
                    ControlToValidate="txtShouhinId" ErrorMessage="商品IDは必須です。" SetFocusOnError="True" 
                    ValidationGroup="new"><font color="red">*</font></asp:RequiredFieldValidator>
                <asp:RegularExpressionValidator ID="regShouhinId" runat="server" 
                    ControlToValidate="txtShouhinId" ErrorMessage="商品IDは半角数字5桁で入力してください。" ValidationExpression="^[0-9]{5}" 
                    ValidationGroup="new"><font color="red">*</font></asp:RegularExpressionValidator>
                <%--DBの重複チェック--%>
                <asp:CustomValidator id="cusShouhinId" runat="Server"
                    ControlToValidate="txtShouhinId" ErrorMessage="" SetFocusOnError="True"
                    OnServerValidate="customValid_ServerValidate"  
                    ValidationGroup="new"><font color="red">*</font></asp:CustomValidator>
            </div>
            <div>
                <asp:Label ID="lblShouhinName" runat="server" Text="商品名称" Font-Size="Medium" Height="40px" Width="200px"></asp:Label>
                <asp:TextBox ID="txtShouhinName" runat="server" TabIndex="2" Height="30px" Width="700px"></asp:TextBox>
                <asp:RequiredFieldValidator ID="reqShouhinName" runat="server" 
                    ControlToValidate="txtShouhinName" ErrorMessage="商品名称は必須です。" SetFocusOnError="True" 
                    ValidationGroup="new"><font color="red">*</font></asp:RequiredFieldValidator>
            </div>
            <div>
                <asp:Label ID="lblShouhinDetail" runat="server" Text="商品詳細" Font-Size="Medium" Height="40px" Width="200px"></asp:Label>
                <asp:TextBox ID="txtShouhinDetail" runat="server" TabIndex="3" Height="30px" Width="700px"></asp:TextBox>
                <asp:RequiredFieldValidator ID="reqShouhinDetail" runat="server" 
                    ControlToValidate="txtShouhinDetail" ErrorMessage="商品詳細は必須です。" SetFocusOnError="True" 
                    ValidationGroup="new"><font color="red">*</font></asp:RequiredFieldValidator>
            </div>
            <div>
                <asp:Label ID="lblNyuukaSuu" runat="server" Text="入荷数" Font-Size="Medium" Height="40px" Width="200px"></asp:Label>
                <asp:TextBox ID="txtNyuukaSuu" runat="server" TabIndex="4" Height="30px" Width="700px" MaxLength="2"></asp:TextBox>
                <asp:RequiredFieldValidator ID="reqNyuukaSuu" runat="server" 
                    ControlToValidate="txtNyuukaSuu" ErrorMessage="入荷数は必須です。" SetFocusOnError="True" 
                    ValidationGroup="new"><font color="red">*</font></asp:RequiredFieldValidator>
                <asp:RegularExpressionValidator ID="regNyuukaSuu" runat="server" 
                    ControlToValidate="txtNyuukaSuu" ErrorMessage="入荷数は半角数字で入力してください。" ValidationExpression="^[0-9]+$" 
                    ValidationGroup="new"><font color="red">*</font></asp:RegularExpressionValidator>
                <asp:RangeValidator ID="ranNyuukaSuu" runat="server" 
                    ControlToValidate="txtNyuukaSuu" ErrorMessage="入荷数は1～20の範囲で入力してください。" 
                    MaximumValue="20" MinimumValue="1" SetFocusOnError="True" Type="Integer" 
                    ValidationGroup="new"><font color="red">*</font></asp:RangeValidator>
            </div>
            <asp:ValidationSummary ID="valSum" DisplayMode="BulletList"
                ShowMessageBox="true" ShowSummary="False" HeaderText="入力エラー"
                Font-Names="verdana" Font-Size="12" runat="server"
                ValidationGroup="new" EnableClientScript="True"/>
        </div>
        <div Class="Footer">
            <asp:Panel ID="PnlFooter" runat="server" BorderColor="Silver" BorderWidth="3px" Height="80px" Width="1650px" HorizontalAlign="Right">
                <P Class="FooterBtn">
                    <asp:Button ID="btnInsert" runat="server" Text="登録" Font-Size="Medium" Height="35px" TabIndex="5" Width="100px" 
                        OnClick="btnInsert_Click" ValidationGroup="new"/>
                    <asp:Button ID="btnReturn" runat="server" Text="戻る" Font-Size="Medium" Height="35px" TabIndex="6" Width="100px" 
                        OnClick="btnReturn_Click"/>
                </P>
            </asp:Panel>
        </div>
    </form>
</body>
</html>
