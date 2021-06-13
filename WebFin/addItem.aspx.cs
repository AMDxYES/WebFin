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
    public partial class addItem : System.Web.UI.Page
    {
        SqlConnection o_con = new SqlConnection(ConfigurationManager.ConnectionStrings["myCon"].ConnectionString);
        string[] area1 = new string[] { "中正", "大同", "中山", "松山", "大安", "萬華", "信義", "士林", "北投",
                                        "內湖", "南港", "文山", };
        string[] area2 = new string[] { "萬里","金山", "板橋", "汐止", "深坑", "石碇", "瑞芳", "平溪", "雙溪",
                                        "貢寮", "新店", "坪林", "烏來", "永和", "中和", "土城", "三峽", "樹林",
                                        "鶯歌", "三重", "新莊", "泰山", "林口", "蘆洲", "五股", "八里", "淡水",
                                        "三芝", "石門" };
        string[] type = new string[] { "火鍋","牛排", "燒烤", "小吃", "自助餐", "中式快餐", "中式餐廳", "日式料理","韓式料理", "休閒飲料",
                                       "早餐專賣", "西式速食", "西式餐廳", "咖啡簡餐", "甜點冰品" };
        string name;
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Request.QueryString["name"] != null)
            {
                name = Request.QueryString["name"];
            }
            foreach (string i in type)
            {
                ddl_type.Items.Add(i);
            }
        }

        protected void btn_add_Click(object sender, EventArgs e)
        {
            string img = "";
            if (ddl_City.SelectedIndex != 0 && ddl_Area.SelectedIndex != 0 && ddl_type.SelectedIndex != 0)
            {
                if (tb_shopname.Text != "" && tb_address.Text != "")
                {
                    if (File1.PostedFile.FileName != "")
                    {
                        img = File1.PostedFile.FileName;
                        File1.PostedFile.SaveAs("E:\\program\\WebFin\\WebFin\\Resources\\" + img);
                    }
                    else
                    {
                        img = "default.png";
                    }
                    o_con.Open();
                    SqlCommand o_com = new SqlCommand("select count(Id) from Restaurant", o_con);
                    int count = Convert.ToInt32(o_com.ExecuteScalar());
                    o_con.Close();
                    o_con.Open();
                    o_com.CommandText = "insert into Restaurant values (@Id,@City,@Area,@Type,@Img,@Name,@Address,0,0);";
                    o_com.Parameters.Add("@Id", SqlDbType.Int);
                    o_com.Parameters["@Id"].Value = count + 1;
                    o_com.Parameters.Add("@City", SqlDbType.NVarChar);
                    o_com.Parameters["@City"].Value = ddl_City.SelectedValue;
                    o_com.Parameters.Add("@Area", SqlDbType.NVarChar);
                    o_com.Parameters["@Area"].Value = ddl_Area.SelectedValue + "區";
                    o_com.Parameters.Add("@Type", SqlDbType.NVarChar);
                    o_com.Parameters["@Type"].Value = ddl_type.SelectedValue;
                    o_com.Parameters.Add("@Img", SqlDbType.NVarChar);
                    o_com.Parameters["@Img"].Value = img;
                    o_com.Parameters.Add("@Name", SqlDbType.NVarChar);
                    o_com.Parameters["@Name"].Value = tb_shopname.Text;
                    o_com.Parameters.Add("@Address", SqlDbType.NVarChar);
                    o_com.Parameters["@Address"].Value = tb_address.Text;
                    o_com.ExecuteNonQuery();
                    o_con.Close();

                    Response.Redirect("main_page.aspx?name=" + name);
                }
                else
                {
                    Response.Write("<script>alert('欄位不可為空');</script>");
                }

            }
            else
            {
                Response.Write("<script>alert('請選擇店家所在地區及類型');</script>");
            }

        }

        protected void ddl_City_SelectedIndexChanged(object sender, EventArgs e)
        {
            ddl_Area.Items.Clear();
            ddl_Area.Items.Add("請選擇");
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
        }
    }
}