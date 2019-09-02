using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Data.SqlClient;
using eLeave.DAL;
using eLeave.BAL;
namespace eLeave.User
{
    public partial class Alerts : System.Web.UI.Page
    {
        public void Fill_Alerts()
        {
            grdAlerts.DataSource = Helper.ExecutePlainQuery("select Registration.RegistartionID,SubmitLeave.SubmitLeaveID,Registration.UserName,Department.DepartmentName,LeaveType.LeaveType,SubmitLeave.FormDate,SubmitLeave.ToDate from SubmitLeave inner join Registration on SubmitLeave.RegistrationID=Registration.RegistartionID inner join LeaveType on SubmitLeave.LeaveTypeID=LeaveType.LeaveTypeID inner join	Department on Registration.DepartmentID=Department.DepartmentID;");
            grdAlerts.DataBind();
        
        }
        
        
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                Fill_Alerts();
            }
        }

        protected void Delete_Click(object sender, ImageClickEventArgs e)
        {
            ImageButton delete = (ImageButton)sender;
            AlertsClass.GetSubmitLeaveID =Convert.ToInt32( delete.CommandArgument);
            AlertsClass.Delete_Alerts();

        }

        protected void Approved_Click(object sender, ImageClickEventArgs e)
        {
            ImageButton Approved = (ImageButton)sender;
            Helper.ExecutePlainQuery("Update SubmitLeave set IsApproved='"+true+"' where SubmitLeaveID="+Approved.CommandArgument);
        }

        protected void Deny_Click(object sender, ImageClickEventArgs e)
        {
            ImageButton Deny = (ImageButton)sender;
            Helper.ExecutePlainQuery("Update SubmitLeave set IsDeny='" + true + "' where SubmitLeaveID=" + Deny.CommandArgument);
        }


    }
}