﻿using System;

namespace SchoolManagementSystem.Admin
{
    public partial class StudentAttendanceDetails : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["admin"] == null)
            {
                Response.Redirect("../Login.aspx");
            }
        }
    }
}