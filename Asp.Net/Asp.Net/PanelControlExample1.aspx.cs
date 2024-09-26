using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Asp.Net
{
    public partial class PanelControlExample1 : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            Panel1.Visible = false;
            Panel2.Visible = false;
            Panel3.Visible = false;
            Panel4.Visible = false;
        }

        protected void RadioButtonList1_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (RadioButtonList1.SelectedIndex == 0)
            {
                Panel1.Visible = true;
            }
            if (RadioButtonList1.SelectedIndex == 1)
            {
                Panel2.Visible = true;
            }
            if (RadioButtonList1.SelectedIndex == 2)
            {
                Panel3.Visible = true;
            }
            if (RadioButtonList1.SelectedIndex == 3)
            {
                Panel4.Visible = true;
            }
        }
    }
}