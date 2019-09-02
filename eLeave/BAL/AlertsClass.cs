using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data;
using System.Data.SqlClient;
using eLeave.DAL;

namespace eLeave.BAL
{
    public class AlertsClass
    {
        public static int  GetSubmitLeaveID { get; set; }


        public static void Delete_Alerts()
        {

            SqlParameter[] prm = new SqlParameter[1];
            prm[1] = new SqlParameter("SubmitLeaveID", GetSubmitLeaveID);

            Helper.ExecuteQuery("sp_Delete_Alerts", prm);
        }



    }
}