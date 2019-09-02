using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data;
using System.Data.SqlClient;
using eLeave.DAL;

namespace eLeave.BAL
{
    public static class AdminClass
    {
        public static string  GetEmail{ get; set; }
        public static string GetPassword { get; set; }


        public static DataTable AdminLogin()
        {

            SqlParameter[] prm = new SqlParameter[2];
            prm[0] = new SqlParameter("Email", GetEmail);
            prm[1] = new SqlParameter("Password", GetPassword);

            return Helper.select("sp_AdminLogin", prm);
        }



    }
}