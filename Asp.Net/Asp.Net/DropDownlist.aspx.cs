using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Asp.Net
{
    public partial class DropDownlist : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                DropDownList1.Items.Add("India");
                DropDownList1.Items.Add("USA");
                DropDownList1.Items.Add("UK");
                DropDownList1.Items.Add("Gujrat");
                DropDownList1.Items.Add("Rajstan");
                DropDownList1.Items.Add("Mharast");

            }
        }

        protected void DropDownList1_SelectedIndexChanged(object sender, EventArgs e)
        {
            DropDownList2.Items.Clear();

            if (DropDownList1.SelectedItem.Text == "India")
            {
                DropDownList2.Items.Add("UP");
                DropDownList2.Items.Add("Gujarat");
            }
            else if (DropDownList1.SelectedItem.Text == "USA")
            {
                DropDownList2.Items.Add("California");
                DropDownList2.Items.Add("Washington");
            }
            else if (DropDownList1.SelectedItem.Text=="Uk")
            {
                DropDownList2.Items.Add("London");
                DropDownList2.Items.Add("Leistor");
            }
            else if (DropDownList1.SelectedItem.Text == "Gujrat")
            {
                DropDownList2.Items.Add("Palanpur");
                DropDownList2.Items.Add("RAjkot");
                DropDownList2.Items.Add("Baroda");
            }
            else if (DropDownList1.SelectedItem.Text == "Rajsthan")
            {
                DropDownList2.Items.Add("London");
                DropDownList2.Items.Add("Leistor");
            }
            else
            {
                DropDownList2.Items.Add("Mumbai");
                DropDownList2.Items.Add("PUne");
            }
        }
    }
}