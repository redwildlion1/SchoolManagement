using System;
using System.Data;
using System.Web.UI;
using static SchoolManagementSystem.Models.CommonFn;

namespace SchoolManagementSystem.Admin
{
    public partial class MarkDetails : System.Web.UI.Page
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
                GetMarks();
            }
        }

        private void GetMarks()
        {
            DataTable dt = fn.Fetch("Select ROW_NUMBER() OVER (ORDER BY(Select 1)) as [Sr.No]" +
                   ",e.ExamId, e.ClassId ,c.ClassName,e.SubjectId,s.SubjectName, e.RollNo,e.TotalMark,e.OutOfMark from Exam e " +
                   "inner join Class c on e.ClassId = c.ClassId inner join Subject s on s.SubjectId = e.SubjectId");
            GridView1.DataSource = dt;
            GridView1.DataBind();
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
        protected void btnAdd_Click(object sender, EventArgs e)
        {
            try
            {
                string classId = ddlClass.SelectedValue;
                string rollNo = txtRoll.Text.Trim();
                DataTable dt = fn.Fetch(@"Select ROW_NUMBER() OVER (ORDER BY(Select 1)) as [Sr.No]
                    ,e.ExamId, e.ClassId ,c.ClassName,e.SubjectId,s.SubjectName, e.RollNo,e.TotalMark,e.OutOfMark from Exam e 
                    inner join Class c on e.ClassId = c.ClassId inner join Subject s on s.SubjectId = e.SubjectId
                    where e.ClassId = '" + classId + "' and e.RollNo = '" + rollNo + "'");
                GridView1.DataSource = dt;
                GridView1.DataBind();
            }
            catch (Exception ex)
            {
                Response.Write("<script>alert('" + ex.Message + "')</script>");
            }
        }

        protected void GridView1_PageIndexChanging(object sender, System.Web.UI.WebControls.GridViewPageEventArgs e)
        {
            GridView1.PageIndex = e.NewPageIndex;
            GetMarks();
        }
    }




}
