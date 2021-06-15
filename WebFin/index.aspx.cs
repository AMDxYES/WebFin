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
    public partial class index : System.Web.UI.Page
    {
        SqlConnection o_con = new SqlConnection(ConfigurationManager.ConnectionStrings["myCon"].ConnectionString);
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void btn_login_Click(object sender, EventArgs e)
        {
            string msg = "",mail="";
            bool login = false;
            o_con.Open();
            SqlCommand o_com = new SqlCommand("select * from Users", o_con);
            SqlDataReader o_data = o_com.ExecuteReader();
            if (tb_accounts.Text != "" & tb_password.Text != "")
            {
                for (; o_data.Read();)
                {
                    Response.Write(o_data[0]);
                    Response.Write(o_data[1]);
                    if (o_data[0].ToString() == tb_accounts.Text)
                    {
                        if (o_data[1].ToString() == tb_password.Text)
                        {
                            mail = o_data[0].ToString();
                            login = true;
                            break;
                        }
                        else
                        {
                            msg = "登入失敗，密碼不正確";
                        }
                    }
                    else
                    {
                        msg = "登入失敗，無此帳號，請點「我還沒有帳號」來創建一個帳號";
                    }
                }
            }
            else
            {
                msg = "欄位不可為空";
            }
            o_con.Close();
            if (login)
            {
                msg = "main_page.aspx?mail="+mail;
                Response.Redirect(msg);
            }
            else
            {
                Response.Write("<script>alert('" + msg + "');</script>");
            }
        }
    }
}