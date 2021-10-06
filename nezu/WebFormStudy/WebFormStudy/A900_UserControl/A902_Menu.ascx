<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="A902_Menu.ascx.cs" Inherits="WebFormStudy.A900_UserControl.A903_Menu" %>

<asp:Panel ID="PanelMenu" runat="server" Height="900px" Width="200px" HorizontalAlign="Center" BorderColor="Silver" ForeColor="White" BorderWidth="3px">
    <asp:Panel ID="PanelMenuHeader" runat="server" BackColor="CornflowerBlue" Height="24px">
        <asp:Label ID="lblHederTitle" runat="server" Text="Label"></asp:Label>
    </asp:Panel>
    <asp:Panel ID="PanelMenuContents" runat="server" Height="500px" Width="200px" Font-Size="Medium">
        <div Class="MenuContents">
            <asp:LinkButton ID="LinkMenu" runat="server">LinkButton</asp:LinkButton>
        </div>
    </asp:Panel>
</asp:Panel>
