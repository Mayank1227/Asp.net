using System;
using System.Data;
using System.Data.SqlClient;
using System.Configuration;
using System.IO;
using System.Web.UI.WebControls;

namespace Asp.Net
{
    public partial class Employee : System.Web.UI.Page
    {
        string connectionString = ConfigurationManager.ConnectionStrings["Student2ConnectionString"].ConnectionString;
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                BindGridView();
            }
        }

        private void BindGridView()
        {
            using (SqlConnection con = new SqlConnection(connectionString))
            {
                using (SqlCommand cmd = new SqlCommand("SELECT * FROM Employees", con))
                {
                    using (SqlDataAdapter sda = new SqlDataAdapter(cmd))
                    {
                        DataTable dt = new DataTable();
                        sda.Fill(dt);
                        GridView1.DataSource = dt;
                        GridView1.DataBind();
                    }
                }
            }
        }

        protected void btnAdd_Click(object sender, EventArgs e)
        {
            string filePath = UploadFile();

            using (SqlConnection con = new SqlConnection(connectionString))
            {
                using (SqlCommand cmd = new SqlCommand("INSERT INTO Employees (Name, Salary, ImagePath) VALUES (@Name, @Salary, @ImagePath)", con))
                {
                    cmd.Parameters.AddWithValue("@Name", txtName.Text.Trim());
                    cmd.Parameters.AddWithValue("@Salary", Convert.ToDecimal(txtSalary.Text.Trim()));
                    cmd.Parameters.AddWithValue("@ImagePath", filePath);
                    con.Open();
                    cmd.ExecuteNonQuery();
                    con.Close();
                }
            }
            BindGridView();
        }
        private string UploadFile()
        {
            string filePath = "";
            if (FileUpload1.HasFile)
            {
                string fileName = Path.GetFileName(FileUpload1.PostedFile.FileName);
                filePath = "~/Images/" + fileName;
                FileUpload1.SaveAs(Server.MapPath(filePath));
            }
            return filePath;
        }

        protected void GridView1_RowEditing(object sender, GridViewEditEventArgs e)
        {
            GridView1.EditIndex = e.NewEditIndex;
            BindGridView();
        }

        protected void GridView1_RowUpdating(object sender, GridViewUpdateEventArgs e)
        {
            int id = Convert.ToInt32(GridView1.DataKeys[e.RowIndex].Value.ToString());
            string name = (GridView1.Rows[e.RowIndex].FindControl("txtName") as TextBox).Text;
            decimal salary = Convert.ToDecimal((GridView1.Rows[e.RowIndex].FindControl("txtSalary") as TextBox).Text);

            FileUpload fileUpload = (GridView1.Rows[e.RowIndex].FindControl("FileUpload1") as FileUpload);
            string imagePath = "";

            // Check if a new image is uploaded
            if (fileUpload.HasFile)
            {
                // Define the path to save the uploaded file
                string fileName = Path.GetFileName(fileUpload.PostedFile.FileName);
                imagePath = "~/Uploads/" + fileName;

                // Resolve the server path for the directory
                string serverPath = Server.MapPath("~/Uploads/");

                // Check if the directory exists, if not, create it
                if (!Directory.Exists(serverPath))
                {
                    Directory.CreateDirectory(serverPath); // Create the directory
                }

                // Save the file to the server
                string fullPath = Path.Combine(serverPath, fileName);
                fileUpload.SaveAs(fullPath);
            }
            else
            {
                // No new image uploaded, retrieve the current image path from the GridView
                imagePath = (GridView1.Rows[e.RowIndex].FindControl("imgPhoto") as Image).ImageUrl;
            }

            // Update the database with new values (including the image path)
            using (SqlConnection con = new SqlConnection(connectionString))
            {
                using (SqlCommand cmd = new SqlCommand("UPDATE Employees SET Name=@Name, Salary=@Salary, ImagePath=@ImagePath WHERE Id=@Id", con))
                {
                    cmd.Parameters.AddWithValue("@Id", id);
                    cmd.Parameters.AddWithValue("@Name", name);
                    cmd.Parameters.AddWithValue("@Salary", salary);
                    cmd.Parameters.AddWithValue("@ImagePath", imagePath);

                    con.Open();
                    cmd.ExecuteNonQuery();
                    con.Close();
                }
            }

            // Reset the edit index and rebind the GridView
            GridView1.EditIndex = -1;
            BindGridView();
        }


        protected void GridView1_RowDeleting(object sender, GridViewDeleteEventArgs e)
        {
            int id = Convert.ToInt32(GridView1.DataKeys[e.RowIndex].Value.ToString());

            using (SqlConnection con = new SqlConnection(connectionString))
            {
                using (SqlCommand cmd = new SqlCommand("DELETE FROM Employees WHERE Id=@Id", con))
                {
                    cmd.Parameters.AddWithValue("@Id", id);
                    con.Open();
                    cmd.ExecuteNonQuery();
                    con.Close();
                }
            }
            BindGridView();
        }

        protected void GridView1_RowCancelingEdit(object sender, GridViewCancelEditEventArgs e)
        {
            GridView1.EditIndex = -1;
            BindGridView();
        }
    }
}