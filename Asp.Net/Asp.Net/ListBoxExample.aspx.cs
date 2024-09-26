using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Asp.Net
{
    public partial class ListBoxExample : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                ListBox1.Items.Add("MCA");
                ListBox1.Items.Add("BCom");
                ListBox1.Items.Add("BCA");
                ListBox1.Items.Add("BBA");
                ListBox1.Items.Add("BA");

            }
        }

        protected void Button1_Click(object sender, EventArgs e)
        {
            ListBox2.Items.Add(ListBox1.SelectedItem.Text);
           // ListBox1.Items.Remove(ListBox1.SelectedItem);
        }
    }
}