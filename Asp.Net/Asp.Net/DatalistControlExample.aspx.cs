using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.Configuration;
using System.Web.UI;
using System.Web.UI.WebControls;


namespace Asp.Net
{
    public partial class DatalistControlExample : System.Web.UI.Page
    {
        SqlConnection con = new SqlConnection(WebConfigurationManager.ConnectionStrings["EmployeedbConnectionString"].ConnectionString);
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                Bind();
            }
        }
        public void Bind()
        {
            SqlCommand cmd = new SqlCommand("select * from Employee2", con);
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            DataSet ds = new DataSet();
            da.Fill(ds, "Employee2");
            dl1.DataSource = ds.Tables[0];
            dl1.DataBind();
        }
        protected void dl1_EditCommand(object sender, DataListCommandEventArgs e)
        {
            dl1.EditItemIndex = e.Item.ItemIndex;
            Bind();
        }
        protected void dl1_CancelCommand(object sender, DataListCommandEventArgs e)
        {
            dl1.EditItemIndex = -1;
            Bind();
        }
        protected void dl1_updateCommand(object sender, DataListCommandEventArgs e)
        {
            int index = e.Item.ItemIndex;
            int empid = Convert.ToInt32(((TextBox)dl1.Items[index].FindControl("txtempid")).Text);
            string empname = ((TextBox)dl1.Items[index].FindControl("txtempname")).Text;
            string empmail = ((TextBox)dl1.Items[index].FindControl("txtempmail")).Text;
            long empmbnum = Convert.ToInt64(((TextBox)dl1.Items[index].FindControl("txtmbnum")).Text);
            FileUpload fu = (FileUpload)dl1.Items[index].FindControl("fu1");
            // to update image name in data base and image in server, If he selectted new Image  
            if (fu.HasFile)
            {
                string filepath = System.IO.Path.Combine(Server.MapPath("~/Images/"), fu.FileName);
                fu.SaveAs(filepath);
                SqlCommand fcmd = new SqlCommand();
                //     fcmd.CommandText = "update employee set EmpImage='" + fu.FileName + "'";

                fcmd.CommandText = "update Employee2 set EmpImage='" + fu.FileName + "' where EmpId = '" + empid + "'";
                fcmd.Connection = con;
                con.Open();
                fcmd.ExecuteNonQuery();
                con.Close();
            }
            SqlCommand cmd = new SqlCommand("update Employee2 set EmpName = '" + empname + "',EmpEmailId='" + empmail + "',EmpMobileNumber =" + empmbnum + " where EmpId = " + empid + "", con);
            con.Open();
            int i = cmd.ExecuteNonQuery();
            con.Close();
            if (i == 1)
            {
                Response.Write("<script>alert('Successfully updated')</script>");
                dl1.EditItemIndex = -1;
                Bind();
            }
        }
        protected void dl1_DeleteCommand(object sender, DataListCommandEventArgs e)
        {
            int index = e.Item.ItemIndex;
            Label empid;
            empid = (Label)dl1.Items[index].FindControl("lblempid");

            SqlCommand cmd = new SqlCommand("delete from Employee2 where EmpId = " + Convert.ToInt32(empid.Text) + "", con);
            con.Open();
            int res = cmd.ExecuteNonQuery();
            con.Close();
            if (res == 1)
            {
                Response.Write("<script>alert('Successfully deleted')</script>");
                Bind();
            }
        }
    }
}
