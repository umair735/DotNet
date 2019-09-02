using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data;
using System.Data.SqlClient;
using System.Configuration;

namespace eLeave.DAL
{
    public  class Helper
    {
        static string con1 = ConfigurationManager.ConnectionStrings["abc"].ToString();
        static SqlConnection con = new SqlConnection("Data Source=.;Initial Catalog=eLeave;Integrated Security=True");

        public static void ExecuteQuery(string Query, SqlParameter[] prm)
        {
            SqlCommand cmd = new SqlCommand();
            cmd.CommandText = Query;
            cmd.Connection = con;
            cmd.Parameters.AddRange(prm);
            cmd.CommandType = CommandType.StoredProcedure;
            con.Open();
            cmd.ExecuteNonQuery();
            con.Close();
        }

        public static DataTable ExecutePlainQuery(string Query)
        {
            SqlCommand cmd = new SqlCommand();
            cmd.CommandText = Query;
            cmd.CommandType = CommandType.Text;
            cmd.Connection = con;


            SqlDataAdapter da = new SqlDataAdapter(cmd);
            DataTable dt = new DataTable();
            da.Fill(dt);
            return dt;

        }
        public static DataTable select(string query, SqlParameter[] prm)
        {
            SqlCommand cmd = new SqlCommand();
            cmd.CommandText = query;
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Connection = con;
            cmd.Parameters.AddRange(prm);

            SqlDataAdapter da = new SqlDataAdapter(cmd);
            DataTable dt = new DataTable();
            da.Fill(dt);
            return dt;
        }
    }
}