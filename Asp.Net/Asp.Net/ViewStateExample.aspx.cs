using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Asp.Net
{
    public partial class ViewStateExample : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (IsPostBack)
            {
                if (ViewState["counter"] != null)
                {
                    int val = Convert.ToInt32(ViewState["counter"]) + 1;
                    MyLabel.Text = val.ToString();
                    ViewState["counter"] = val.ToString();
                }
                else
                {
                    ViewState["counter"] = "1";
                }
            }
        }
        protected void Button1_Click(object sender, EventArgs e)
        {
            ViewState["data"] = TextBox1.Text;
            TextBox1.Text = "";
        }

        protected void Button2_Click(object sender, EventArgs e)
        {
            TextBox2.Text = ViewState["data"].ToString();
        }
   
        protected void Button3_Click(object sender, EventArgs e)
        {
            MyLabel.Text = ViewState["counter"].ToString();
        }
    }
}