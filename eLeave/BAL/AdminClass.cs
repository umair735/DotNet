using eLeave.DAL;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

namespace eLeave.BAL
{
    public static class AdminClass
    {
        public static string Email { get; set; }
        public static string Password { get; set; }
        public static Datatable AdminLogin()
        {
            SqlParameter[] prm = new SqlParameter[8];
            prm[0] = new SqlParameter("Email", Email);
            prm[1] = new SqlParameter("Password", Password);
            Datatable dt = new Datatable();
        
            dt=Helper.select("sp_select", prm);
            return dt;



        }
    }
}