using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Data.SqlClient;
using eLeave.DAL;
namespace eLeave.User
{
    public partial class Login : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void btnSignIn_Click(object sender, EventArgs e)
        {
            DataTable dt = new DataTable();
            dt=Helper.ExecutePlainQuery("select UserEmail,UserPassword from Users where UserEmail='" + txtEmail.Text.Trim()+ "' and UserPassword='" + txtPassword.Text.Trim()+"';");
            if (dt.Rows.Count>0)
            {
                Session["User_ID"] = dt.Rows[0]["UserEmail"].ToString();
                Response.Redirect("SubmitLeave.aspx?UserID="+Session["User_ID"]);
            }

        }
    }
}