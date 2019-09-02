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
    public partial class Template : System.Web.UI.Page
    {
        public void Fill_ddLeaveType()
        {
            ddLeaveType.DataSource = Helper.ExecutePlainQuery("FillLeaveType");
            ddLeaveType.DataTextField = "LeaveType";
            ddLeaveType.DataValueField = "LeaveTypeID";
            ddLeaveType.DataBind();
        }

        public void FillTemplate()
        {
            grdTemplate.DataSource = Helper.ExecutePlainQuery("FillTemplate");
            grdTemplate.DataBind();
        
        }

        public void ClearAll()
        {
            txtTemplate.Text = "";
            ddLeaveType.SelectedIndex = 0;
        }
        
        
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                FillTemplate();
                Fill_ddLeaveType();
                btnSave.Visible = true;
                btnUpdate.Visible = false;
            }
            
        }

        protected void btnSave_Click(object sender, EventArgs e)
        {
            TemplateClass.GetTemplate = txtTemplate.Text.Trim();
            TemplateClass.GetLeaveTypeID =Convert.ToInt32( ddLeaveType.SelectedValue);
            TemplateClass.InsertTemplate();
            FillTemplate();
            ClearAll();
            btnSave.Visible = true;
            btnUpdate.Visible = false;
        }

        protected void Delete_Click(object sender, ImageClickEventArgs e)
        {
            ImageButton delete = (ImageButton)sender;
            TemplateClass.GetTemplateID =Convert.ToInt32(delete.CommandArgument);
            TemplateClass.DeleteTemplate();
            FillTemplate();
            ClearAll();
            btnSave.Visible = true;
            btnUpdate.Visible = false;
        }

        protected void Edit_Click(object sender, ImageClickEventArgs e)
        {
            ImageButton edit = (ImageButton)sender;
            Session["Edit"] = edit.CommandArgument;
            TemplateClass.GetTemplateID =Convert.ToInt32( Session["Edit"]);
            DataTable dt = new DataTable();
            dt = Helper.ExecutePlainQuery("select * from Template where TemplateID="+Session["Edit"]);                        
            ddLeaveType.SelectedValue = dt.Rows[0]["LeaveTypeID"].ToString();
            txtTemplate.Text = dt.Rows[0]["Template"].ToString();
            btnSave.Visible = false;
            btnUpdate.Visible = true;
        }

        protected void btnUpdate_Click(object sender, EventArgs e)
        {
            TemplateClass.GetTemplateID = Convert.ToInt32(Session["Edit"]);
            TemplateClass.GetTemplate = txtTemplate.Text.Trim();
            TemplateClass.GetLeaveTypeID =Convert.ToInt32( ddLeaveType.SelectedValue);
            TemplateClass.UpdateTemplate();
            FillTemplate();
            ClearAll();
            btnSave.Visible = true;
            btnUpdate.Visible = false;
        }



    }
}