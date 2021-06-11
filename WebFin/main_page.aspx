<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="main_page.aspx.cs" Inherits="WebFin.main_page" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
<meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
        <div>
            <asp:Label ID="lb_Msg" runat="server" Text="篩選：  "></asp:Label>
            <asp:Label ID="lb_SelCity" runat="server" Text="縣市(City)"></asp:Label>
            <asp:DropDownList ID="ddl_City" runat="server" OnSelectedIndexChanged="ddl_City_SelectedIndexChanged" AutoPostBack="True">
                <asp:ListItem>全部</asp:ListItem>
                <asp:ListItem>台北市</asp:ListItem>
                <asp:ListItem>新北市</asp:ListItem>
            </asp:DropDownList>
        </div>
        <div>
            <asp:GridView ID="gv_data" runat="server"></asp:GridView>
        </div>
    </form>
</body>
</html>
