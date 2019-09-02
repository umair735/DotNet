using eLeave.BAL;
using eLeave.DAL;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace eLeave.Admin
{
    public partial class Branch : System.Web.UI.Page
    {
        public void ClearAll()
        {
            txtDepartmentName.Text = "";
        }

        public void FillDeprtment()
        {
            grdDepartment.DataSource = Helper.ExecutePlainQuery("sp_FillBranch");
            grdDepartment.DataBind();
            btnUpdate.Visible = false;
            btnSave.Visible = true;

        }

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                FillDeprtment();
                ClearAll();
                btnUpdate.Visible = false;
                btnSave.Visible = true;
            }
        }

        protected void btnSave_Click(object sender, EventArgs e)
        {
            BranchClass.GetBranchName = txtDepartmentName.Text.Trim();
            BranchClass.InsertBracnh();
            FillDeprtment();
            ClearAll();

        }

        protected void Edit_Click(object sender, ImageClickEventArgs e)
        {
            ImageButton Edit = (ImageButton)sender;
            Session["Edit"] = Edit.CommandArgument;

            DataTable dt = new DataTable();
            dt = Helper.ExecutePlainQuery("[sp_EditBranch]@ID=" + Session["Edit"]);
            if (dt.Rows.Count > 0)
            {
                txtDepartmentName.Text = dt.Rows[0]["BranchName"].ToString();
            }
            btnSave.Visible = false;
            btnUpdate.Visible = true;
        }

        protected void btnUpdate_Click(object sender, EventArgs e)
        {

            BranchClass.GetBranchName = txtDepartmentName.Text.Trim();
            BranchClass.DID = Convert.ToInt32(Session["Edit"]);
            BranchClass.UpdateBracnh();

            FillDeprtment();
            ClearAll();
            btnSave.Visible = true;
            btnUpdate.Visible = false;
        }

        protected void Delete_Click(object sender, ImageClickEventArgs e)
        {
            ImageButton delete = (ImageButton)sender;
            BranchClass.DID = Convert.ToInt32(delete.CommandArgument);
            BranchClass.DeleteBracnh();
            FillDeprtment();
            ClearAll();
        }
    }
}
