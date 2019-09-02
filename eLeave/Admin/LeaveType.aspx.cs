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

namespace eLeave.Admin
{
    public partial class LeaveType : System.Web.UI.Page
    {

        public void FillLeaveType()
        {
            grdLeaveType.DataSource = Helper.ExecutePlainQuery("sp_FillLeaveType");
            grdLeaveType.DataBind();
        }

        public void clearAll()
        {
            txtLeaveType.Text = "";
        }
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                FillLeaveType();
                clearAll();
                btnSave.Visible = true;
                btnUpdate.Visible = false;
            }

        }

        protected void btnSave_Click(object sender, EventArgs e)
        {
            LeaveTypeClass.GetLeaveType = txtLeaveType.Text.Trim();
            LeaveTypeClass.InsertLeaveType();
            FillLeaveType();
            clearAll();
        }

        protected void Edit_Click(object sender, ImageClickEventArgs e)
        {
            ImageButton edit = (ImageButton)sender;
            Session["Edit"] = edit.CommandArgument;
            DataTable dt = new DataTable();
            dt=Helper.ExecutePlainQuery("[sp_EditLeaveType]@LeaveTypeID="+Session["Edit"]);
            if (dt.Rows.Count>0)
            {
                txtLeaveType.Text = dt.Rows[0]["LeaveType"].ToString();    
            }
            btnSave.Visible = false;
            btnUpdate.Visible = true;
            


        }

        protected void btnUpdate_Click(object sender, EventArgs e)
        {
            LeaveTypeClass.GetLeaveType = txtLeaveType.Text.Trim();
            LeaveTypeClass.GetLeaveTypeID = Convert.ToInt32(Session["Edit"]);
            LeaveTypeClass.UpdateLeaveType();
            FillLeaveType();
            clearAll();
            btnSave.Visible = true;
            btnUpdate.Visible = false;
        }

        protected void Delete_Click(object sender, ImageClickEventArgs e)
        {
            ImageButton delete=(ImageButton)sender;
            LeaveTypeClass.GetLeaveTypeID =Convert.ToInt32( delete.CommandArgument);
            LeaveTypeClass.DeleteLeaveType();
            FillLeaveType();
        }
    }
}