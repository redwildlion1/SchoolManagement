<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="MarksDetailUserControl.ascx.cs" Inherits="SchoolManagementSystem.MarksDetailUserControl" %>


  <div style="width: 100%; height: 720px; background-repeat: no-repeat; background-size: cover; background-attachment: fixed;">
      <div class="container p-md-4 p-sm-4">
          <asp:Label ID="lblMsg" runat="server" Text=""></asp:Label>
      </div>
      <h3 class="text-center">Mark Details</h3>

      <div class="row mb-3 mr-lg-5 ml-lg-5 mt-md-5">
          <div class="col-md-6">
              <label for="ddlClass">Class</label>
              <asp:DropDownList ID="ddlClass" runat="server" CssClass="form-control" AutoPostBack="true" ></asp:DropDownList>
              <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ErrorMessage="Class is required"
                  ControlToValidate="ddlClass" Display="Dynamic" ForeColor="Red" InitialValue="Select Class" SetFocusOnError="True"></asp:RequiredFieldValidator>
          </div>
      </div>
      <div class="row mb-3 mr-lg-5 ml-lg-5 mt-md-5">
          <div class="col-md-6">
              <label for="txtRoll">
                  Student Roll Number 
              </label>
              <asp:TextBox ID="txtRoll" runat="server" CssClass="form-control" placeholder="Enter Student Roll Number" required="True"></asp:TextBox>
          </div>
      </div>

  <div class="row mb-3 mr-lg-5 ml-lg-5 ">
      <div class="col-md-3 col-md-offset-2 mb-3 ">
          <asp:Button ID="btnAdd" runat="server" Text="Get Marks" CssClass="btn btn-primary btn-block" BackColor="#5558C9" OnClick="btnAdd_Click" />
      </div>
  </div>

  <div class="row mb-3 mr-lg-5 ml-lg-5 mt-md-5">
      <div class="col-md-12">
          <asp:GridView ID="GridView1" runat="server" CssClass="table table-hover table-bordered" EmptyDataText="No record to display!"
              AutoGenerateColumns="False" AllowPaging="true" PageSize="8" OnPageIndexChanging="GridView1_PageIndexChanging">
              <Columns>
                  <asp:BoundField DataField="Sr.No" HeaderText="Sr.No">
                      <ItemStyle HorizontalAlign="Center" />
                  </asp:BoundField>

                  <asp:BoundField DataField="ExamId" HeaderText="ExamId">
                      <ItemStyle HorizontalAlign="Center" />
                  </asp:BoundField>

                  <asp:BoundField DataField="ClassName" HeaderText="Class">
                      <ItemStyle HorizontalAlign="Center" />
                  </asp:BoundField>

                  <asp:BoundField DataField="SubjectName" HeaderText="Subject">
                      <ItemStyle HorizontalAlign="Center" />
                  </asp:BoundField>

                  <asp:BoundField DataField="RollNo" HeaderText="Roll Number">
                      <ItemStyle HorizontalAlign="Center" />
                  </asp:BoundField>

                  <asp:BoundField DataField="TotalMark" HeaderText="Total Mark">
                      <ItemStyle HorizontalAlign="Center" />
                  </asp:BoundField>

                  <asp:BoundField DataField="OutOfMark" HeaderText="Out of Mark">
                      <ItemStyle HorizontalAlign="Center" />
                  </asp:BoundField>


              </Columns>
              <HeaderStyle BackColor="#5558C9" ForeColor="White" />
          </asp:GridView>
      </div>
  </div>

  </div>
