using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Data.SqlClient;

namespace Asp.Net
{
    public partial class SignupPage : System.Web.UI.Page
    {
        SqlConnection con = new SqlConnection("Data Source=DESKTOP-0T00OD0;Initial Catalog=userdb;Integrated Security=True");
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void Button1_Click1(object sender, EventArgs e)
        {
            string email = TextBox2.Text;
            string mobile = TextBox3.Text;
            Label1.Text = "";
            Label1.Visible = false;
            // string password = TextBox4.Text;

            // Check if email already exists in the database
            if (IsEmailOrMobileRegistered(email,mobile))
            {
                Label1.Text = "Email is already registered.";
                return;
            }

            con.Open();
            SqlCommand cmd = new SqlCommand("insert into userdata (name,email,mobile,password)values(@name,@email,@mobile,@password)", con);
            cmd.Parameters.AddWithValue("@name", TextBox1.Text);
            cmd.Parameters.AddWithValue("@email", TextBox2.Text);
            cmd.Parameters.AddWithValue("@mobile", TextBox3.Text);
            cmd.Parameters.AddWithValue("@password", TextBox4.Text);
            cmd.ExecuteNonQuery();
            con.Close();
            Label1.Text = "Registration Successfully";
            Label1.Visible = true;
            // Response.Redirect("LoginPage.aspx");

        }
        private bool IsEmailOrMobileRegistered(string email, string mobile)
        {
            bool isRegistered = false;

            con.Open();
            SqlCommand cmd = new SqlCommand("SELECT COUNT(*) FROM userdata WHERE email= @Email OR mobile=@Mobile", con);
            cmd.Parameters.AddWithValue("@Email",email);
            cmd.Parameters.AddWithValue("@Mobile",mobile);

            int count = (int)cmd.ExecuteScalar();
            con.Close();

            if (count > 0)
            {
                isRegistered = true;
            }

            return isRegistered;
        }
    }
}