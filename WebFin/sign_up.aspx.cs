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
    public partial class sign_up : System.Web.UI.Page
    {
        SqlConnection o_con = new SqlConnection(ConfigurationManager.ConnectionStrings["myCon"].ConnectionString);
        protected void Page_Load(object sender, EventArgs e)
        {
            UnobtrusiveValidationMode = UnobtrusiveValidationMode.None;
        }

        protected void btn_signup_Click(object sender, EventArgs e)
        {
            if (rev_mail.IsValid == true & cv_password.IsValid == true & rev_phone.IsValid == true & rev_password.IsValid == true)
            {
                if (tb_mail.Text != "" & tb_password.Text != "" & tb_name.Text != "" & tb_phone.Text != "" & tb_checkpassword.Text != "")
                {
                    try
                    {
                        Response.Write("dsa");
                        o_con.Open();
                        SqlCommand o_com = new SqlCommand("insert into Users values(@email,@password,@name,@phone)", o_con);
                        o_com.Parameters.Add("@email", SqlDbType.NVarChar);
                        o_com.Parameters["@email"].Value = tb_mail.Text;
                        o_com.Parameters.Add("@password", SqlDbType.NVarChar);
                        o_com.Parameters["@password"].Value = tb_password.Text;
                        o_com.Parameters.Add("@name", SqlDbType.NVarChar);
                        o_com.Parameters["@name"].Value = tb_name.Text;
                        o_com.Parameters.Add("@phone", SqlDbType.NVarChar);
                        o_com.Parameters["@phone"].Value = tb_phone.Text;
                        o_com.ExecuteNonQuery();
                        o_con.Close();
                        Response.Write("<script>alert('帳號創建成功!');location.href='./index.aspx';</script>");
                    }
                    catch (Exception er)
                    {

                        if (er.Message.Contains("Violation of PRIMARY KEY constraint"))
                        {
                            Response.Write("<script>alert('此帳號已被使用!');</script>");
                        }
                    }
                }
                else
                {
                    Response.Write("<script>alert('欄位不可為空');</script>");

                }
            }
        }
    }
}