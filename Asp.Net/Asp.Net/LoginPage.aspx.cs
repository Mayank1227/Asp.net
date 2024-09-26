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
    public partial class LoginPage : System.Web.UI.Page
    {
        SqlConnection con = new SqlConnection("Data Source=DESKTOP-0T00OD0;Initial Catalog=userdb;Integrated Security=True");
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void Button1_Click(object sender, EventArgs e)
        { 
           string email = TextBox1.Text.Trim();
           string password = TextBox2.Text.Trim();

           // Clear previous error messages
            lblEmailError.Text = "";
            lblPasswordError.Text = "";
            lblEmailError.Visible = false;
            lblPasswordError.Visible = false;

        con.Open();
        // Check if the email exists in the database
        SqlCommand checkEmailCmd = new SqlCommand("select * from userdata where email=@Email", con);
        checkEmailCmd.Parameters.AddWithValue("@Email", email);
        SqlDataReader dr = checkEmailCmd.ExecuteReader();

        if (!dr.HasRows) // Email not registered
        {
            lblEmailError.Text = "Email is not registered!";
            lblEmailError.Visible = true;
        }
        else
        {
            dr.Close(); // Close previous DataReader

            // Check if the email and password match
            SqlCommand cmd = new SqlCommand("select * from userdata where email=@Email and password=@Password", con);
            cmd.Parameters.AddWithValue("@Email", email);
            cmd.Parameters.AddWithValue("@Password", password);
            SqlDataReader loginReader = cmd.ExecuteReader();

            if (loginReader.Read())
            {
                // Login successful
                Session["email"] = email;
                Response.Redirect("Home.aspx");
            }
            else
            {
                // Email exists but password is incorrect
                lblPasswordError.Text = "Invalid password!";
                lblPasswordError.Visible = true;
            }
        }

        con.Close();

        // Clear the input fields
        TextBox1.Text = "";
        TextBox2.Text = "";


            

        }
    }
 }
