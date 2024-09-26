using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

using Mayankasp.net.App_Code.Bal;
using Mayankasp.net.App_Code.Dal;
using System.Data.Sql;
using System.Data.SqlClient;
using System.Data;

namespace Mayankasp.net.App_Code.Dal
{
    public class DL_Student
    {
        DBConnection con = new DBConnection();
        public void insert(BL_Student objbl)
        {
            SqlCommand cmd = new SqlCommand();
            cmd.Connection = con.open();
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.CommandText = "Sp_StudentReg";
            cmd.Parameters.AddWithValue("@firstname", objbl.firstname);
            cmd.Parameters.AddWithValue("@lastname", objbl.lastname);
            cmd.Parameters.AddWithValue("@emailid", objbl.emailid);
            cmd.Parameters.AddWithValue("@password", objbl.password);
            cmd.Parameters.AddWithValue("@age", objbl.age);

            cmd.Parameters.AddWithValue("@action", "insert");

            cmd.ExecuteNonQuery();

        }
        public DataSet select()
        {
            SqlCommand cmd = new SqlCommand();
            cmd.Connection = con.open();
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.CommandText = "Sp_StudentReg";

            cmd.Parameters.AddWithValue("@action", "select");

            DataSet ds = new DataSet();
            SqlDataAdapter adpt = new SqlDataAdapter(cmd);
            adpt.Fill(ds);
            return ds;

        }
        public void delete(BL_Student objb1)
        {
            SqlCommand cmd = new SqlCommand();
            cmd.Connection = con.open();
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.CommandText = "Sp_StudentReg";
            cmd.Parameters.AddWithValue("@id", objb1.id);
            cmd.Parameters.AddWithValue("@action", "delete");
            cmd.ExecuteNonQuery();
        }
        public void update(BL_Student objbl)
        {
            SqlCommand cmd = new SqlCommand();
            cmd.Connection = con.open();
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.CommandText = "Sp_StudentReg";
            cmd.Parameters.AddWithValue("@firstname", objbl.firstname);
            cmd.Parameters.AddWithValue("@lastname", objbl.lastname);
            cmd.Parameters.AddWithValue("@emailid", objbl.emailid);
            cmd.Parameters.AddWithValue("@password", objbl.password);

            cmd.Parameters.AddWithValue("@id", objbl.id);

            cmd.Parameters.AddWithValue("@action", "update");

            cmd.ExecuteNonQuery();

        }

        public SqlDataReader login(BL_Student objbl)
        {
            SqlCommand cmd = new SqlCommand();
            cmd.Connection = con.open();
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.CommandText = "Sp_StudentReg";
            cmd.Parameters.AddWithValue("@emailid", objbl.emailid);
            cmd.Parameters.AddWithValue("@password", objbl.password);

            cmd.Parameters.AddWithValue("@action", "login");

            SqlDataReader dr;
            dr = cmd.ExecuteReader();
            return dr;

        }


    }
}



