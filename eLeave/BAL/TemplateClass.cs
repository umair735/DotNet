using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data;
using System.Data.SqlClient;
using eLeave.DAL;
namespace eLeave.BAL
{
    public class TemplateClass
    {
        public static string GetTemplate { get; set; }

        public static int GetTemplateID { get; set; }

        public static int  GetLeaveTypeID { get; set; }

        public static bool GetIsActive { get { return true; } }

        public static void InsertTemplate()
        {
            SqlParameter[] prm = new SqlParameter[3];
            prm[0] = new SqlParameter("Template", GetTemplate);
            prm[1] = new SqlParameter("LeaveTypeID", GetLeaveTypeID);
            prm[2]=new SqlParameter("IsActive",GetIsActive);
            Helper.ExecuteQuery("sp_InsertTemplate",prm);
        }

        public static void DeleteTemplate()
        {
            SqlParameter[] prm = new SqlParameter[1];
            prm[0] = new SqlParameter("TemplateID", GetTemplateID);
            Helper.ExecuteQuery("sp_DeleteTemplate",prm);

        }


        public static void UpdateTemplate()
        {
            SqlParameter[] prm = new SqlParameter[3];
            prm[0] = new SqlParameter("Template", GetTemplate);
            prm[1] = new SqlParameter("LeaveTypeID", GetLeaveTypeID);
            
            prm[2] = new SqlParameter("TemplateID", GetTemplateID);
            Helper.ExecuteQuery("sp_UpdateTemplate", prm);
        
        }
    }
}