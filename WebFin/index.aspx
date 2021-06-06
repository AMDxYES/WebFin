<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="index.aspx.cs" Inherits="WebFin.index" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
<meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
    <title></title>
</head>
<body>
   <form id="form1" runat="server" style="text-align: center">
        <div>
            <asp:Label ID="lb_login" runat="server" Text="登入" Font-Overline="False" Font-Size="X-Large" Font-Strikeout="False" Font-Underline="False" ForeColor="#0066FF"></asp:Label><br /><br />
            <asp:Label ID="lb_accounts" runat="server" Text="帳號："></asp:Label>
            <asp:TextBox ID="tb_accounts" runat="server"></asp:TextBox><br /><br />
            <asp:Label ID="lb_password" runat="server" Text="密碼："></asp:Label>
            <asp:TextBox ID="tb_password" runat="server" TextMode="Password"></asp:TextBox><br /><br />
            <asp:HyperLink ID="hy_create" runat="server" NavigateUrl="sign_up.aspx">我還沒有帳號</asp:HyperLink><br /><br />
            <asp:Button ID="btn_login" runat="server" Text="登入" OnClick="btn_login_Click" />
        </div>
    </form>
</body>
</html>
