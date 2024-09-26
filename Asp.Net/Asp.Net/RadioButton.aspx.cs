using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Asp.Net
{
    public partial class RadioButton : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void RadioButton1_CheckedChanged(object sender, EventArgs e)
        {

        }

        protected void RadioButton1_CheckedChanged1(object sender, EventArgs e)
        {

        }

        protected void RadioButton1_CheckedChanged2(object sender, EventArgs e)
        {

        }

        protected void Button1_Click(object sender, EventArgs e)
        {
            if (rdMale.Checked == true)
            {
                Label1.Text = rdMale.Text;
            }
            else     //Html ma cod chench karvo     ID="rdMale" runat="server" Text="Male" GroupName="g"
            {
                Label1.Text = rdFemale.Text;
            }
        }

        protected void RadioButton2_CheckedChanged(object sender, EventArgs e)
        {
        }
    }
}