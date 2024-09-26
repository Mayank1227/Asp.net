using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Asp.Net
{
    public partial class WizardControlExampal : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void Wizard1_FinishButtonClick(object sender, WizardNavigationEventArgs e)
        {
            if (e.NextStepIndex == 3)
            {
                Label1.Text = TextBox1.Text;
                Label2.Text = TextBox2.Text;
                Label3.Text = TextBox3.Text;
                Label4.Text = TextBox4.Text;
                Label5.Text = TextBox5.Text;
                Label6.Text = TextBox6.Text;
                Label7.Text = TextBox7.Text;
            }
        }
    }
}