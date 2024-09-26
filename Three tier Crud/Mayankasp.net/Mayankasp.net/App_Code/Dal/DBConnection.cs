using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;


using System.Configuration;
using System.Data;
using System.Data.SqlClient;

namespace Mayankasp.net.App_Code.Dal
{
    public class DBConnection
    {
        SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["EmployeedbConnectionString"].ToString());

        public SqlConnection open()
        {
            if(con.State==ConnectionState.Broken || con.State==ConnectionState.Closed)
            {
                con.Open();
            }
            return con;
        }

        public SqlConnection close()
        {
            if (con.State == ConnectionState.Open)
            {
                con.Close();
            }
            return con;

        }

    }
} 