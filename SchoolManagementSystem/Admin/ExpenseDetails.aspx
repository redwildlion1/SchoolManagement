<%@ Page Title="" Language="C#" MasterPageFile="~/Admin/AdminMst.Master" AutoEventWireup="true" CodeBehind="ExpenseDetails.aspx.cs" Inherits="SchoolManagementSystem.Admin.ExpenseDetails" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">


<script type="text/javascript" src="https://ajax.googleapis.com/ajax/libs/jquery/3.6.0/jquery.min.js"></script>
<script type="text/javascript" src="https://cdn.datatables.net/1.11.5/js/jquery.dataTables.min.js"></script>
<link href="https://cdn.datatables.net/1.11.5/css/jquery.dataTables.min.css" rel="stylesheet" type="text/css" />

<script type="text/javascript">
    $(document).ready(function () {
        $('#<%=GridView1.ClientID %>').prepend($("<thead></thead>").append($(this).find("tr:first"))).DataTable({ "paging": true, "ordering": true, "searching": true });
    });
</script>


</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">

    <div style="width: 100%; height: 720px; background-repeat: no-repeat; background-size: cover; background-attachment: fixed;">

        <h3 class="text-center">Expense Details</h3>
        <div class="row mb-3 mr-lg-5 ml-lg-5 ">
            <div class="col-md-12">
                <asp:GridView ID="GridView1" runat="server" CssClass="table table-hover table-bordered" EmptyDataText="No record to display!"
                    AutoGenerateColumns="False">
                    <columns>
                        <asp:BoundField DataField="Sr.No" HeaderText="Sr.No">
                            <itemstyle horizontalalign="Center" />
                        </asp:BoundField>
                        <asp:BoundField DataField="ClassName" HeaderText="Class">
                            <itemstyle horizontalalign="Center" />
                        </asp:BoundField>
                        <asp:BoundField DataField="SubjectName" HeaderText="Subject">
                            <itemstyle horizontalalign="Center" />
                        </asp:BoundField>
                        <asp:BoundField DataField="ChargeAmount" HeaderText="Charge Per Lecture">
                            <itemstyle horizontalalign="Center" />
                        </asp:BoundField>
                    </columns>
                    <headerstyle backcolor="#5558C9" forecolor="White" />
                </asp:GridView>
            </div>

        </div>
    </div>

</asp:Content>
