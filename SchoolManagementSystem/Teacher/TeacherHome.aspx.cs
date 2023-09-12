using System;
using System.Data;
using static SchoolManagementSystem.Models.CommonFn;

namespace SchoolManagementSystem.Teacher
{
    public partial class TeacherHome : System.Web.UI.Page
    {
        Commonfnx fn = new Commonfnx();
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["staff"] == null)
            {
                Response.Redirect("../Login.aspx");
            }
            else
            {
                StudentCount();
                TeacherCount();
                SubjectCount();
                ClassCount();
            }
        }
        void StudentCount()
        {
            DataTable dt = fn.Fetch("Select Count(*) from Student");
            Session["student"] = dt.Rows[0][0];
        }
        void TeacherCount()
        {
            DataTable dt = fn.Fetch("Select Count(*) from Teacher");
            Session["teacher"] = dt.Rows[0][0];
        }
        void ClassCount()
        {
            DataTable dt = fn.Fetch("Select Count(*) from Class");
            Session["class"] = dt.Rows[0][0];
        }
        void SubjectCount()
        {
            DataTable dt = fn.Fetch("Select Count(*) from Subject");
            Session["subject"] = dt.Rows[0][0];
        }
    }
}