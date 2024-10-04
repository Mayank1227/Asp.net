using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

namespace InterviewManagement.Models
{
	public class Method
	{
        string cs = ConfigurationManager.ConnectionStrings["InterviewManagemetconnectionString"].ConnectionString;
        //string cs = ConfigurationManager.ConnectionStrings["abc"].ConnectionString;


        //show method in database
        public List<Master> GetCompanyShowData()
        {
            List<Master> userclassList = new List<Master>();

            try
            {
                using (SqlConnection con = new SqlConnection(cs))
                {
                    using (SqlCommand cmd = new SqlCommand("UspGetCompanyDetail", con))
                    {
                        cmd.CommandType = CommandType.StoredProcedure;
                        con.Open();

                        using (SqlDataReader dr = cmd.ExecuteReader())
                        {
                            while (dr.Read())
                            {
                                Master user = new Master();

                                user.CompanyId = Convert.ToInt64(dr["CompanyId"]);
                                user.CompanyName = dr["CompanyName"].ToString();
                                user.MobileNo = dr["MobailNumber"].ToString();
                                user.EmailId = dr["EmailId"].ToString();
                                user.Password = dr["Password"].ToString();
                                user.CompanyShortName = dr["CompanyShortName"].ToString();
                                user.IsActive = Convert.ToInt32(dr["CompanyIsActive"]);
                                user.CreatedBy = dr["CompanyCreatedBy"].ToString();
                                user.CreatedOn = Convert.ToDateTime(dr["CompanyCreatedOn"]);
                                user.UpdatedBy = dr["CompanyUpdatedBy"].ToString();
                                user.UpdatedOn = Convert.ToDateTime(dr["CompanyUpdatedOn"]);
                                user.CompanyDetailId = Convert.ToInt64(dr["CompanyDetailId"]);
                                user.GSTNo = dr["GSTNo"].ToString();
                                user.PanCardNo = dr["PanNo"].ToString();
                                
                                // user.EmailSmtpPassword = dr["EmailSmtpPassword "].ToString();

                                userclassList.Add(user);
                            }
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                // Handle the exception (log it, throw it, etc.)
                Console.WriteLine("An error occurred while fetching data: " + ex.Message);
            }

            return userclassList;
        }



        //Insert and Update Data
        public bool AddOrUpdateCompanay(Master CM, string fullpath, out string errorMessage)
        {
            try
            {
              
                using (SqlConnection con = new SqlConnection(cs))
                using (SqlCommand cmd = new SqlCommand("UspCompanySave", con))
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    var EmailSmtpPassword = "umam gpko xcqh hfxd";
                    cmd.Parameters.AddWithValue("@P_EmailSmtpPassword", EmailSmtpPassword);
                    // Add Parameters
                    cmd.Parameters.AddWithValue("@P_CompanyId", CM.CompanyId);
                    cmd.Parameters.AddWithValue("@P_CompanyName", CM.CompanyName);
                    cmd.Parameters.AddWithValue("@P_MobileNo", CM.MobileNo);
                    cmd.Parameters.AddWithValue("@P_Email", CM.EmailId);
                    cmd.Parameters.AddWithValue("@P_Password", CM.Password);
                    cmd.Parameters.AddWithValue("@P_CompanyShortName", CM.CompanyShortName);
                    cmd.Parameters.AddWithValue("@P_PanNo", CM.PanCardNo);
                    cmd.Parameters.AddWithValue("@P_GstNo", CM.GSTNo);
                    cmd.Parameters.AddWithValue("@P_File", fullpath);



                    // Add output parameter for the error message
                    SqlParameter errorMessageParam = new SqlParameter("@P_ErrorMessage", SqlDbType.VarChar, 500);
                    errorMessageParam.Direction = ParameterDirection.Output;
                    cmd.Parameters.Add(errorMessageParam);

                    con.Open();
                    int i = cmd.ExecuteNonQuery();

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

       

        //Delete
        public bool DeleteCompany(int id)
        {
            try
            {
                using (SqlConnection con = new SqlConnection(cs))
                {
                    using (SqlCommand cmd = new SqlCommand("UspSoftDeleteCompany", con))
                    {
                        cmd.CommandType = CommandType.StoredProcedure;
                        cmd.Parameters.AddWithValue("@P_CompanyId", id);
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

        // DeshBoardCount
        public List<DeshBoard> GetDeshBoardCount()
        {
            List<DeshBoard> userclassList = new List<DeshBoard>();

            try
            {
                using (SqlConnection con = new SqlConnection(cs))
                {
                    using (SqlCommand cmd = new SqlCommand("UspAllDeatilsCount", con))
                    {
                        cmd.CommandType = CommandType.StoredProcedure;
                        con.Open();

                        using (SqlDataReader dr = cmd.ExecuteReader())
                        {
                            while (dr.Read())
                            {
								DeshBoard user = new DeshBoard
								{
									TotalCompany = (long)dr["TotalCompany"],
									LoginEmployee = (long)dr["TotalCandidate"],
									LoginCandidate = (long)dr["TotalEmployee"],
									TodayInterview = (long)dr["SheduleCandidate"]
								};

								// user.EmailSmtpPassword = dr["EmailSmtpPassword "].ToString();

								userclassList.Add(user);
                            }
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                // Handle the exception (log it, throw it, etc.)
                Console.WriteLine("An error occurred while fetching data: " + ex.Message);
            }

            return userclassList;
        }

    }
}