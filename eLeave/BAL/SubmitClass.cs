using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data;
using System.Data.SqlClient;
using eLeave.DAL;
namespace eLeave.BAL
{
    public class SubmitClass
    {
        public static int GetRegistrationID { get; set; }

        public static int GetLeaveTypeID { get; set; }

        public static DateTime GetFormDate { get; set; }

        public static DateTime GetToDate { get; set; }

        public static string GetApplicationText { get; set; }              

        public static bool GetIsActive { get { return true; } }

        public static bool GetIsApproved { get { return false; } }

        public static bool GetIsDeny { get { return false; } }


        public static void Insert_SubmitLeave()
        {
            SqlParameter[] prm = new SqlParameter[8];
            prm[0] = new SqlParameter("RegistrationID", GetRegistrationID);
            prm[1] = new SqlParameter("LeaveTypeID", GetLeaveTypeID);
            prm[2] = new SqlParameter("FormDate", GetFormDate);
            prm[3] = new SqlParameter("ToDate", GetToDate);
            prm[4] = new SqlParameter("ApplicationText", GetApplicationText);            
            prm[5] = new SqlParameter("IsActive", GetIsActive);
            prm[6] = new SqlParameter("IsApproved", GetIsApproved);
            prm[7] = new SqlParameter("IsDeny", GetIsDeny);

            Helper.ExecuteQuery("sp_Insert_SubmitLeave", prm);
        }

    }
}