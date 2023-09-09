using System;
using System.Data;
using System.Web.UI;
using static SchoolManagementSystem.Models.CommonFn;

namespace SchoolManagementSystem
{

    public partial class WebUserControl1 : System.Web.UI.UserControl
    {
        Commonfnx fn = new Commonfnx();
        protected void Page_Load(object sender, EventArgs e)
        {
            ScriptManager.ScriptResourceMapping.AddDefinition("jquery", new ScriptResourceDefinition
            {
                Path = "~/Scripts/jquery-3.0.0.min.js",
                DebugPath = "~/Scripts/jquery-3.0.0.js",
                CdnPath = "https://code.jquery.com/jquery-3.0.0.min.js",
                CdnDebugPath = "https://code.jquery.com/jquery-3.0.0.js"
            });
            if (!IsPostBack)
            {
                GetClass();
            }
        }
        protected void ddlClass_SelectedIndexChanged(object sender, EventArgs e)
        {
            string classId = ddlClass.SelectedValue;
            DataTable dt = fn.Fetch("Select * from Subject where ClassId = '" + classId + "' ");
            ddlSubject.DataSource = dt;
            ddlSubject.DataTextField = "SubjectName";
            ddlSubject.DataValueField = "SubjectId";
            ddlSubject.DataBind();
            ddlSubject.Items.Insert(0, "Select Subject");

        }

        private void GetClass()
        {
            DataTable dt = fn.Fetch("Select * from Class");
            ddlClass.DataSource = dt;
            ddlClass.DataTextField = "ClassName";
            ddlClass.DataValueField = "ClassId";
            ddlClass.DataBind();
            ddlClass.Items.Insert(0, "Select Class");
        }

        protected void btnCheckAttendance_Click(object sender, EventArgs e)
        {
            DataTable dt;
            DateTime date = Convert.ToDateTime(txtMonth.Text);
            if (ddlSubject.SelectedValue == "Select Subject")
            {
                dt = fn.Fetch("Select Row_NUMBER() over(Order by (Select 1)) as [Sr.No], s.Name, sa.Status, sa.Date from StudentAttendance sa " +
                              "inner join Student s on s.RollNo = sa.RollNo where sa.ClassId = '" + ddlClass.SelectedValue + "'" +
                              " and  sa.RollNo = '" + txtRollNo.Text.Trim() + "' and DATEPART(yy, Date) = '" + date.Year + "'" +
                              " and DATEPART(M, Date) = '" + date.Month + "' and sa.Status = 1");

            }
            else
            {
                dt = fn.Fetch("Select Row_NUMBER() over(Order by (Select 1)) as [Sr.No], s.Name, sa.Status, sa.Date from StudentAttendance sa " +
                               "inner join Student s on s.RollNo = sa.RollNo where sa.ClassId = '" + ddlClass.SelectedValue + "'" +
                               " and  sa.RollNo = '" + txtRollNo.Text.Trim() + "'and sa.SubjectId = '" + ddlSubject.SelectedValue + "'" +
                               " and DATEPART(yy, Date) = '" + date.Year + "'" +
                               " and DATEPART(M, Date) = '" + date.Month + "' and sa.Status = 1");
            }
            GridView1.DataSource = dt;
            GridView1.DataBind();
        }
    }
}