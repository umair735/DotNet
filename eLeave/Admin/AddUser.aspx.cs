using eLeave.BAL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace eLeave.Admin
{
    public partial class AddUser : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void btnSignUp_Click(object sender, EventArgs e)
        {
            UsersClass.UserEmail = txtEmail.Text.Trim();
            UsersClass.UserName = txtUserName.Text.Trim();
            UsersClass.UserPassword = txtPassword.Text.Trim();
            UsersClass.AddUser();
        }
    }
}