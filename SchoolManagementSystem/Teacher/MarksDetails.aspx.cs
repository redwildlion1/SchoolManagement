﻿using System;

namespace SchoolManagementSystem.Teacher
{
    public partial class MarksDetails : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["staff"] == null)
            {
                Response.Redirect("../Login.aspx");
            }
        }
    }
}