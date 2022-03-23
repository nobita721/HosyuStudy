<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="errorinfo.aspx.cs" Inherits="WebFormStudy.errorinfo" %>
<html>
<head runat="server">
<meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
    <title id="title">エラー情報</title>
    <webopt:bundlereference runat="server" path="~/Content/Common.css" />
</head>
<body>
    <form id="form1" runat="server">
        <div align="left" style="width:100%; height:30px; padding:2px">
            <asp:Label ID="lblTitle" runat="server" Font-Bold="True" Font-Size="Large" ForeColor="Red" Text="エラーが発生しました！"></asp:Label>
        </div>
        <div style="width:100%; height:50px; padding:2px; border:2px solid #000000">
            <div style="display:inline-block; padding:12px">
                <asp:Label ID="lblContact" runat="server" Text="この画面を保存後、メールに添付してシステム管理者に送信してください。"></asp:Label>
            </div>
            <div style="display:inline-block; padding:8px; float:right" >
                <asp:Button ID="btnErrInfoSave" runat="server" Font-Size="Medium" Height="35px" Width="150px" Text="この画面を保存" OnClick="btnErrInfoSave_Click" />
                <asp:Button ID="btnErrInfoClose" runat="server" Font-Size="Medium" Height="35px" Width="150px" Text="保存せずに閉じる" OnClientClick="window.close()" />
            </div>
        </div>
        <div style="width:100%; height:30px; padding:2px; text-align:center; margin-top:5px">
            <table width="100%">
                <tr>
                    <td style="border:1px solid #000000" align="center" colspan="2">基本情報</td>
                </tr>
                <tr>
                    <td style="border:1px solid #000000" width="20%">画面名</td>
                    <td style="border:1px solid #000000" width="80%">
                        <asp:Label ID="lblDisplay" runat="server"></asp:Label>
                    </td>
                </tr>
                <tr>
                    <td style="border:1px solid #000000" width="20%">発生日時</td>
                    <td style="border:1px solid #000000" width="80%">
                        <asp:Label ID="lblDateTime" runat="server"></asp:Label>
                    </td>
                </tr>
                <tr>
                    <td style="border:1px solid #000000" width="20%">プログラム</td>
                    <td style="border:1px solid #000000" width="80%">
                        <asp:Label ID="lblProgram" runat="server"></asp:Label>
                    </td>
                </tr>
            </table>
            <table width="100%">
                <tr>
                    <td style="border:1px solid #000000" align="center">エラー内容</td>
                </tr>
                <tr>
                    <td style="border:1px solid #000000" width="70%" colspan="2">
                        <div style="overflow:auto; height:650px; width:1500px; padding:2px">
                            <pre><asp:Label ID="lblErrInfo" runat="server"></asp:Label></pre>
                        </div>
                    </td>
                </tr>
            </table>
        </div>
    </form>
</body>
</html>
