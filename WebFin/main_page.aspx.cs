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
        protected void Page_Load(object sender, EventArgs e)
        {
            sql_query(sql);
        }

        protected void ddl_City_SelectedIndexChanged(object sender, EventArgs e)
        {
            string[] city = new string[] { "全部", "台北市", "新北市" };
            if (ddl_City.SelectedIndex != 0)
            {
                sql = "select City,Area,Type,ShopName,Address,Evaluation from Restaurant where City=N'" + city[ddl_City.SelectedIndex] + "';";
                sql_query(sql);
            }
        }

        void sql_query(string sql)
        {

            try
            {
                o_con.Open();
                //SqlCommand o_com = new SqlCommand("select * from Restaurant", o_con);
                SqlDataAdapter o_data = new SqlDataAdapter(sql, o_con);
                DataSet o_ds = new DataSet();
                o_data.Fill(o_ds, "Restaurant");
                gv_data.DataSource = o_ds;
                gv_data.DataBind();
                o_con.Close();
            }
            catch (Exception er)
            {
                Response.Write("<script>alert('" + er.Message + "');</script>");
            }

        }
    }
}