using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Net;
using System.Net.Mail;
using System.Web;

namespace InterviewManagement.Models
{
	public class InterviewMethod
    {

        string cs = ConfigurationManager.ConnectionStrings["InterviewManagemetconnectionString"].ConnectionString;

        // Retrieve CompanyId and CompanyName from session
        long CompanyId = Convert.ToInt32(HttpContext.Current.Session["CompanyId"]);
        string CompanyName = HttpContext.Current.Session["CompanyName"].ToString();

        // Sender's email address and App Password for two-factor authentication
        string FromEmail = HttpContext.Current.Session["CompanyEmail"].ToString();
        string AppPassword = HttpContext.Current.Session["CompanyEmailSmtpPassword"].ToString();

        // Show all data
        public List<InterviewMaster> GetAllCandidate()
        {
            List<InterviewMaster> lstCandidate = new List<InterviewMaster>();

            using (SqlConnection con = new SqlConnection(cs))
            {
                SqlCommand cmd = new SqlCommand("UspGetCandidateData", con);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@P_CompanyId", CompanyId);
                SqlDataAdapter da = new SqlDataAdapter(cmd);
                DataTable dt = new DataTable();

                con.Open();
                da.Fill(dt);
                con.Close();

                foreach (DataRow row in dt.Rows)
                {
					InterviewMaster IM = new InterviewMaster
					{
						CompanyId = (long)row["CompanyId"],
						CompanyName = row["CompanyName"].ToString(),
						CandidateId = (long)row["CandidateId"],
                        InterViewStatus= row["InterviewType"].ToString(),
                        FirstName = row["FirstName"].ToString(),
						LastName = row["LastName"].ToString(),
						Email = row["EmailId"].ToString(),
						MobailNumber = row["MobileNo"].ToString(),
						Address = row["AddressName"].ToString(),
						DOB = (DateTime)row["DateOfBirth"],
						Age = row["Age"].ToString(),
						Qualification = row["Qualification"].ToString(),
						Skill = row["MasterSkills"].ToString(),
						Experience = row["WorkExperience"].ToString(),
						City = row["City"].ToString(),
						Country = row["Country"].ToString(),
						State = row["State"].ToString(),
                        TotalPendingInterviewCount = (long)row["TotalPendingInterviewCount"]

                    };

					lstCandidate.Add(IM);
                }
            }
            return lstCandidate;
        }

       
        // ShowDeshboard all data
        public List<InterviewMaster> GetAllCandidateDeshBoard()
        {
            List<InterviewMaster> lstCandidate = new List<InterviewMaster>();

            using (SqlConnection con = new SqlConnection(cs))
            {
                SqlCommand cmd = new SqlCommand("UspGetCandidateDataDeshboard", con);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@P_CompanyId", CompanyId);
                SqlDataAdapter da = new SqlDataAdapter(cmd);
                DataTable dt = new DataTable();

                con.Open();
                da.Fill(dt);
                con.Close();

                foreach (DataRow row in dt.Rows)
                {
                    InterviewMaster IM = new InterviewMaster
                    {
                        CompanyId = (long)row["CompanyId"],
                        CompanyName = row["CompanyName"].ToString(),
                        CandidateId = (long)row["CandidateId"],
                        FirstName = row["FirstName"].ToString(),
                        LastName = row["LastName"].ToString(),
                        Email = row["EmailId"].ToString(),
                        MobailNumber = row["MobileNo"].ToString(),
                        Address = row["AddressName"].ToString(),
                        DOB = (DateTime)row["DateOfBirth"],
                        Age = row["Age"].ToString(),
                        Qualification = row["Qualification"].ToString(),
                        Skill = row["MasterSkills"].ToString(),
                        Experience = row["WorkExperience"].ToString(),
                        City = row["City"].ToString(),
                        Country = row["Country"].ToString(),
                        State = row["State"].ToString()
                    };

                    lstCandidate.Add(IM);
                }
            }
            return lstCandidate;
        }




        // insert all data 
        public bool AddOrUpdateCandidate(InterviewMaster IM, out string errorMessage)
		{
			try
			{
			
				using (SqlConnection con = new SqlConnection(cs))
				using (SqlCommand cmd = new SqlCommand("USpCandidateSave", con))
				{
					cmd.CommandType = CommandType.StoredProcedure;
					cmd.Parameters.AddWithValue("@P_CandidateId", IM.CandidateId);
					cmd.Parameters.AddWithValue("@P_CompanyId", CompanyId);
					cmd.Parameters.AddWithValue("@P_CompanyName", CompanyName);
					cmd.Parameters.AddWithValue("@P_FirstName", IM.FirstName);
					cmd.Parameters.AddWithValue("@P_LastName", IM.LastName);
					cmd.Parameters.AddWithValue("@P_MobileNo", IM.MobailNumber);
					cmd.Parameters.AddWithValue("@P_DateOfBirth", IM.DOB);
					cmd.Parameters.AddWithValue("@P_Age", IM.Age);
					cmd.Parameters.AddWithValue("@P_Qualification", IM.Qualification);
					cmd.Parameters.AddWithValue("@P_MasterSkills", IM.Skill);
					cmd.Parameters.AddWithValue("@P_WorkExperience", IM.Experience);
					cmd.Parameters.AddWithValue("@P_EmailId", IM.Email);
					cmd.Parameters.AddWithValue("@P_AddressName", IM.Address);
					cmd.Parameters.AddWithValue("@P_Country", IM.Country);
					cmd.Parameters.AddWithValue("@P_State", IM.State);
					cmd.Parameters.AddWithValue("@P_City", IM.City);

					// Add output parameter for the error message
					SqlParameter errorMessageParam = new SqlParameter("@P_ErrorMessage", SqlDbType.VarChar, 500);
					errorMessageParam.Direction = ParameterDirection.Output;
					cmd.Parameters.Add(errorMessageParam);

					con.Open();
					int i= cmd.ExecuteNonQuery();

					// Retrieve the error message from the output parameter
					errorMessage = cmd.Parameters["@P_ErrorMessage"].Value.ToString();

                    if (i > 0)
                    {
                        return true;
                    }
                    else
                    {
                        return false;
                    }
                }
			}
			catch (SqlException ex)
			{
				// Log the exception details for debugging
				errorMessage = "SQL Error occurred: " + ex.Message;
				return false;
			}
			catch (Exception ex)
			{
				// Handle other exceptions
				errorMessage = "An error occurred: " + ex.Message;
				return false;
			}
		}

		

        //DeleteCandidate
        public bool DeleteCandidate(int id)
        {
            try
            {
                using (SqlConnection con = new SqlConnection(cs))
                {
                    using (SqlCommand cmd = new SqlCommand("UspSoftDeleteCandidate", con))
                    {
                        cmd.CommandType = CommandType.StoredProcedure;
                        cmd.Parameters.AddWithValue("@P_CandidateId", id);
                        con.Open();
                        int i = cmd.ExecuteNonQuery();

                        return i > 0;
                    }
                }
            }
            catch (Exception ex)
            {
                // Handle the exception (log it, throw it, etc.)
                Console.WriteLine("An error occurred while deleting an employee: " + ex.Message);
                return false;
            }
        }



        // SendInterviewEmail Method

        public bool SendInterviewEmail(InterviewMaster Inter, ScheduleInterviewDB Intersi)
        {
            try
            {             
                // Create a MailMessage object
                MailMessage mailMessage = new MailMessage();
                mailMessage.From = new MailAddress(FromEmail);
                mailMessage.To.Add(Intersi.InterviewEmail);
               // = $"Interview Invitation{Intersi.InterviewDate}";
               // = $"Interview Invitation{Intersi.InterviewDate}";
                mailMessage.Subject = $"Interview Date Confirmation - {Intersi.InterviewDate:yyyy-MM-dd}";
                mailMessage.Body = $"Dear { Inter.FirstName + Inter.LastName}\n\nWe would like to schedule your interview for { Intersi.InterviewDate:yyyy - MM - dd}\n \n at { Intersi.InterviewLocation}. Please let us know your availability.\n\nBest Regards,\n{CompanyName}";


                // Configure SmtpClient
                SmtpClient smtpClient = new SmtpClient();
                smtpClient.Host = "smtp.gmail.com";
                smtpClient.Port = 587; // Set the appropriate SMTP port
                smtpClient.UseDefaultCredentials = false;
                smtpClient.Credentials = new NetworkCredential(FromEmail, AppPassword); // Replace with your SMTP credentials
                smtpClient.EnableSsl = true; // Set to true if your SMTP server requires SSL/TLS

                // Send the email
                smtpClient.Send(mailMessage);

                return true;
            }
            catch (Exception ex)
            {
                // Handle exceptions appropriately (log, display error message, etc.)
                Console.WriteLine($"Error sending email: {ex.Message}");
                return false;
            }
        }

        // ScheduleInterview  insert data

        public bool  AddScheduleInterview( ScheduleInterviewDB Inter)
        {
			try
			{
				using (SqlConnection con = new SqlConnection(cs))
				{
					SqlCommand cmd = new SqlCommand("USpScheduleInterviewSave", con);
					cmd.CommandType = CommandType.StoredProcedure;

					cmd.Parameters.AddWithValue("@P_CandidateId", Inter.CandidateId);
					cmd.Parameters.AddWithValue("@P_CompanyId", CompanyId);					
					cmd.Parameters.AddWithValue("@P_InterviewDate", Inter.InterviewDate);
					cmd.Parameters.AddWithValue("@P_InterviewLocation", Inter.InterviewLocation);
					cmd.Parameters.AddWithValue("@P_CompanyEmail", FromEmail);
                    cmd.Parameters.AddWithValue("@P_EmployeeId", Inter.EmployeeId);

                    con.Open();
					int i = cmd.ExecuteNonQuery();
					con.Close();

					if (i > 0)
					{
						return true;
					}
					else
					{
						return false;
					}
				}
			}
			catch (Exception ex)
			{
                // Handle exceptions appropriately (log, display error message, etc.)
                Console.WriteLine($"Error sending email: {ex.Message}");
                return false;
            }
        }

      
        // Show all data
        public List<InterviewMaster>ScheduleInterviewMethod()
        {
            List<InterviewMaster> lstCandidate = new List<InterviewMaster>();

            using (SqlConnection con = new SqlConnection(cs))
            {
                SqlCommand cmd = new SqlCommand("UspGetScheduleInterviewCandidateData", con);
                cmd.CommandType = CommandType.StoredProcedure;
                
                SqlDataAdapter da = new SqlDataAdapter(cmd);
                DataTable dt = new DataTable();

                con.Open();
                cmd.Parameters.AddWithValue("@P_CompanyId", CompanyId);
                da.Fill(dt);
                con.Close();

                foreach (DataRow row in dt.Rows)
                {
                    InterviewMaster IM = new InterviewMaster 
                    {
                        CompanyId = (long)row["CompanyId"],
                        CompanyName = row["CompanyName"].ToString(),
                        CandidateId = (long)row["CandidateId"],
                        InterViewStatus = row["InterviewType"].ToString(),
                        FirstName = row["FirstName"].ToString(),
                        LastName = row["LastName"].ToString(),
                        Email = row["EmailId"].ToString(),
                        MobailNumber = row["MobileNo"].ToString(),
                        Address = row["AddressName"].ToString(),
                        DOB = (DateTime)row["DateOfBirth"],
                        Age = row["Age"].ToString(),
                        Qualification = row["Qualification"].ToString(),
                        Skill = row["MasterSkills"].ToString(),
                        Experience = row["WorkExperience"].ToString(),
                        City = row["City"].ToString(),
                        Country = row["Country"].ToString(),
                        State = row["State"].ToString(),
                        InterviewRoundName = row["InterviewRoundName"].ToString(),
                        InterviewLocation = row["InterviewLocation"].ToString(),
                        InterviewDate  = (DateTime)row["InterviewDate"],
                        InProgressInterviewCount = (long)row["InProgressInterviewCount"]

                    };
                    lstCandidate.Add(IM);
                }
            }
            return lstCandidate;
        }

       

        //Interview Date
        public List<InterviewMaster> ScheduleInterviewDateMethod()
        {
            List<InterviewMaster> lstCandidate = new List<InterviewMaster>();

            using (SqlConnection con = new SqlConnection(cs))
            {
                SqlCommand cmd = new SqlCommand("UspGetScheduleInterviewCandidateDateList", con); // Change the stored procedure name
                cmd.CommandType = CommandType.StoredProcedure;

                SqlDataAdapter da = new SqlDataAdapter(cmd);
                DataTable dt = new DataTable();

                con.Open();
                cmd.Parameters.AddWithValue("@P_CompanyId", CompanyId);
                da.Fill(dt);
                con.Close();

                foreach (DataRow row in dt.Rows)
                {
                    InterviewMaster IM = new InterviewMaster
                    {
                        CompanyId = (long)row["CompanyId"],
                        CompanyName = row["CompanyName"].ToString(),
                        CandidateId = (long)row["CandidateId"],
                        FirstName = row["FirstName"].ToString(),
                        LastName = row["LastName"].ToString(),
                        Email = row["EmailId"].ToString(),
                        MobailNumber = row["MobileNo"].ToString(),
                        Address = row["AddressName"].ToString(),
                        DOB = (DateTime)row["DateOfBirth"],
                        Age = row["Age"].ToString(),
                        Qualification = row["Qualification"].ToString(),
                        Skill = row["MasterSkills"].ToString(),
                        Experience = row["WorkExperience"].ToString(),
                        City = row["City"].ToString(),
                        Country = row["Country"].ToString(),
                        State = row["State"].ToString(),
                        InterviewRoundName = row["InterviewRoundName"].ToString(),
                        InterviewLocation = row["InterviewLocation"].ToString(),
                        InterviewDate = (DateTime)row["InterviewDate"],
                        InterviewDateCandite = (long)row["InterviewCount"],
                        // InterviewDateCandite = (long)row["@InterviewCount"],
                    };
                    lstCandidate.Add(IM);
                }
            }
            return lstCandidate;
        }

    }
}