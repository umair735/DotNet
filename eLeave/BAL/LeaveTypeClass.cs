using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data;
using System.Data.SqlClient;
using eLeave.DAL;

namespace eLeave.BAL
{
    public class LeaveTypeClass
    {
        public static string GetLeaveType { get; set; }
        public static bool GetIsActive { get { return true; } }
        public static int  GetLeaveTypeID { get; set; }

        public static void InsertLeaveType()
        {
            SqlParameter[] prm = new SqlParameter[2];
            prm[0] = new SqlParameter("LeaveType", GetLeaveType);
            prm[1] = new SqlParameter("IsActive", GetIsActive);
            Helper.ExecuteQuery("sp_InsertLeaveType", prm);
        }

        public static void UpdateLeaveType()
        {
            SqlParameter[] prm = new SqlParameter[3];
            prm[0] = new SqlParameter("LeaveType", GetLeaveType);
            prm[1]=new SqlParameter("LeaveTypeID",GetLeaveTypeID);
            prm[2] = new SqlParameter("IsActive", GetIsActive);
            Helper.ExecuteQuery("sp_UpdateLeaveType", prm);
        }


        public static void DeleteLeaveType()
        {
            SqlParameter[] prm = new SqlParameter[1];
            prm[0] = new SqlParameter("LeaveTypeID", GetLeaveTypeID);
            Helper.ExecuteQuery("sp_DeleteLeaveType", prm);        
        }

    }
}