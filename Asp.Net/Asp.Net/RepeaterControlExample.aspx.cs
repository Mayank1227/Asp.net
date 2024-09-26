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
    public partial class RepeaterControlExample : System.Web.UI.Page
    {
        SqlCommand cmd;
        SqlDataAdapter da;
        DataSet ds;
        SqlConnection con = new SqlConnection("Data Source=DESKTOP-0T00OD0;Initial Catalog=Employeedb;Integrated Security=True");

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                repeaterbind();
            }
        }

        protected void btnSubmit_click(object sender, EventArgs e)
        {
            try
            {
                con.Open();
                cmd = new SqlCommand("INSERT INTO Comment (UserName, Subject, CommentOn, Post_Date) VALUES (@userName, @subject, @comment, @date)", con);
                cmd.Parameters.AddWithValue("@userName", txtName.Text);
                cmd.Parameters.AddWithValue("@subject", txtSubject.Text);
                cmd.Parameters.AddWithValue("@comment", txtComment.Text);
                cmd.Parameters.AddWithValue("@date", DateTime.Now.ToString());
                cmd.ExecuteNonQuery();
                con.Close();
                txtName.Text = string.Empty; //"";
                txtSubject.Text = string.Empty;
                txtComment.Text = string.Empty;
                repeaterbind();
            }
            catch (Exception ex)
            {
                txtComment.Text = ex.Message;
            }
        }

        void repeaterbind()
        {
            con.Open();
            cmd = new SqlCommand("select * from Comment order by Post_Date desc", con);
            DataSet ds = new DataSet();
            da = new SqlDataAdapter(cmd);
            da.Fill(ds);

            RepterDetails.DataSource = ds;
            RepterDetails.DataBind();
        }
    }
 } 
