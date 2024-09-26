using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Mayankasp.net
{
    public partial class Home : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["Emailid"] != null)
            {
                Label1.Text = Session["Emailid"].ToString();
            }
            else
            {

                Response.Redirect("Login page.aspx");
            }
        }
        protected void Button1_Click(object sender, EventArgs e)
        {
            Session.Clear();
            Response.Redirect("Login Page.aspx");
        }
    }
}
    

      
