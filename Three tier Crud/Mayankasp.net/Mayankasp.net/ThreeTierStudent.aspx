<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="ThreeTierStudent.aspx.cs" Inherits="Mayankasp.net.ThreeTierStudent" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
    <style type="text/css">
        .auto-style1 {
            width: 100%;
        }
        .auto-style2 {
            width: 202px;
        }
    </style>
</head>
<body>
    <form id="form1" runat="server">
        <table class="auto-style1">
            <tr>
                <td class="auto-style2">Firstname</td>
                <td>
                    <asp:TextBox ID="TextBox1" runat="server"></asp:TextBox>
                </td>
                <td>&nbsp;</td>
                <td>&nbsp;</td>
            </tr>
            <tr>
                <td class="auto-style2">Lastname</td>
                <td>
                    <asp:TextBox ID="TextBox2" runat="server"></asp:TextBox>
                </td>
                <td>&nbsp;</td>
                <td>&nbsp;</td>
            </tr>
            <tr>
                <td class="auto-style2">emailid</td>
                <td>
                    <asp:TextBox ID="TextBox3" runat="server"></asp:TextBox>
                </td>
                <td>&nbsp;</td>
                <td>&nbsp;</td>
            </tr>
            <tr>
                <td class="auto-style2">password</td>
                <td>
                    <asp:TextBox ID="TextBox4" runat="server"></asp:TextBox>
                </td>
                <td>&nbsp;</td>
                <td>&nbsp;</td>
            </tr>
            <tr>
                <td class="auto-style2">age</td>
                <td>
                    <asp:TextBox ID="TextBox5" runat="server"></asp:TextBox>
                </td>
                <td>&nbsp;</td>
                <td>&nbsp;</td>
            </tr>
            <tr>
                <td class="auto-style2">&nbsp;</td>
                <td>&nbsp;</td>
                <td>&nbsp;</td>
                <td>&nbsp;</td>
            </tr>
            <tr>
                <td class="auto-style2">&nbsp;</td>
                <td>
                    <asp:Label ID="Label1" runat="server" Text="Label"></asp:Label>
                </td>
                <td>&nbsp;</td>
                <td>&nbsp;</td>
            </tr>
            <tr>
                <td class="auto-style2">&nbsp;</td>
                <td>&nbsp;</td>
                <td>&nbsp;</td>
                <td>&nbsp;</td>
            </tr>
            <tr>
                <td class="auto-style2">&nbsp;</td>
                <td>
                    <asp:Button ID="Button1" runat="server" OnClick="Button1_Click" Text="Submit" />
                </td>
                <td>&nbsp;</td>
                <td>&nbsp;</td>
            </tr>
            <tr>
                <td class="auto-style2">&nbsp;</td>
                <td>
                    <asp:SqlDataSource ID="SqlDataSource1" runat="server" ConnectionString="<%$ ConnectionStrings:EmployeedbConnectionString %>" SelectCommand="SELECT * FROM [Comment]"></asp:SqlDataSource>
                </td>
                <td>&nbsp;</td>
                <td>&nbsp;</td>
            </tr>
        </table>
        <div>
        </div>
        <asp:GridView ID="GridView1" runat="server"  DataKeyNames="id" AutoGenerateColumns="false" OnRowDeleting="GridView1_RowDeleting" OnRowCancelingEdit="GridView1_RowCancelingEdit" OnRowEditing="GridView1_RowEditing" OnRowUpdating="GridView1_RowUpdating" BackColor="White" BorderColor="#999999" BorderStyle="None" BorderWidth="1px" CellPadding="3" GridLines="Vertical">
            <AlternatingRowStyle BackColor="#DCDCDC" />
            <FooterStyle BackColor="#CCCCCC" ForeColor="Black" />
            <HeaderStyle BackColor="#000084" Font-Bold="True" ForeColor="White" />
            <PagerStyle BackColor="#999999" ForeColor="Black" HorizontalAlign="Center" />
            <RowStyle BackColor="#EEEEEE" ForeColor="Black" />
            <SelectedRowStyle BackColor="#008A8C" Font-Bold="True" ForeColor="White" />
            <SortedAscendingCellStyle BackColor="#F1F1F1" />
            <SortedAscendingHeaderStyle BackColor="#0000A9" />
            <SortedDescendingCellStyle BackColor="#CAC9C9" />
            <SortedDescendingHeaderStyle BackColor="#000065" />
            <Columns>
                <asp:TemplateField HeaderText="FirstName">
                         
                                <ItemTemplate>
                                    <%#Eval("firstname") %>
                                </ItemTemplate>
                            <EditItemTemplate>
                                    <asp:TextBox ID="txtfname" runat="server" Text='<%#Eval("firstname") %>'></asp:TextBox>
                                </EditItemTemplate>
                            </asp:TemplateField>
                
                         <asp:TemplateField HeaderText="lastname">
                        
                                <ItemTemplate>
                                    <%#Eval("lastname") %>
                                </ItemTemplate>
                             <EditItemTemplate>
                                    <asp:TextBox ID="txtlname" runat="server" Text='<%#Eval("lastname") %>'></asp:TextBox>
                                </EditItemTemplate>
                               
                            </asp:TemplateField>
                         <asp:TemplateField HeaderText="Emailid">
                       
                                <ItemTemplate>
                                    <%#Eval("emailid") %>
                                </ItemTemplate>
                              <EditItemTemplate>
                                    <asp:TextBox ID="txtemail" runat="server" Text='<%#Eval("emailid") %>'></asp:TextBox>
                                </EditItemTemplate>     
                            </asp:TemplateField>

                        <asp:TemplateField HeaderText="Password">
                         
                                <ItemTemplate>
                                    <%#Eval("password") %>
                                </ItemTemplate>
                               <EditItemTemplate>
                                    <asp:TextBox ID="txtpassword" runat="server" Text='<%#Eval("password") %>'></asp:TextBox>
                               </EditItemTemplate>                       
                            </asp:TemplateField>

                         <asp:TemplateField HeaderText="Delete">
                                <ItemTemplate>
                                  <asp:Button ID="delete" runat="server" CommandName="Delete" text="Delete" Height="20px" Width="50px" OnClientClick="return confirm('Are you sure you want to delete selected record ?')" ToolTip="Delete" CausesValidation="false"/>
                                </ItemTemplate>
                            </asp:TemplateField>

                          <asp:TemplateField HeaderText="Edit">
                                <ItemTemplate>
                                  <asp:Button ID="Edit" runat="server" CommandName="Edit" text="Edit" Height="20px" Width="50px" OnClientClick="return confirm('Are you sure you want to Edit selected record ?')" ToolTip="Edit" CausesValidation="false"/>
                                </ItemTemplate>
                                <EditItemTemplate>
                                <asp:Button ID="Update" runat="server" Text="Update" CommandName="Update"></asp:Button>
                               <asp:Button ID="Cancel" runat="server" Text="Cancel" CommandName="Cancel"></asp:Button>
                        </EditItemTemplate>
                     </asp:TemplateField>
            </Columns>
        </asp:GridView>
    </form>
</body>
</html>
