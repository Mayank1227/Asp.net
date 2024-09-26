using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Data.SqlClient;
namespace Asp.Net
{
    public partial class TwoTierRegistration1 : System.Web.UI.Page
    {
        SqlConnection con = new SqlConnection("Data Source=DESKTOP-0T00OD0;Initial Catalog=Employeedb;Integrated Security=True");
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                gridbinding();
            }
        }
        protected void RadioButton1_CheckedChanged(object sender, EventArgs e)
        {


        }

        protected void Button1_Click(object sender, EventArgs e)
        {
            con.Open();
            SqlCommand cmd = new SqlCommand("insert into Employee(FirstName,LastName,Gender,Salary,City,MobileNumber,CompanyId,BirthDate,JoiningDate) values(@FirstName,@LastName,@Gender,@Salary,@City,@MobileNumber,@CompanyId,@BirthDate,@JoiningDate)", con);
            cmd.Parameters.AddWithValue("@FirstName", TextBox1.Text);
            cmd.Parameters.AddWithValue("@LastName", TextBox2.Text);
            cmd.Parameters.AddWithValue("@Salary", TextBox3.Text);
            cmd.Parameters.AddWithValue("@City", TextBox4.Text);
            cmd.Parameters.AddWithValue("@MobileNumber", TextBox5.Text);
            cmd.Parameters.AddWithValue("@CompanyId", TextBox6.Text);
            cmd.Parameters.AddWithValue("@BirthDate", TextBox7.Text);
            cmd.Parameters.AddWithValue("@JoiningDate", TextBox8.Text);
            if (rdMale.Checked == true)
            {
                cmd.Parameters.AddWithValue("@Gender", rdMale.Text);
            }
            else
            {
                cmd.Parameters.AddWithValue("@Gender", rdfemale.Text);
            }
            cmd.ExecuteNonQuery();
            con.Close();
            Label1.Text = "Registration successfully";


            // From data clayer.........
            {
                TextBox1.Text = "";
                TextBox2.Text = "";
                TextBox3.Text = "";
                TextBox4.Text = "";
                TextBox5.Text = "";
                TextBox6.Text = "";
                TextBox7.Text = "";
                TextBox8.Text = "";
                rdMale.Checked = false;
                rdfemale.Checked = false;
            }

            gridbinding();
        }

        void gridbinding()
        {
            con.Open();
            SqlCommand cmd = new SqlCommand("select * from Employee", con);
            DataSet ds = new DataSet();

            SqlDataAdapter adpt = new SqlDataAdapter(cmd);

            adpt.Fill(ds);
            GridView1.DataSource = ds;
            GridView1.DataBind();
        }

        protected void GridView1_RowDeleting(object sender, GridViewDeleteEventArgs e)
        {
            int id;
            con.Open();
            id = Convert.ToInt32(GridView1.DataKeys[e.RowIndex].Value);
            SqlCommand cmd = new SqlCommand("delete from Employee where id=@id", con);
            cmd.Parameters.AddWithValue("@id", id);
            cmd.ExecuteNonQuery();

            con.Close();
            GridView1.EditIndex = -1;
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
            int id;
            string FirstName = "";
            string LastName = "";
            string Salary = "";
            string City = "";
            string MobileNumber="";

            id = Convert.ToInt32(GridView1.DataKeys[e.RowIndex].Value);
            FirstName = ((TextBox)(GridView1.Rows[e.RowIndex].FindControl("txtFirstName"))).Text;
            LastName = ((TextBox)(GridView1.Rows[e.RowIndex].FindControl("txtLastName"))).Text;
            Salary = ((TextBox)(GridView1.Rows[e.RowIndex].FindControl("txtSalary"))).Text;
            City = ((TextBox)(GridView1.Rows[e.RowIndex].FindControl("txtCity"))).Text;
      
            MobileNumber = ((TextBox)(GridView1.Rows[e.RowIndex].FindControl("txtMobileNumber"))).Text;

            con.Open();
            SqlCommand cmd = new SqlCommand("update Employee set FirstName=@FirstName,LastName=@LastName,Salary=@Salary,City=@City,MobileNumber=@MobileNumber where id=@id ", con);
            cmd.Parameters.AddWithValue("@FirstName",FirstName );
            cmd.Parameters.AddWithValue("@LastName",LastName );
            cmd.Parameters.AddWithValue("@Salary",Salary);
            cmd.Parameters.AddWithValue("@City",City);
            cmd.Parameters.AddWithValue("@MobileNumber",MobileNumber);
            cmd.Parameters.AddWithValue("@id",id);
            cmd.ExecuteNonQuery();
            con.Close();
            GridView1.EditIndex = -1;
            gridbinding();

        }
    }
  }

    