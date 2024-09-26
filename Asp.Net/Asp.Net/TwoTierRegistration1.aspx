<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="TwoTierRegistration1.aspx.cs" Inherits="Asp.Net.TwoTierRegistration1" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
    <style type="text/css">
        .auto-style1 {
            width: 100%;
        }
        .auto-style3 {
            width: 197px;
        }
        .auto-style4 {
            width: 93px;
        }
    </style>
</head>
<body>
    <form id="form1" runat="server">
        &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<br />
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<h1>Employee List</h1> <br />
        <br />
        <table class="auto-style1">
            <tr>
                <td class="auto-style4">FirstName</td>
                <td class="auto-style3">
                    <asp:TextBox ID="TextBox1" runat="server"></asp:TextBox>
                </td>
            </tr>
            <tr>
                <td class="auto-style4">LastName</td>
                <td class="auto-style3">
                    <asp:TextBox ID="TextBox2" runat="server"></asp:TextBox>
                </td>
            </tr>
            <tr>
                <td class="auto-style4">Gender</td>
                 <td class="auto-style3">
                    <asp:RadioButton ID="rdMale" runat="server" Text="Male" GroupName="gender" />
               
                    <asp:RadioButton ID="rdfemale" runat="server" Text="female"  GroupName="gender"/>
                </td>
            </tr>
            <tr>
                <td class="auto-style4">Salary</td>
                <td class="auto-style3">
                    <asp:TextBox ID="TextBox3" runat="server"></asp:TextBox>
                </td>
            </tr>
            <tr>
                <td class="auto-style4">City</td>
                <td class="auto-style3">
                    <asp:TextBox ID="TextBox4" runat="server" ></asp:TextBox>
                </td>
            </tr>
            <tr>
                <td class="auto-style4">MobileNumber</td>
                <td class="auto-style3">
                    <asp:TextBox ID="TextBox5" runat="server" ></asp:TextBox>
                </td>
            </tr>
            <tr>
                <td class="auto-style4">CompanyId</td>
                <td class="auto-style3">
                    <asp:TextBox ID="TextBox6" runat="server"></asp:TextBox>
                </td>
            </tr>
            <tr>
                <td class="auto-style4">BirthDate</td>
                <td class="auto-style3">
                    <asp:TextBox ID="TextBox7" runat="server" Type ="date"></asp:TextBox>
                </td>
            </tr>
            <tr>
                <td class="auto-style4">JoiningDate</td>
                <td class="auto-style3">
                    <asp:TextBox ID="TextBox8" runat="server" Type ="date"></asp:TextBox>
                </td>
            </tr>
            <tr>
                <td class="auto-style4">&nbsp;</td>
                <td class="auto-style3">&nbsp;</td>
            </tr>
            <tr>
                <td class="auto-style4">&nbsp;</td>
                <td class="auto-style3">
                    <asp:Label ID="Label1" runat="server" Text="Label"></asp:Label>
                </td>
            </tr>
            <tr>
                <td class="auto-style4">&nbsp;</td>
                <td class="auto-style3">
                    <asp:Button ID="Button1" runat="server" OnClick="Button1_Click" Text="Submit" />
                </td>
            </tr>
        </table>
        <asp:GridView ID="GridView1" runat="server" DataKeyNames="id" AutoGenerateColumns="false" OnRowCancelingEdit="GridView1_RowCancelingEdit" OnRowEditing="GridView1_RowEditing" OnRowUpdating="GridView1_RowUpdating" OnRowDeleting="GridView1_RowDeleting" BackColor="#DEBA84" BorderColor="#DEBA84" BorderStyle="None" BorderWidth="1px" CellPadding="3" CellSpacing="2" Width="1162px" OnSelectedIndexChanged="GridView1_SelectedIndexChanged" >
            <FooterStyle BackColor="#F7DFB5" ForeColor="#8C4510" />
            <HeaderStyle BackColor="#A55129" Font-Bold="True" ForeColor="White" />
            <PagerStyle ForeColor="#8C4510" HorizontalAlign="Center" />
            <RowStyle BackColor="#FFF7E7" ForeColor="#8C4510" />
            <SelectedRowStyle BackColor="#738A9C" Font-Bold="True" ForeColor="White" />
            <SortedAscendingCellStyle BackColor="#FFF1D4" />
            <SortedAscendingHeaderStyle BackColor="#B95C30" />
            <SortedDescendingCellStyle BackColor="#F1E5CE" />
            <SortedDescendingHeaderStyle BackColor="#93451F" />

            <Columns>
           <asp:TemplateField HeaderText="FirstName">
               <ItemTemplate>
                   <%#Eval("FirstName")%>
               </ItemTemplate>
               <EditItemTemplate>
                   <asp:TextBox ID="txtFirstName" runat="server" Text='<%#Eval("FirstName") %>'></asp:TextBox>
               </EditItemTemplate>
           </asp:TemplateField>

                <asp:TemplateField HeaderText="LastName">
                    <ItemTemplate>
                        <%# Eval("LastName") %>
                    </ItemTemplate>
                    <EditItemTemplate>
                         <asp:TextBox ID="txtLastName" runat="server" Text='<%#Eval("LastName") %>'></asp:TextBox>
                    </EditItemTemplate>
                </asp:TemplateField>

                <asp:TemplateField HeaderText="Gender">
                    <ItemTemplate>
                        <%#Eval("Gender") %>
                    </ItemTemplate>
                </asp:TemplateField>

                <asp:TemplateField HeaderText="Salary">
                    <ItemTemplate>
                        <%#Eval("Salary") %>
                    </ItemTemplate>
                     <EditItemTemplate>
                         <asp:TextBox ID="txtSalary" runat="server" Text='<%#Eval("Salary") %>'></asp:TextBox>
                    </EditItemTemplate>
                </asp:TemplateField>

                 <asp:TemplateField HeaderText="City">
                    <ItemTemplate>
                        <%#Eval("City") %>
                    </ItemTemplate>
                     <EditItemTemplate>
                         <asp:TextBox ID="txtCity" runat="server" Text='<%#Eval("City") %>'></asp:TextBox>
                    </EditItemTemplate>
                </asp:TemplateField>

                 <asp:TemplateField HeaderText="MobileNumber">
                    <ItemTemplate>
                        <%#Eval("MobileNumber") %>
                    </ItemTemplate>
                     <EditItemTemplate>
                         <asp:TextBox ID="txtMobileNumber" runat="server" Text='<%#Eval("MobileNumber") %>'></asp:TextBox>
                    </EditItemTemplate>
                     </asp:TemplateField>

                      <asp:TemplateField HeaderText="CompanyId">
                         <ItemTemplate>
                        <%#Eval("CompanyId") %>
                      </ItemTemplate>
                     </asp:TemplateField>

                   <asp:TemplateField HeaderText="BirthDate">
                    <ItemTemplate>
                        <%#Eval("BirthDate") %>
                    </ItemTemplate>
                </asp:TemplateField>

                <asp:TemplateField HeaderText="JoiningDate">
                    <ItemTemplate>
                        <%#Eval("JoiningDate") %>
                    </ItemTemplate>
                </asp:TemplateField>

               <asp:TemplateField HeaderText="Delete">
                     <ItemTemplate>
                      <asp:Button ID="Imgdelete" runat="server" CommandName="Delete" text="Delete" Height="28px" Width="90px" 
                          OnClientClick="return confirm('Are you sure you want to delete selected record ?')" ToolTip="Delete" CausesValidation="false"/>
                      </ItemTemplate>
                   </asp:TemplateField>
                <asp:TemplateField HeaderText="Edit">
                    <ItemTemplate>
                  <asp:Button ID="ImgEdit" runat="server" CommandName="Edit" text="Edit" Height="28px" Width="90px" 
                          OnClientClick="return confirm('Are you sure you want to Edit selected record ?')" ToolTip="Edit" CausesValidation="false"/>

                    </ItemTemplate>

                    <EditItemTemplate>

                         <asp:Button ID="lnkUpdate" runat="server" Text="Update"  CommandName="Update" ToolTip="Update" CausesValidation="false"></asp:Button>
                              
                              
                         <asp:Button ID="lnkCancel" runat="server" Text="Cancel"  CommandName="Cancel" ToolTip="Update" CausesValidation="false"></asp:Button>

                    </EditItemTemplate>
                </asp:TemplateField>
                   
            </Columns>
        </asp:GridView>
        
    </form>
</body>
</html>
