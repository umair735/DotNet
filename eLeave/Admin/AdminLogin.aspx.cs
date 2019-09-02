using eLeave.DAL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using eLeave.BAL;
using System.Data;


namespace eLeave.Admin
{
    public partial class AdminLogin : System.Web.UI.Page
    {
       // Helper obj = new Helper();

        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void btnLogin_Click(object sender, EventArgs e)
        {
            AdminClass.GetEmail= txtemail.Text.Trim();
            AdminClass.GetPassword = txtpass.Text.Trim();
            DataTable dt = new DataTable();
            dt = AdminClass.AdminLogin(); ;
            if (dt.Rows.Count > 0)
            {
                Response.Redirect("Branch.aspx");
            }
            else
            {
                lblmsg.Text = "Invalid User Name or Password";
            }
        }
    }
}