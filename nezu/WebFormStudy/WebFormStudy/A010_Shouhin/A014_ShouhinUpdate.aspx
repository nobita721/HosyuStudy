<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="A014_ShouhinUpdate.aspx.cs" Inherits="WebFormStudy.A010_Shouhin.A014_ShouhinUpdate" %>
<%@ Register Tagprefix="win" Tagname="NaviHeader" Src="~/A900_UserControl/A901_Heder.ascx" %>
<%@ Register Tagprefix="win" Tagname="NaviMenu" Src="~/A900_UserControl/A902_Menu.ascx" %>

<html>
<head runat="server">
<meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
    <title>商品詳細</title>

    <webopt:bundlereference runat="server" path="~/Content/Common.css" />

<%--    <script type = "text/javascript">
        function Calc()
        {
            //alert("あ");
            //document.dispatchEvent(new KeyboardEvent("keydown", { key: "Enter" }));
            //document.getElementById(" 対象のid名 ").dispatchEvent(new KeyboardEvent("keydown", { keyCode: 40 }));
            // チェックする前にEnterキー押下
            //document.getElementById(" txtSuuRyou ").dispatchEvent(new KeyboardEvent("keydown", { key: "Enter" }));
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
                <asp:Label ID="lblShouhinIdDisp" runat="server" Height="30px" Width="700px"></asp:Label>
            </div>
            <div>
                <asp:Label ID="lblShouhinName" runat="server" Text="商品名称" Font-Size="Medium" Height="40px" Width="200px"></asp:Label>
                <asp:TextBox ID="txtShouhinName" runat="server" TabIndex="1" Height="30px" Width="700px"></asp:TextBox>
                <asp:RequiredFieldValidator ID="reqShouhinName" runat="server" 
                    ControlToValidate="txtShouhinName" ErrorMessage="商品名称は必須です。" SetFocusOnError="True" 
                    ValidationGroup="upd"><font color="red">*</font></asp:RequiredFieldValidator>
            </div>
            <div>
                <asp:Label ID="lblShouhinDetail" runat="server" Text="商品詳細" Font-Size="Medium" Height="40px" Width="200px"></asp:Label>
                <asp:TextBox ID="txtShouhinDetail" runat="server" TabIndex="2" Height="30px" Width="700px"></asp:TextBox>
                <asp:RequiredFieldValidator ID="reqShouhinDetail" runat="server" 
                    ControlToValidate="txtShouhinDetail" ErrorMessage="商品詳細は必須です。" SetFocusOnError="True" 
                    ValidationGroup="upd"><font color="red">*</font></asp:RequiredFieldValidator>
            </div>
            <div>
                <asp:Label ID="lblZaikoSuu" runat="server" Text="在庫数" Font-Size="Medium" Height="40px" Width="200px"></asp:Label>
                <asp:TextBox ID="txtZaikoSuu" runat="server" Height="30px" Width="700px" Enabled="False"></asp:TextBox>
                <%-- RangeValidatorだと数量手打ち→フォーカス移動しないで更新ボタンを押すと計算後の値をセットする前に
                    エラーチェックをやってしまうので、CustomValidatorで実施。 --%>
                <asp:RangeValidator ID="ranZaikoSuu" runat="server" 
                    ControlToValidate="txtZaikoSuu" ErrorMessage="入荷数は1～20の範囲で入力してください。" 
                    MaximumValue="20" MinimumValue="1" SetFocusOnError="True" Type="Integer" 
                    ValidationGroup="upd"><font color="red">*</font></asp:RangeValidator>
                <%--                <asp:CustomValidator id="cusZaikoSuu" runat="Server"
                    ControlToValidate="txtZaikoSuu" ErrorMessage="" SetFocusOnError="True"
                    OnServerValidate="customValid_ServerValidate"  
                    ValidationGroup="upd"><font color="red">*</font></asp:CustomValidator>--%>
            </div>
            <div>
                <asp:Label ID="lblNyuuSyukka" runat="server" Text="入出荷選択" Font-Size="Medium" Height="40px" Width="200px"></asp:Label>
                <asp:RadioButton ID="rdobtnNyuuka" runat="server" TabIndex="3" Text="入荷" GroupName="Suuryou" Checked="true" OnCheckedChanged="rdobtnNyuuka_CheckedChanged" AutoPostBack="True" />
                <asp:RadioButton ID="rdobtnSyukka" runat="server" TabIndex="4" Text="出荷" GroupName="Suuryou" Checked="false" OnCheckedChanged="rdobtnSyukka_CheckedChanged" AutoPostBack="True" />
            </div>
            <div>
                <asp:Label ID="lblSuuRyou" runat="server" Text="数量" Font-Size="Medium" Height="40px" Width="200px"></asp:Label>
                <%--発表会で説明したら消す--%>
<%--                <asp:TextBox ID="txtSuuRyou" runat="server" TabIndex="5" Height="30px" Width="700px" MaxLength="2" OnTextChanged="txtSuuRyou_TextChanged" AutoPostBack="True"></asp:TextBox>
                <asp:RegularExpressionValidator ID="regSuuRyou" runat="server" 
                    ControlToValidate="txtSuuRyou" ErrorMessage="数量は半角数字で入力してください。" ValidationExpression="^[0-9]+$" 
                    ValidationGroup="upd"><font color="red">*</font></asp:RegularExpressionValidator>--%>
                <asp:DropDownList ID="ddlSuuRyou" runat="server" Height="30px" Width="70px" OnSelectedIndexChanged="ddlSuuRyou_SelectedIndexChanged" AutoPostBack="true"></asp:DropDownList>
            </div>
            <asp:ValidationSummary ID="valSum" DisplayMode="BulletList"
                ShowMessageBox="true" ShowSummary="False" HeaderText="入力エラー"
                Font-Names="verdana" Font-Size="12" runat="server"
                ValidationGroup="upd" EnableClientScript="True"/>
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
<%--                    <asp:Button ID="btnUpdate" runat="server" Text="更新" Font-Size="Medium" Height="35px" TabIndex="6" Width="100px" 
                        OnClick="btnUpdate_Click" OnClientClick="Calc()" ValidationGroup="upd"/>--%>
                    <asp:Button ID="btnUpdate" runat="server" Text="更新" Font-Size="Medium" Height="35px" TabIndex="6" Width="100px" 
                        OnClick="btnUpdate_Click" ValidationGroup="upd"/>
                    <asp:Button ID="btnReturn" runat="server" Text="戻る" Font-Size="Medium" Height="35px" TabIndex="7" Width="100px" 
                        OnClick="btnReturn_Click"/>
                </P>
            </asp:Panel>
        </div>
    </form>
</body>
</html>

