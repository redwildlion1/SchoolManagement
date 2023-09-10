using System;
using System.Data;
using System.Web.UI;
using static SchoolManagementSystem.Models.CommonFn;

namespace SchoolManagementSystem.Admin
{
    public partial class EmpAttendanceDetails : System.Web.UI.Page
    {
        Commonfnx fn = new Commonfnx();
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["admin"] == null)
            {
                Response.Redirect("../Login.aspx");
            }
            ScriptManager.ScriptResourceMapping.AddDefinition("jquery", new ScriptResourceDefinition
            {
                Path = "~/Scripts/jquery-3.0.0.min.js",
                DebugPath = "~/Scripts/jquery-3.0.0.js",
                CdnPath = "https://code.jquery.com/jquery-3.0.0.min.js",
                CdnDebugPath = "https://code.jquery.com/jquery-3.0.0.js"
            });

            if (!IsPostBack)
            {
                GetTeacher();

            }
        }

        private void GetTeacher()
        {
            DataTable dt = fn.Fetch("Select * from Teacher");
            ddlTeacher.DataSource = dt;
            ddlTeacher.DataTextField = "Name";
            ddlTeacher.DataValueField = "TeacherId";
            ddlTeacher.DataBind();
            ddlTeacher.Items.Insert(0, "Select Teacher");
        }


        protected void btnCheckAttendance_Click(object sender, EventArgs e)
        {
            DateTime date = Convert.ToDateTime(txtMonth.Text);
            DataTable dt = fn.Fetch("Select Row_NUMBER() over(Order by (Select 1)) as [Sr.No], t.Name, ta.Status, ta.Date from TeacherAttendance ta " +
                                    "inner join Teacher t on t.TeacherId = ta.TeacherId where" +
                                    " DATEPART(yy, Date) = '" + date.Year + "' and DATEPART(M, Date) = '" + date.Month + "'" +
                                    "and ta.TeacherId = '" + ddlTeacher.SelectedValue + "' ");
            GridView1.DataSource = dt;
            GridView1.DataBind();
        }
    }
}