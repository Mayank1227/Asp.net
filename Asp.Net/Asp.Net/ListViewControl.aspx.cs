using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Asp.Net
{
    public partial class ListViewControl : System.Web.UI.Page
    {
        SqlConnection con = new SqlConnection("Data Source=DESKTOP-0T00OD0;Initial Catalog=Employeedb;Integrated Security=True");

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack) // Always a good practice to avoid re-binding on postbacks
            {
                SqlDataAdapter da = new SqlDataAdapter("select * from Comments2", con);
                DataSet ds = new DataSet();
                da.Fill(ds, "FillComent");
                ListView1.DataSource = ds.Tables["FillComent"]; // Fixed space here
                ListView1.DataBind();
            }
        }
    }
}