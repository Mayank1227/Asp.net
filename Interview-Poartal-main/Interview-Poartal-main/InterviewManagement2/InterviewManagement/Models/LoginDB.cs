using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data;
using System.Data.SqlClient;
using System.Configuration;


namespace InterviewManagement.Models
{
    public class LoginDB
    {
        string cs = ConfigurationManager.ConnectionStrings["InterviewManagemetconnectionString"].ConnectionString;


        public bool isAuth(LoginModel CL)
        {
            bool isauth = false;

            try
            {
                using (SqlConnection connection = new SqlConnection(cs))
                {
                    connection.Open();

                    using (SqlCommand command = new SqlCommand("UspCompanyLogin", connection))
                    {
                        command.CommandType = System.Data.CommandType.StoredProcedure;

                        // Add parameters to the stored procedure
                        command.Parameters.AddWithValue("@P_CompanyName", CL.UserName);
                        command.Parameters.AddWithValue("@P_Password", CL.Password);

                        // Use SqlDataReader to execute the stored procedure and read the results
                        using (SqlDataReader reader = command.ExecuteReader())
                        {
                            // Check if any rows were returned
                            if (reader.Read())
                            {
                                isauth = true;
                                CL.CompanyName = reader["CompanyName"].ToString();
                                CL.CompanyId = (long)reader["CompanyId"];
                                CL.CompanyEmail = reader["EmailId"].ToString();
                                CL.CompanyEmailSmtpPassword = reader["EmailSmtpPassword"].ToString();
                                // Retrieve additional information like CompanyName and CompanyId
                            }
                            else
                            {
                                isauth = false;
                            }
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"An error occurred: {ex.Message}");
            }
            // Return the authentication result
            return isauth;
        }

    }
}