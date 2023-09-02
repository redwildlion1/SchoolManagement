using System;
using System.Data;
using System.Web.UI;
using static SchoolManagementSystem.Models.CommonFn;

namespace SchoolManagementSystem.Admin
{
    public partial class ExpenseDetails : System.Web.UI.Page
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
                GetExpenseDetails();
            }
        }

        private void GetExpenseDetails()
        {
            DataTable dt = fn.Fetch("Select Row_NUMBER() over(Order by (Select 1)) as [Sr.No]," +
                " e.ExpenseId, e.ClassId, c.ClassName,e.SubjectId,s.SubjectName,e.ChargeAmount " +
                " from Expense e inner join Class c on e.ClassId = c.ClassId inner" +
                " join Subject s on e.SubjectId = s.SubjectId");
            GridView1.DataSource = dt;
            GridView1.DataBind();
        }
    }
}