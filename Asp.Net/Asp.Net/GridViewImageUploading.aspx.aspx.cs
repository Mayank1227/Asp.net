using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Data.SqlClient;
using System.IO;
using System.Configuration;

namespace Asp.Net
{
    public partial class GridViewImageUploading_aspx : System.Web.UI.Page
    {

        SqlConnection con;
        SqlDataAdapter da;
        DataSet ds;
        SqlCommand cmd;

       // SqlConnection con = new SqlConnection("Data Source=DESKTOP-0T00OD0;Initial Catalog=Employeedb;Integrated Security=True");
         string connStr = ConfigurationManager.ConnectionStrings["EmployeedbConnectionString"].ConnectionString;
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                ImageData();
            }
        }
        protected void upload_Click(object sender, EventArgs e)
        {
            try
            {
                string filename = Path.GetFileName(fileupload.PostedFile.FileName);
                fileupload.SaveAs(Server.MapPath("~/Images/" + filename));
                con = new SqlConnection(connStr);
                con.Open();
                cmd = new SqlCommand("insert into Image_Details (ImageName,Image) values(@ImageName,@Image)", con);
                cmd.Parameters.AddWithValue("@ImageName", filename);
                cmd.Parameters.AddWithValue("@Image", "Images/" + filename);
                cmd.ExecuteNonQuery();
                ImageData();
            }
            catch (Exception ex)
            {
                upload.Text = ex.Message;
            }
        }
        protected void ImageData()
        {
            con = new SqlConnection(connStr);
            con.Open();
            da = new SqlDataAdapter("select * from Image_Details", con);
            ds = new DataSet();
            da.Fill(ds);
            gvImage.DataSource = ds;
            gvImage.DataBind();
        }
        // edit event
        protected void gvImage_RowEditing(object sender, GridViewEditEventArgs e)
        {
            gvImage.EditIndex = e.NewEditIndex;
            ImageData();

        }
        // update event
        protected void gvImage_RowUpdating(object sender, GridViewUpdateEventArgs e)
        {
            //find image id of edit row
            string imageId = gvImage.DataKeys[e.RowIndex].Value.ToString();
            // find values for update
            TextBox name = (TextBox)gvImage.Rows[e.RowIndex].FindControl("txt_Name");
            FileUpload FileUpload1 = (FileUpload)gvImage.Rows[e.RowIndex].FindControl("FileUpload1");
            con = new SqlConnection(connStr);
            string path = "~/Images/";
            if (FileUpload1.HasFile)
            {
                path += FileUpload1.FileName;
                //save image in folder
                FileUpload1.SaveAs(MapPath(path));
            }
            else
            {
                // use previous user image if new image is not changed
                Image img = (Image)gvImage.Rows[e.RowIndex].FindControl("img_user");
                path = img.ImageUrl;
            }
            SqlCommand cmd = new SqlCommand("update Image_Details set ImageName='" + name.Text + "',image='" + path + "'  where ImageId=" + imageId + "", con);
            con.Open();
            cmd.ExecuteNonQuery();
            con.Close();
            gvImage.EditIndex = -1;
            ImageData();
        }
        // cancel edit event
        protected void gvImage_RowCancelingEdit(object sender, GridViewCancelEditEventArgs e)
        {
            gvImage.EditIndex = -1;
            ImageData();
        }
        //delete event
        protected void gvImage_RowDeleting(object sender, GridViewDeleteEventArgs e)
        {
            GridViewRow row = (GridViewRow)gvImage.Rows[e.RowIndex];
            Label lbldeleteid = (Label)row.FindControl("lblImgId");
            Label lblDeleteImageName = (Label)row.FindControl("lblImageName");
            con = new SqlConnection(connStr);
            con.Open();
            SqlCommand cmd = new SqlCommand("delete FROM Image_Details where ImageId='" + Convert.ToInt32(gvImage.DataKeys[e.RowIndex].Value.ToString()) + "'", con);
            cmd.ExecuteNonQuery();
            con.Close();
            ImageDeleteFromFolder(lblDeleteImageName.Text);
            ImageData();
        }
        /// <summary>
        /// This function is used to delete image from folder when deleting in gridview.
        /// </summary>
        /// <param name="imagename">image name</param>
        protected void ImageDeleteFromFolder(string imagename)
        {
            string file_name = imagename;
            string path = Server.MapPath("~/Images/" + imagename);

            FileInfo file = new FileInfo(path);
            if (file.Exists) //check file exsit or not
            {
                file.Delete();
                lblResult.Text = file_name + " file deleted successfully";
                lblResult.ForeColor = System.Drawing.Color.Green;
            }
            else
            {
                lblResult.Text = file_name + " This file does not exists ";
                lblResult.ForeColor = System.Drawing.Color.Red;
            }
        }

       
    }
}