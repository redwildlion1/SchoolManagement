<%@ Page Title="" Language="C#" MasterPageFile="~/Admin/AdminMst.Master" AutoEventWireup="true" CodeBehind="EmployeeAttendance.aspx.cs" Inherits="SchoolManagementSystem.Admin.EmployeeAttendance" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">

    <div style="width: 100%; height: 720px; background-repeat: no-repeat; background-size: cover; background-attachment: fixed;">
        <div class="container p-md-4 p-sm-4">
            <asp:Label ID="lblMsg" runat="server" Text=""></asp:Label>
        </div>
        <div class="text-right ml-auto">
            <asp:ScriptManager ID="ScriptManager1" runat="server"></asp:ScriptManager>
            <asp:UpdatePanel ID="UpdatePanel1" runat="server">
                <ContentTemplate>
                    <asp:Timer ID="Timer1" runat="server" OnTick="Timer1_Tick" Interval="1000"></asp:Timer>
                    <asp:Label ID="lblTime" runat="server" Font-Bold="true"></asp:Label>
                </ContentTemplate>
            </asp:UpdatePanel>
        </div>
        <h3 class="text-center">Teacher's Attendance</h3>

        <div class="row mb-3 mr-lg-5 ml-lg-5 ">
            <div class="col-md-12">
                <asp:GridView ID="GridView1" runat="server" CssClass="table table-hover table-bordered"
                    EmptyDataText="No Record to display!">
                    <Columns>

                        <asp:TemplateField HeaderText="Class">
                            <ItemTemplate>
                                <div class="form-check form-check-inline">
                                    <asp:RadioButton ID="RadioButton1" runat="server" Text="Present" Checked="true" GroupName="attendance"
                                        CssClass="form-check-input" />
                                </div>
                                <div class="form-check form-check-inline">
                                    <asp:RadioButton ID="RadioButton2" runat="server" Text="Absent" GroupName="attendance" CssClass="form-check-input" />
                                </div>
                            </ItemTemplate>
                            <ItemStyle HorizontalAlign="Center" />
                        </asp:TemplateField>
                    </Columns>
                    <HeaderStyle BackColor="#5558C9" ForeColor="White" />
                </asp:GridView>
            </div>
        </div>

        <div class="row mb-3 mr-lg-5 ml-lg-5 ">
            <div class="col-md-6 col-md-offset-2 col-lg-4 col-xl-3 mb-3 ">
                <asp:Button ID="btnMarkAttendance" runat="server" Text="Mark Attendace" CssClass="btn btn-primary btn-block"
                    BackColor="#5558C9" OnClick="btnMarkAttendance_Click" Width="100%" />
            </div>
        </div>

    </div>

</asp:Content>
