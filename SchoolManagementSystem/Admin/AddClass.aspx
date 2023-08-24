<%@ Page Title="" Language="C#" MasterPageFile="~/Admin/AdminMst.Master" AutoEventWireup="true" CodeBehind="AddClass.aspx.cs" Inherits="SchoolManagementSystem.Admin.WebForm1" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">

 <div style=" width:100%; height:720px; background-repeat: no-repeat; background-size:cover;background-attachment:fixed;">
    <div class="container p-md-4 p-sm-4">
        <asp:Label ID="lblMsg" runat="server" Text=""></asp:Label>
    </div>
      <h3 class="text-center">New Class</h3>

     <div class="row mb-3 mr-lg-5 ml-lg-5 mt-md-5">
         <div class="col-md-6">
             <label for="txtClass">Class Name</label>
             <asp:TextBox ID="txtClass" runat="server" CssClass="form-control" placeholder="Enter Class Name" required="True" Width="100%"></asp:TextBox>
         </div>
     </div>

     <div class="row mb-3 mr-lg-5 ml-lg-5 ">
         <div class="col-md-3 col-md-offset-2 mb-3 ">
             <asp:Button ID="btnAdd" runat="server" Text="Add Class" CssClass="btn btn-primary btn-block" BackColor="#5558C9" OnClick="btnAdd_Click" Width="100%" />
         </div>
     </div>

      <div class="row mb-3 mr-lg-5 ml-lg-5 mt-md-5">
     <div class="col-md-6">
         <asp:GridView ID="GridView1" runat="server" CssClass="table table-hover table-bordered" DataKeyNames="ClassId" AutoGenerateColumns="False" 
             EmptyDataText="No Record to display!" OnPageIndexChanging="GridView1_PageIndexChanging" OnRowCancelingEdit="GridView1_RowCancelingEdit" 
             OnRowEditing="GridView1_RowEditing" OnRowUpdating="GridView1_RowUpdating"  AllowPaging="true" PageSize="4">
             <Columns>
                 <asp:BoundField DataField="Sr.No" HeaderText="Sr.No" ReadOnly="True">
                 <ItemStyle HorizontalAlign="Center" />
                 </asp:BoundField>
                 <asp:TemplateField HeaderText="Class">
                     <EditItemTemplate>
                         <asp:TextBox ID="txtClassEdit" runat="server" Text='<%# Eval("ClassName") %>' CssClass="form-control"></asp:TextBox>
                     </EditItemTemplate>
                     <ItemTemplate>
                         <asp:Label ID="lblClassName" runat="server" Text='<%# Eval("ClassName") %>'></asp:Label>
                     </ItemTemplate>
                     <ItemStyle HorizontalAlign="Center" />
                 </asp:TemplateField>
                 <asp:CommandField CausesValidation="False" HeaderText="Operation" ShowEditButton="True" />
             </Columns>
             <HeaderStyle BackColor="#5558C9" ForeColor="White"/>
         </asp:GridView>
     </div>
    </div>

</div>


</asp:Content>
