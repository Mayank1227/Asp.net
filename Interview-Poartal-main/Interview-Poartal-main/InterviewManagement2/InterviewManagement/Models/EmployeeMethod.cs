using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Web;

namespace InterviewManagement.Models
{
    public class EmployeeMethod
    {

        string cs = ConfigurationManager.ConnectionStrings["InterviewManagemetconnectionString"].ConnectionString;

        // Retrieve CompanyId and CompanyName from session
        long CompanyId = Convert.ToInt32(HttpContext.Current.Session["CompanyId"]);
        string CompanyName = HttpContext.Current.Session["CompanyName"].ToString();

        //show method in database
        public List<EmployeeMaster> GetEmployeeData(EmployeeMaster emp = null)
        {
            List<EmployeeMaster> EmployeeList = new List<EmployeeMaster>();

            try
            {
                using (SqlConnection con = new SqlConnection(cs))
                {
                    using (SqlCommand cmd = new SqlCommand("UspGetAllEmploye", con)) // Corrected stored procedure name
                    {
                        cmd.CommandType = CommandType.StoredProcedure;

                        con.Open();
                        long CompanyId = Convert.ToInt64(HttpContext.Current.Session["CompanyId"]);
                        cmd.Parameters.AddWithValue("@P_CompanyId", CompanyId);

                        // object paramValue = null;
                        if (emp != null)
                        {
                            // string paramValue1 = emp.Employee_F_L_D;
                            cmd.Parameters.AddWithValue("@P_Employee_F_L_D", emp.Employee_F_L_D);
                        }


                        int i = cmd.ExecuteNonQuery();

                        using (SqlDataReader dr = cmd.ExecuteReader())
                        {
                            while (dr.Read())
                            {
                                EmployeeMaster employee = new EmployeeMaster
                                {
                                    CompanyId = (long)dr["CompanyId"],
                                    EmployeeId = (long)dr["EmployeeId"],
                                    CompanyName = dr["CompanyName"].ToString(),
                                    FirstName = dr["FirstName"].ToString(),
                                    MiddleName = dr["MiddleName"].ToString(),
                                    LastName = dr["LastName"].ToString(),
                                    MobileNo = dr["MobileNo"].ToString(),
                                    DateOfBirth = (DateTime)dr["DateOfBirth"],
                                    Password = dr["Password"].ToString(),
                                    EmailId = dr["EmailId"].ToString(),
                                    DateOfJoining = (DateTime)dr["DateOfJoining"],
                                    ManagerId = (int)dr["ManagerId"],
                                    EmployeeRoll = dr["RollName"].ToString(),
                                    TypeName = dr["Department"].ToString(),
                                    TotalEmployee = (long)dr["TotalEmployee"]
                                };

                                EmployeeList.Add(employee);
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

            return EmployeeList;
        }



        //Delete
        public bool DeleteEmployee(int id)
        {
            try
            {
                using (SqlConnection con = new SqlConnection(cs))
                {
                    using (SqlCommand cmd = new SqlCommand("UspSoftDeleteEmployee", con))
                    {
                        cmd.CommandType = CommandType.StoredProcedure;
                        cmd.Parameters.AddWithValue("@P_EmployeeId", id);
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


        // AddUpadteMethodEmployee

        public bool AddOrUpdateEmployee(EmployeeMaster emp, out string errorMessage)
        {
            try
            {
               

                using (SqlConnection con = new SqlConnection(cs))
                using (SqlCommand cmd = new SqlCommand("UspEmployeeSave", con))
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@P_EmployeeId", emp.EmployeeId);
                    cmd.Parameters.AddWithValue("@P_CompanyId", CompanyId);
                    cmd.Parameters.AddWithValue("@P_CompanyName", CompanyName);
                    cmd.Parameters.AddWithValue("@P_FirstName", emp.FirstName);
                    cmd.Parameters.AddWithValue("@P_MiddleName", emp.MiddleName);
                    cmd.Parameters.AddWithValue("@P_LastName", emp.LastName);
                    cmd.Parameters.AddWithValue("@P_MobileNo", emp.MobileNo);
                    cmd.Parameters.AddWithValue("@P_DateOfBirth", emp.DateOfBirth);
                    cmd.Parameters.AddWithValue("@P_Password", emp.Password);
                    cmd.Parameters.AddWithValue("@P_EmailId", emp.EmailId);
                    cmd.Parameters.AddWithValue("@P_ManagerId", emp.ManagerId);
                    cmd.Parameters.AddWithValue("@P_EmployeeRoll", emp.EmployeeRoll);
                    cmd.Parameters.AddWithValue("@P_Department", emp.TypeName);



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
    }
}