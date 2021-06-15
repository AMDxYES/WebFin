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
        string sql = "select Id,City,Area,Type,ShopName,Address,Evaluation from Restaurant;";

        string[] area1 = new string[] { "全部","中正", "大同", "中山", "松山", "大安", "萬華", "信義", "士林", "北投",
                                        "內湖", "南港", "文山", };
        string[] area2 = new string[] { "全部","萬里","金山", "板橋", "汐止", "深坑", "石碇", "瑞芳", "平溪", "雙溪",
                                        "貢寮", "新店", "坪林", "烏來", "永和", "中和", "土城", "三峽", "樹林",
                                        "鶯歌", "三重", "新莊", "泰山", "林口", "蘆洲", "五股", "八里", "淡水",
                                        "三芝", "石門" };
        string[] type = new string[] { "全部","火鍋","牛排", "燒烤", "小吃", "自助餐", "中式快餐", "中式餐廳", "日式料理","韓式料理", "休閒飲料",
                                       "早餐專賣", "西式速食", "西式餐廳", "咖啡簡餐", "甜點冰品" };
        string[] city = new string[] { "全部", "台北市", "新北市" };
        string user;
        int shop_id,evaluation_sum,evaluation_count;
        int evaluation_new_sum, evaluation_new_count, evaluation_avg;
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Request.QueryString["mail"] != null)
            {
                user = Request.QueryString["mail"];
                o_con.Open();
                SqlCommand o_com = new SqlCommand("select Name from Users where Mail='" + user + "';", o_con);
                SqlDataReader o_data = o_com.ExecuteReader();
                o_data.Read();
                user = o_data.GetString(0);
                o_con.Close();
                lkbtn_user.Text = "使用者名稱:" + user;
            }
            else if(Request.QueryString["name"]!=null) 
            {
                user = Request.QueryString["name"];
                lkbtn_user.Text = "使用者名稱: " + user;
            }
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

            selddl();

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
            selddl();
        }

        protected void btn_addItem_Click(object sender, EventArgs e)
        {
            Response.Redirect("./addItem.aspx?name=" + user);
        }

        protected void btn_logout_Click(object sender, EventArgs e)
        {
            Response.Redirect("./index.aspx");
        }

        protected void ddl_type_SelectedIndexChanged(object sender, EventArgs e)
        {
            selddl();
        }

        void selddl()
        {
            if (ddl_City.SelectedIndex != 0)
            {
                if (ddl_Area.SelectedIndex != 0)
                {
                    if (ddl_type.SelectedIndex != 0)
                    {
                        if (ddl_City.SelectedIndex == 1)
                        {
                            sql = "select Id,City,Area,Type,ShopName,Address,Evaluation from Restaurant where City=N'" + city[ddl_City.SelectedIndex] + "' and Area=N'" + area1[ddl_Area.SelectedIndex] + "區' and Type=N'" + type[ddl_type.SelectedIndex] + "' ;";
                        }
                        else
                        {
                            sql = "select Id,City,Area,Type,ShopName,Address,Evaluation from Restaurant where City=N'" + city[ddl_City.SelectedIndex] + "' and Area=N'" + area1[ddl_Area.SelectedIndex] + "區' and Type=N'" + type[ddl_type.SelectedIndex] + "' ;";
                        }

                    }
                    else
                    {

                        if (ddl_City.SelectedIndex == 1)
                        {
                            sql = "select Id,City,Area,Type,ShopName,Address,Evaluation from Restaurant where City=N'" + city[ddl_City.SelectedIndex] + "' and Area=N'" + area1[ddl_Area.SelectedIndex] + "區';";
                        }
                        else
                        {
                            sql = "select Id,City,Area,Type,ShopName,Address,Evaluation from Restaurant where City=N'" + city[ddl_City.SelectedIndex] + "' and Area=N'" + area1[ddl_Area.SelectedIndex] + "區';";
                        }
                    }

                }
                else
                {
                    if (ddl_type.SelectedIndex != 0)
                    {
                        sql = "select Id,City,Area,Type,ShopName,Address,Evaluation from Restaurant where City=N'" + city[ddl_City.SelectedIndex] + "' and Type=N'" + type[ddl_type.SelectedIndex] + "' ;";
                    }
                    else
                    {
                        sql = "select Id,City,Area,Type,ShopName,Address,Evaluation from Restaurant where City=N'" + city[ddl_City.SelectedIndex] + "';";
                    }

                }

            }
            else
            {
                if (ddl_type.SelectedIndex != 0)
                {
                    sql = "select Id,City,Area,Type,ShopName,Address,Evaluation from Restaurant where Type=N'" + type[ddl_type.SelectedIndex] + "';";
                }
                else
                {
                    sql = "select Id,City,Area,Type,ShopName,Address,Evaluation from Restaurant;";
                }
            }
            sql_query(sql);
        }

        protected void btn_backmain_Click(object sender, EventArgs e)
        {
            main.Visible = true;
            second_page.Visible = false;
            btn_eva.Enabled = true;
            btn_eva.Text = "送出評價";
        }

        protected void gv_data_RowCommand1(object sender, GridViewCommandEventArgs e)
        {
            if (e.CommandName == "sel")
            {
                try
                {
                    main.Visible = false;
                    second_page.Visible = true;
                    int id = Convert.ToInt32(e.CommandArgument);
                    o_con.Open();
                    SqlCommand o_com = new SqlCommand("select * from Restaurant where Id='" + gv_data.Rows[id].Cells[2].Text + "';", o_con);
                    SqlDataReader o_data = o_com.ExecuteReader();
                    shop_id=Convert.ToInt32( gv_data.Rows[id].Cells[2].Text);
                    o_data.Read();
                    string img = o_data[4].ToString();
                    evaluation_count = Convert.ToInt32(o_data[8].ToString());
                    evaluation_sum = Convert.ToInt32(o_data[9].ToString());
                    o_con.Close();
                    img_show.ImageUrl = "Resources\\" + img;
                    lb_name.Text = "店名：" + gv_data.Rows[id].Cells[6].Text;
                    lb_type2.Text = "類別：" + gv_data.Rows[id].Cells[5].Text;
                    lb_address.Text = "地址：" + gv_data.Rows[id].Cells[7].Text;
                    ViewState["id"] = shop_id;
                    ViewState["sum"] = evaluation_sum;
                    ViewState["count"] = evaluation_count;
                    if (gv_data.Rows[id].Cells[8].Text == "0")
                    {
                        lb_evaluation.Text = "評價：暫無評價";
                    }
                    else
                    {
                        lb_evaluation.Text = "評價：" + gv_data.Rows[id].Cells[8].Text;
                    }
                    
                }
                catch(Exception er)
                {
                    Response.Write("錯誤:" + er.ToString());
                }
                
            }
        }

        protected void btn_eva_Click(object sender, EventArgs e)
        {
            shop_id =Convert.ToInt32( ViewState["id"]);
            evaluation_sum = Convert.ToInt32(ViewState["sum"]);
            evaluation_count = Convert.ToInt32(ViewState["count"]);
            evaluation_new_sum = int.Parse(rbl_eva.SelectedValue) + evaluation_sum;
            evaluation_new_count = evaluation_count + 1;
            evaluation_avg = Convert.ToInt32(evaluation_new_sum / evaluation_new_count);
            try
            {
                o_con.Open();
                SqlCommand o_com = new SqlCommand("update Restaurant set EvaluationSum=" + evaluation_new_sum + " , EvaluationCount=" + evaluation_new_count + " , Evaluation=" + evaluation_avg + " where Id=" + shop_id + " ;", o_con);
                int result = o_com.ExecuteNonQuery();
                if (result > 0)
                {
                    btn_eva.Text = "評價成功！";
                    btn_eva.Enabled = false;
                }
                o_con.Close();
            }
            catch(Exception er)
            {
                Response.Write("錯誤:" + er.Message);
            }
           
        }
    }
}