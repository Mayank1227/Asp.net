using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

using System.Data;
using System.Data.SqlClient;
using Mayankasp.net.App_Code.Bal;
using Mayankasp.net.App_Code.Dal;

namespace Mayankasp.net
{
    public partial class Login_page : System.Web.UI.Page
    {
        BL_Student objbl = new BL_Student();
        DL_Student objdl = new DL_Student();

        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void Button1_Click(object sender, EventArgs e)
        {
            objbl.emailid = TextBox1.Text;
            objbl.password = TextBox2.Text;

            Session["Emailid"] = TextBox1.Text;
            SqlDataReader dr;
            dr = objdl.login(objbl);
            if (dr.Read())
            {
                Response.Redirect("Home.aspx");
            }
            else
            {
                Response.Write("<script>alert('login failed')</script>");
            }
        }
    }
}