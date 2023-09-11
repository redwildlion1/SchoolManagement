using System;
using System.Data;
using static SchoolManagementSystem.Models.CommonFn;

namespace SchoolManagementSystem
{
    public partial class Login : System.Web.UI.Page
    {
        Commonfnx fn = new Commonfnx();
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void btnLogin_Click(object sender, EventArgs e)
        {
            string email = inputEmail.Value.Trim();
            string providedPassword = inputPassword.Value.Trim();
            DataTable dt = fn.Fetch("Select password from Teacher where Email = '" + email + "' ");
            string storedPassword = dt.Rows[0]["password"].ToString();
            if (email == "admin" && PasswordHasher.VerifyPassword(providedPassword, storedPassword))
            {
                Session["admin"] = email;
                Response.Redirect("Admin/AdminHome.aspx");
            }
            else if (dt.Rows.Count > 0 && PasswordHasher.VerifyPassword(providedPassword, storedPassword))
            {


                Session["staff"] = email;
                Response.Redirect("Teacher/TeacherHome.aspx");


            }
            else
            {
                lblMsg.Text = "Login Failed";
                lblMsg.ForeColor = System.Drawing.Color.Red;
            }
        }
    }
}