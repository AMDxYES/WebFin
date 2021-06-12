using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Data.SqlClient;
using System.Configuration;

namespace WebFin
{
    public partial class main_page : System.Web.UI.Page
    {
        SqlConnection o_con = new SqlConnection(ConfigurationManager.ConnectionStrings["myCon"].ConnectionString);
        string sql = "select City,Area,Type,ShopName,Address,Evaluation from Restaurant;";

        string[] area1 = new string[] { "全部","中正", "大同", "中山", "松山", "大安", "萬華", "信義", "士林", "北投",
                                        "內湖", "南港", "文山", };
        string[] area2 = new string[] { "全部","萬里","金山", "板橋", "汐止", "深坑", "石碇", "瑞芳", "平溪", "雙溪",
                                        "貢寮", "新店", "坪林", "烏來", "永和", "中和", "土城", "三峽", "樹林",
                                        "鶯歌", "三重", "新莊", "泰山", "林口", "蘆洲", "五股", "八里", "淡水",
                                        "三芝", "石門" };
        string[] city = new string[] { "全部", "台北市", "新北市" };

        protected void Page_Load(object sender, EventArgs e)
        {
            sql_query(sql);
        }

        protected void ddl_City_SelectedIndexChanged(object sender, EventArgs e)
        {
            ddl_Area.Items.Clear();
            if (ddl_City.SelectedIndex == 1)
            {
                foreach (string i in area1)
                {
                    ddl_Area.Items.Add(i);
                }
            }
            else if (ddl_City.SelectedIndex == 2)
            {
                foreach (string i in area2)
                {
                    ddl_Area.Items.Add(i);
                }
            }
            else
            {
                ddl_Area.Items.Add("全部");
            }

            if (ddl_City.SelectedIndex != 0)
            {

                sql = "select Id,City,Area,Type,ShopName,Address,Evaluation from Restaurant where City=N'" + city[ddl_City.SelectedIndex] + "';";
            }
            sql_query(sql);

        }

        void sql_query(string sql)
        {
            lb_Nodata.Visible = false;
            try
            {
                o_con.Open();
                SqlDataAdapter o_data = new SqlDataAdapter(sql, o_con);
                DataSet o_ds = new DataSet();
                int data_count = o_data.Fill(o_ds, "Restaurant");
                gv_data.DataSource = o_ds;
                gv_data.DataBind();
                gv_data.AutoGenerateSelectButton = true;
                o_con.Close();
                if (data_count == 0)
                {
                    lb_Nodata.Visible = true;
                }
            }
            catch (Exception er)
            {
                Response.Write("<script>alert('" + er.Message + "');</script>");
            }


        }

        protected void ddl_Area_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (ddl_Area.SelectedIndex != 0)
            {
                if (ddl_City.SelectedIndex == 1)
                {
                    sql = "select Id,City,Area,Type,ShopName,Address,Evaluation from Restaurant where City=N'" + city[ddl_City.SelectedIndex] + "' and Area=N'" + area1[ddl_Area.SelectedIndex] + "區';";
                }
                else
                {
                    sql = "select Id,City,Area,Type,ShopName,Address,Evaluation from Restaurant where City=N'" + city[ddl_City.SelectedIndex] + "' and Area=N'" + area2[ddl_Area.SelectedIndex] + "區';";
                }
            }
            else
            {
                sql = "select Id,City,Area,Type,ShopName,Address,Evaluation from Restaurant where City=N'" + city[ddl_City.SelectedIndex] + "';";
            }
            sql_query(sql);
        }

        protected void gv_data_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            if (e.CommandName == "sel")
            {

            }
        }
    }
}