using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Mail;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Asp.Net
{
    public partial class EmailSendingFunctionality : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void btnsend_Click(object sender, EventArgs e)
        {
            send();
        }
        public void send()
        {
            try
            {
                string FromAdd = "patelmayank@gmail.com";
                string ToAdd = txtTo.Text.Trim();
                string Sub = txtSubject.Text.Trim();
                string body = txtBody.Text.Trim();

                //using (MailMessage mm = new MailMessage(FromAdd, ToAdd))
                //{

                MailMessage mm = new MailMessage(FromAdd, ToAdd);
                mm.Subject = Sub;
                mm.Body = body;
                mm.IsBodyHtml = false;

                SmtpClient smtp = new SmtpClient();
                smtp.Send(mm); //send email to specific email id
                ClearForm();
                Label1.Text = "Mail sent Successfully...!";
                //   }
            }
            catch (Exception ex)
            {
                Label1.Text = ex.ToString();
                Label1.ForeColor = System.Drawing.Color.Red;
            }

        }
        void ClearForm() // data clear after sending mail
        {
            txtTo.Text = "";
            txtSubject.Text = "";
            txtBody.Text = "";

        }

        protected void Button1_Click(object sender, EventArgs e)
        {
            ClearForm();
        }
    }
}