using System;
using System.Data;
using System.Web.UI;
using System.Web.UI.WebControls;
using static SchoolManagementSystem.Models.CommonFn;

namespace SchoolManagementSystem.Admin
{
    public partial class Student : System.Web.UI.Page
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
                GetStudents();
            }
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
                if (ddlGender.SelectedValue != "0")
                {
                    string rollNo = txtRoll.Text.Trim();
                    DataTable dt = fn.Fetch("Select * from Student where ClassId = '" + ddlClass.SelectedValue + "' and RollNo = '" + rollNo + "'");
                    if (dt.Rows.Count == 0)
                    {
                        string query = "Insert into Student values ('" + txtName.Text.Trim() + "'," +
                            " '" + txtDoB.Text.Trim() + "', '" + ddlGender.SelectedValue + "', '" + txtMobile.Text.Trim() + "'," +
                            " '" + txtRoll.Text.Trim() + "','" + txtAddress.Text.Trim() + "', '" + ddlClass.SelectedValue + "') ";
                        fn.Query(query);
                        lblMsg.Text = "Inserted Succesfully!";
                        lblMsg.CssClass = "alert alert-success";
                        ddlGender.SelectedIndex = 0;
                        txtName.Text = string.Empty;
                        txtDoB.Text = string.Empty;
                        txtMobile.Text = string.Empty;
                        txtRoll.Text = string.Empty;
                        txtAddress.Text = string.Empty;
                        ddlClass.SelectedIndex = 0;
                        GetStudents();

                    }
                    else
                    {
                        lblMsg.Text = "Entered  Roll No. <b>'" + rollNo + "'<b>! already exists for selected Class";
                        lblMsg.CssClass = "alert alert-danger";
                    }

                }
                else
                {
                    lblMsg.Text = "Gender is required";
                    lblMsg.CssClass = "alert alert-danger";
                }
            }
            catch (Exception ex)
            {
                Response.Write("<script>alert('" + ex.Message + "')</script>");
            }
        }

        private void GetStudents()
        {
            DataTable dt = fn.Fetch(@"Select ROW_NUMBER() OVER(ORDER BY (SELECT 1)) as [Sr.No], s.StudentId,
                                    s.[Name], DOB, s.Gender,s.Mobile,s.RollNo,s.[Adress], c.ClassId, C.ClassName from Student s inner join Class c on c.ClassId = s.ClassId");
            GridView1.DataSource = dt;
            GridView1.DataBind();
        }

        protected void GridView1_PageIndexChanging(object sender, System.Web.UI.WebControls.GridViewPageEventArgs e)
        {
            GridView1.PageIndex = e.NewPageIndex;
            GetStudents();
        }

        protected void GridView1_RowCancelingEdit(object sender, System.Web.UI.WebControls.GridViewCancelEditEventArgs e)
        {
            GridView1.PageIndex = -1;
            GetStudents();
        }

        protected void GridView1_RowEditing(object sender, System.Web.UI.WebControls.GridViewEditEventArgs e)
        {
            GridView1.PageIndex = e.NewEditIndex;
            GetStudents();
        }

        protected void GridView1_RowUpdating(object sender, System.Web.UI.WebControls.GridViewUpdateEventArgs e)
        {
            try
            {
                GridViewRow row = GridView1.Rows[e.RowIndex];
                int studentId = Convert.ToInt32(GridView1.DataKeys[e.RowIndex].Values[0]);
                string name = (row.FindControl("txtName") as TextBox).Text;
                string mobile = (row.FindControl("txtMobile") as TextBox).Text;
                string rollNo = (row.FindControl("txtRollNo") as TextBox).Text;
                string adress = (row.FindControl("txtAdress") as TextBox).Text;
                string classId = ((DropDownList)GridView1.Rows[e.RowIndex].Cells[4].FindControl("ddlClass")).SelectedValue;
                fn.Query("Update Student set Name = '" + name.Trim() + "', Mobile = '" + mobile.Trim() + "', " +
                    "Adress = '" + adress.Trim() + "', RollNo = '" + rollNo.Trim() + "', ClassId = '" + classId + "' where StudentId = '" + studentId + "' ");
                lblMsg.Text = "Student Updated Succesfully!";
                lblMsg.CssClass = "alert alert-success";
                GridView1.EditIndex = -1;
                GetStudents();
            }
            catch (Exception ex)
            {
                Response.Write("<script>alert('" + ex.Message + "')</script>");
            }
        }

        protected void GridView1_RowDataBound(object sender, GridViewRowEventArgs e)
        {
            if (e.Row.RowType == DataControlRowType.DataRow && GridView1.EditIndex == e.Row.RowIndex)
            {
                DropDownList ddlClass = (DropDownList)e.Row.FindControl("ddlClass");
                DataTable dt = fn.Fetch("Select * from Class ");
                ddlClass.DataSource = dt;
                ddlClass.DataTextField = "ClassName";
                ddlClass.DataValueField = "ClassId";
                ddlClass.DataBind();
                ddlClass.Items.Insert(0, "Select Class");
                string selectedClass = DataBinder.Eval(e.Row.DataItem, "ClassName").ToString();
                ddlClass.Items.FindByText(selectedClass).Selected = true;



            }
        }
    }
}

