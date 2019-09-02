using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data;
using System.Data.Sql;
using eLeave.DAL;
using System.Data.SqlClient;

namespace eLeave.BAL
{
    public static class UsersClass
    {
        public static string UserEmail { get; set; }

        public static string UserName { get; set; }

        public static string UserPassword { get; set; }
        
        public static void AddUser()
        {
            SqlParameter[] prm = new SqlParameter[3];
            prm[0] = new SqlParameter("UserName", UserName);
            prm[1] = new SqlParameter("Email", UserEmail);
            prm[2] = new SqlParameter("Password", UserPassword);

            DataTable dt = new DataTable();

            Helper.ExecuteQuery("sp_InsertUser", prm);
        }
    }
}