<%@ Page Title="" Language="C#" MasterPageFile="~/Admin/AdminMst.Master" AutoEventWireup="true" CodeBehind="Subject.aspx.cs" Inherits="SchoolManagementSystem.Admin.Subject" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">

        <%@ Register TagPrefix="asp" Namespace="System.Web.UI" Assembly="System.Web.Extensions" %>
<asp:ScriptManager ID="ScriptManager1" runat="server" />

 <div style=" width:100%; height:720px; background-repeat: no-repeat; background-size:cover;background-attachment:fixed;">
    <div class="container p-md-4 p-sm-4">
        <asp:Label ID="lblMsg" runat="server" Text=""></asp:Label>
    </div>
      <h3 class="text-center">New Subject</h3>

          <div class="row mb-3 mr-lg-5 ml-lg-5 mt-md-5">
         <div class="col-md-6">
             <label for="txtClass">Class Name</label>
             <asp:DropDownList ID="ddlClass" runat="server" CssClass="form-control"></asp:DropDownList>
             <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ErrorMessage="Class is required" 
                 ControlToValidate="ddlClass" Display="Dynamic" FoSubjectreColor="Red" InitialValue="Select Class" SetFocusOnError="True"></asp:RequiredFieldValidator>
         </div>
     </div>
     <div class="row mb-3 mr-lg-5 ml-lg-5 mt-md-5">
         <div class="col-md-6">
             <label for="txtSubject">Subject
             </label>
             <asp:TextBox ID="txtSubject" runat="server" CssClass="form-control" placeholder="Enter Subject"  required="True" ></asp:TextBox>
         </div>
     </div>

     <div class="row mb-3 mr-lg-5 ml-lg-5 ">
         <div class="col-md-3 col-md-offset-2 mb-3 ">
             <asp:Button ID="btnAdd" runat="server" Text="Add Subject" CssClass="btn btn-primary btn-block" BackColor="#5558C9" OnClick="btnAdd_Click"  />
         </div>
     </div>

      <div class="row mb-3 mr-lg-5 ml-lg-5 mt-md-5">
     <div class="col-md-6">
         <asp:GridView ID="GridView1" runat="server" CssClass="table table-hover table-bordered" EmptyDataText="No record to display!" 
             AutoGenerateColumns="False" AllowPaging="True" PageSize="4" OnPageIndexChanging="GridView1_PageIndexChanging" DataKeyNames="SubjectId"
             OnRowCancelingEdit="GridView1_RowCancelingEdit"  OnRowEditing="GridView1_RowEditing"
             OnRowUpdating="GridView1_RowUpdating">
             <Columns>
                 <asp:BoundField DataField="Sr.No" HeaderText="Sr.No" ReadOnly="True">
                 <ItemStyle HorizontalAlign="Center" />
                 </asp:BoundField>
                 <asp:TemplateField HeaderText="Class">
                     <EditItemTemplate>
                         <asp:DropDownList ID="DropDownList1" runat="server" DataSourceID="SqlDataSource1" 
                             DataTextField="ClassName" DataValueField="ClassId" SelectedValue='<%# Eval("ClassId") %>' CssClass="form-control">
                         </asp:DropDownList>
                         <asp:SqlDataSource ID="SqlDataSource1" runat="server" ConnectionString="<%$ ConnectionStrings:SchoolCS %>" SelectCommand="SELECT * FROM [Class]"></asp:SqlDataSource>
                     </EditItemTemplate>
                     <ItemTemplate>
                         <asp:Label ID="Label2" runat="server" Text='<%# Eval("ClassName") %>'></asp:Label>
                     </ItemTemplate>
                     <ItemStyle HorizontalAlign="Center" />
                 </asp:TemplateField>
                 <asp:TemplateField HeaderText="Subject">
                     <EditItemTemplate>
                         <asp:TextBox ID="TextBox1" runat="server" Text='<%# Eval("SubjectName") %>' CssClass="form-control"></asp:TextBox>
                     </EditItemTemplate>
                     <ItemTemplate>
                         <asp:Label ID="Label1" runat="server" Text='<%# Eval("SubjectName") %>'></asp:Label>
                     </ItemTemplate>
                     <ItemStyle HorizontalAlign="Center" />
                 </asp:TemplateField>
                 <asp:CommandField CausesValidation="false" HeaderText="Operation" ShowEditButton="True">
                 <ItemStyle HorizontalAlign="Center" />
                 </asp:CommandField>
             </Columns>
              <HeaderStyle BackColor="#5558C9" ForeColor="White"/>
         </asp:GridView>
     </div>
    </div>

</div>

</asp:Content>
