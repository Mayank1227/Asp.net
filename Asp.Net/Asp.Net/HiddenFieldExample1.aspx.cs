using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Asp.Net
{
    public partial class HiddenFieldExample1 : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            hdnfldCurrentDateTime.Value = DateTime.Now.ToString();
            lblCurrentDateTime.Text = hdnfldCurrentDateTime.Value;

        }
    }
}