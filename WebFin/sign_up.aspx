<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="sign_up.aspx.cs" Inherits="WebFin.sign_up" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
<meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
    <title></title>
</head>
<body>
    <div style="text-align:center;">
            <asp:Label ID="lb_create" runat="server" Text="創建帳號"></asp:Label><br /><br />
        </div>
    <form id="form1" runat="server">
        <div style="padding-left: 40%;">
            <asp:Label ID="lb_mail" runat="server" Text="電子信箱 mail："></asp:Label>
            <asp:TextBox ID="tb_mail" runat="server" ></asp:TextBox>
            <asp:RegularExpressionValidator ID="rev_mail" runat="server" ErrorMessage="格式不正確" ControlToValidate="tb_mail" ForeColor="Red" ValidationExpression="^\w+((-\w+)|(\.\w+))*\@[a-zA-Z0-9]+((\.|-)[a-zA-Z0-9]+)*\.[a-zA-Z]+$"></asp:RegularExpressionValidator><br /><br />
            <asp:Label ID="lb_password" runat="server" Text="密碼 password："></asp:Label>
            <asp:TextBox ID="tb_password" runat="server" TextMode="Password" EnableTheming="True" MaxLength="20"></asp:TextBox>
            <asp:RegularExpressionValidator ID="rev_password" runat="server" ControlToValidate="tb_password" ErrorMessage="密碼至少6碼" ForeColor="Red" ValidationExpression="[a-zA-Z0-9]{6,20}"></asp:RegularExpressionValidator>
            <br /><br />
            <asp:Label ID="lb_checkpassword" runat="server" Text="確認密碼 check_password："></asp:Label>
            <asp:TextBox ID="tb_checkpassword" runat="server" TextMode="Password" MaxLength="20"></asp:TextBox>
            <asp:CompareValidator ID="cv_password" runat="server" ErrorMessage="二次密碼不一致" ForeColor="Red" ControlToCompare="tb_password" ControlToValidate="tb_checkpassword"></asp:CompareValidator><br /><br />
            <asp:Label ID="lb_name" runat="server" Text="姓名："></asp:Label>
            <asp:TextBox ID="tb_name" runat="server"></asp:TextBox><br /><br />
        </div>
        <div style="text-align:center">
            <asp:Button ID="btn_signup" runat="server" Text="創建帳號" OnClick="btn_signup_Click" />
        </div>
    </form>
</body>
</html>
