<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="addItem.aspx.cs" Inherits="WebFin.addItem" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
<meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
        <div>
             <asp:Label ID="lb_city" runat="server" Text="城市(City)"></asp:Label>
            <asp:DropDownList ID="ddl_City" runat="server" AutoPostBack="True" OnSelectedIndexChanged="ddl_City_SelectedIndexChanged" Font-Size="Large">
                <asp:ListItem>請選擇</asp:ListItem>
                <asp:ListItem>台北市</asp:ListItem>
                <asp:ListItem>新北市</asp:ListItem>
            </asp:DropDownList><br /><br />
            <asp:Label ID="lb_area" runat="server" Text="地區(Area)"></asp:Label>
            <asp:DropDownList ID="ddl_Area" runat="server" AutoPostBack="True" Font-Size="Large">
                <asp:ListItem>請選擇</asp:ListItem>
            </asp:DropDownList><br /><br />
            <asp:Label ID="lb_type" runat="server" Text="類別(Type)"></asp:Label>
            <asp:DropDownList ID="ddl_type" runat="server" AutoPostBack="True" Font-Size="Large">
                <asp:ListItem>請選擇</asp:ListItem>
            </asp:DropDownList><br /><br />
            <asp:Label ID="lb_img" runat="server" Text="店家圖片"></asp:Label>
            <input id="File1" type="file" runat="server" accept="image/png,image/jpeg"/><br /><br />
            <asp:Label ID="lb_shopname" runat="server" Text="店家名字"></asp:Label>
            <asp:TextBox ID="tb_shopname" runat="server" Width="183px"></asp:TextBox><br /><br />
            <asp:Label ID="lb_address" runat="server" Text="店家地址"></asp:Label>
            <asp:TextBox ID="tb_address" runat="server" Width="320px"></asp:TextBox><br /><br />
             <asp:Button ID="btn_back" runat="server" Text="返回主頁" OnClick="btn_back_Click" />
            <asp:Button ID="btn_add" runat="server" Text="確定新增" OnClick="btn_add_Click" />
        </div>
    </form>
</body>
</html>
