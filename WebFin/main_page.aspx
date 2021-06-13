<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="main_page.aspx.cs" Inherits="WebFin.main_page" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
<meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
        <div id="main" runat="server">
        <div >
            <asp:LinkButton ID="lkbtn_user" runat="server">LinkButton</asp:LinkButton>
            <asp:Button ID="btn_addItem" runat="server" Text="新增店家" OnClick="btn_addItem_Click" />
            <asp:Button ID="btn_logout" runat="server" Text="登出" OnClick="btn_logout_Click" />
        </div>
        <div>
            <asp:Label ID="lb_Msg" runat="server" Text="篩選：  "></asp:Label>
            <asp:Label ID="lb_SelCity" runat="server" Text="縣市(City)"></asp:Label>
            <asp:DropDownList ID="ddl_City" runat="server" Font-Size="Large" OnSelectedIndexChanged="ddl_City_SelectedIndexChanged" AutoPostBack="True">
                <asp:ListItem>全部</asp:ListItem>
                <asp:ListItem>台北市</asp:ListItem>
                <asp:ListItem>新北市</asp:ListItem>
            </asp:DropDownList>

            <asp:Label ID="lb_Atea" runat="server" Text="地區"></asp:Label>
            <asp:DropDownList ID="ddl_Area" runat="server" Font-Size="Large" AutoPostBack="True" OnSelectedIndexChanged="ddl_Area_SelectedIndexChanged">
                <asp:ListItem>全部</asp:ListItem>
            </asp:DropDownList>
            <asp:Label ID="lb_type" runat="server" Text="種類"></asp:Label>
            <asp:DropDownList ID="ddl_type" runat="server" Font-Size="Large" OnSelectedIndexChanged="ddl_type_SelectedIndexChanged" AutoPostBack="True">
                <asp:ListItem>全部</asp:ListItem>
                <asp:ListItem>火鍋</asp:ListItem>
                <asp:ListItem>牛排</asp:ListItem>
                <asp:ListItem>燒烤</asp:ListItem>
                <asp:ListItem>小吃</asp:ListItem>
                <asp:ListItem>自助餐</asp:ListItem>
                <asp:ListItem>中式快餐</asp:ListItem>
                <asp:ListItem>中式餐廳</asp:ListItem>
                <asp:ListItem>日式料理</asp:ListItem>
                <asp:ListItem>韓式料理</asp:ListItem>
                <asp:ListItem>休閒飲料</asp:ListItem>
                <asp:ListItem>早餐專賣</asp:ListItem>
                <asp:ListItem>西式速食</asp:ListItem>
                <asp:ListItem>西式餐廳</asp:ListItem>
                <asp:ListItem>咖啡簡餐</asp:ListItem>
                <asp:ListItem>甜點冰品</asp:ListItem>
            </asp:DropDownList>
        </div>
        <div >
            <asp:GridView ID="gv_data" runat="server" BackColor="White" BorderColor="#336666" BorderStyle="Double" BorderWidth="3px" CellPadding="4" GridLines="Horizontal">
                <Columns>
                    <asp:ButtonField ButtonType="Button" CommandName="sel" Text="詳細資訊" />
                </Columns>
                <FooterStyle BackColor="White" ForeColor="#333333" />
                <HeaderStyle BackColor="#336666" Font-Bold="True" ForeColor="White" />
                <PagerStyle BackColor="#336666" ForeColor="White" HorizontalAlign="Center" />
                <RowStyle BackColor="White" ForeColor="#333333" />
                <SelectedRowStyle BackColor="#339966" Font-Bold="True" ForeColor="White" />
                <SortedAscendingCellStyle BackColor="#F7F7F7" />
                <SortedAscendingHeaderStyle BackColor="#487575" />
                <SortedDescendingCellStyle BackColor="#E5E5E5" />
                <SortedDescendingHeaderStyle BackColor="#275353" />
            </asp:GridView>
            <br />
            <asp:Label ID="lb_Nodata" runat="server" Text="此地區尚無任何店家資料" Visible="False"></asp:Label>
        </div>
        </div>
    </form>
</body>
</html>
