using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Asp.Net
{
    public partial class CookieExample1 : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                if (Request.Cookies["UserName"] != null && Request.Cookies["Password"] != null)
                {
                    txtUserName.Text = Request.Cookies["UserName"].Value;
                    txtPassword.Attributes["value"] = Request.Cookies["Password"].Value;
                }
            }
        }

        protected void btnLogin_Click(object sender, EventArgs e)
        {
            if(chkRememberMe.Checked)
            {
                Response.Cookies["UserName"].Expires = DateTime.Now.AddDays(30);   //30 day
                Response.Cookies["Password"].Expires = DateTime.Now.AddDays(30);   //30 day
            }
            else
            {
                Response.Cookies["UserName"].Expires = DateTime.Now.AddDays(-1);  //-1 day
                Response.Cookies["Password"].Expires = DateTime.Now.AddDays(-1);   // -1 day
            }
            Response.Cookies["UserName"].Value = txtUserName.Text.Trim();
            Response.Cookies["Password"].Value = txtPassword.Text.Trim();
        }
    }
}