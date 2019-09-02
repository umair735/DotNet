using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data;
using System.Data.SqlClient;
using eLeave.DAL;
namespace eLeave.BAL
{
    public class RegistrationClass
    {

        public static int GetDepartmentID { get; set; }

        public static string  GetUserName { get; set; }

        public static string GetEmail { get; set; }

        public static string  GetCNIC { get; set; }

        public static string GetAddress { get; set; }

        public static string GetContact { get; set; }

        public static string GetPassword { get; set; }

        public static string GetRePassword { get; set; }

        public static void InsertRegistration()
        {
            SqlParameter[] prm = new SqlParameter[8];
            prm[0] = new SqlParameter("DepartmentID", GetDepartmentID);
            prm[1] = new SqlParameter("UserName", GetUserName);
            prm[2] = new SqlParameter("Email", GetEmail);
            prm[3]=new SqlParameter("CNIC",GetCNIC);
            prm[4] = new SqlParameter("Address", GetAddress);
            prm[5] = new SqlParameter("Contact", GetContact);
            prm[6] = new SqlParameter("Password", GetRePassword);
            prm[7] = new SqlParameter("RePassword", GetRePassword);

            Helper.ExecuteQuery("sp_InsertRegistration", prm);


        
        }
    }
}