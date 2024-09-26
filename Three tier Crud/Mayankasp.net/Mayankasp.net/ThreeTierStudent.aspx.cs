using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

using Mayankasp.net.App_Code.Bal;
using Mayankasp.net.App_Code.Dal;
using System.Data.SqlClient;
using System.Data;

namespace Mayankasp.net
{
    public partial class ThreeTierStudent : System.Web.UI.Page
    {
        BL_Student objbl = new BL_Student();
        DL_Student objdl = new DL_Student();
        protected void Page_Load(object sender, EventArgs e)
        {
            if(!IsPostBack)
            {
                gridbinding();
            }

        }
        protected void Button1_Click(object sender, EventArgs e)
        {
            objbl.firstname = TextBox1.Text;
            objbl.lastname = TextBox2.Text;
            objbl.emailid = TextBox3.Text;
            objbl.password = TextBox4.Text;
            objbl.age = Convert.ToInt32(TextBox5.Text);


            objdl.insert(objbl);

            Label1.Text = "Record inserted successfully";
            gridbinding();

            TextBox1.Text = "";
            TextBox2.Text = "";
            TextBox3.Text = "";
            TextBox4.Text = "";
            TextBox5.Text = "";
        }

        void gridbinding()
        {
            DataSet ds = new DataSet();
            ds = objdl.select();

            GridView1.DataSource = ds;
            GridView1.DataBind();
        }

        protected void GridView1_RowDeleting(object sender, GridViewDeleteEventArgs e)
        {
            int id;
            id = Convert.ToInt32(GridView1.DataKeys[e.RowIndex].Value);
            objbl.id = id;
            objdl.delete(objbl); //delete function called

            gridbinding();
        }
        protected void GridView1_RowCancelingEdit(object sender, GridViewCancelEditEventArgs e)
        {
            GridView1.EditIndex = -1;
            gridbinding();

        }

        protected void GridView1_RowEditing(object sender, GridViewEditEventArgs e)
        {
            GridView1.EditIndex = e.NewEditIndex;
            gridbinding();

        }

        protected void GridView1_RowUpdating(object sender, GridViewUpdateEventArgs e)
        {
            string FName;
            string LName;
            string Email;

            string Password;
            int id1;
            id1 = Convert.ToInt32(GridView1.DataKeys[e.RowIndex].Value);

            FName = ((TextBox)(GridView1.Rows[e.RowIndex].FindControl("txtfname"))).Text.Trim();
            LName = ((TextBox)(GridView1.Rows[e.RowIndex].FindControl("txtlname"))).Text.Trim();
            Email = ((TextBox)(GridView1.Rows[e.RowIndex].FindControl("txtemail"))).Text.Trim();

            Password = ((TextBox)(GridView1.Rows[e.RowIndex].FindControl("txtpassword"))).Text.Trim();
            objbl.firstname = FName;
            objbl.lastname = LName;
            objbl.emailid = Email;
            objbl.password = Password;
            objbl.id = id1;
            objdl.update(objbl);
            GridView1.EditIndex = -1;

          gridbinding();

        }
    }
}