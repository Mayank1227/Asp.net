<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="DatalistControlExample.aspx.cs" Inherits="Asp.Net.DatalistControlExample" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>

 <style>      
        .itemstyle {      
              border-collapse: collapse;      
              background-color: aquamarine;      
              border: 1px solid red;      
              border-radius: 8px;      
              padding:4px;      
        }      
        tr {      
            height:40px;      
        }      
        table {      
              width: initial;      
        }      
    </style>      
</head>
<body>
    
    <form id="form1" runat="server">
       <div>      
                <asp:DataList ID="dl1" runat="server"      
     RepeatDirection="Horizontal"      
      RepeatColumns="3"      
       OnEditCommand="dl1_EditCommand"      
        OnCancelCommand="dl1_CancelCommand"      
         OnUpdateCommand="dl1_updateCommand"      
          OnDeleteCommand="dl1_DeleteCommand" >      
                    <HeaderTemplate>      
                        <table>      
                            <tr>      
                                <td>      
                                    <h1>Student Information</h1>      
                                </td>      
                            </tr>      
                        </table>      
                    </HeaderTemplate>      
                    <ItemStyle CssClass="itemstyle" />      
                    <ItemTemplate>      
                        <table border="1">      
                            <tr>      
                                <td>Employee ID:</td>      
                                <td>      
                                    <asp:Label ID="lblempid" runat="server" Text='<%# Eval("EmpId") %>'>      
                                    </asp:Label>      
                                </td>      
                                <td rowspan="5">      
                                    <asp:Image ID="empimg" runat="server" ImageUrl='      
                                        <%# "~/Images/" + Eval("EmpImage") %>' Height="180px" Width="200px" />      
                                    </td>      
                                </tr>      
                                <tr>      
                                    <td>Employee Name:</td>      
                                    <td>      
                                        <asp:Label ID="lblempname" runat="server" Text='<%# Eval("EmpName") %>'>      
                                        </asp:Label>      
                                    </td>      
                                </tr>      
                                <tr>      
                                    <td>Employee EmailId:</td>      
                                    <td>      
                                        <asp:Label ID="lblemailid" runat="server" Text='<%# Eval("EmpEmailId") %>'>      
                                        </asp:Label>      
                                    </td>      
                                </tr>      
                                <tr>      
                                    <td>Employee Mobile Number</td>      
                                    <td>      
                                        <asp:Label ID="lblmbnum" runat="server" Text='<%# Eval("EmpMobileNumber")  %>'>      
                                        </asp:Label>      
                                    </td>      
                                </tr>      
                                <tr>      
                                    <td colspan="3" style="text-align:left">  
                                        <asp:Button ID="btn1" runat="server" CommandName="edit" Text="Edit" />  
                                        <asp:Button ID="btn2" runat="server" Text="Delete" CommandName="delete" />      
                                    </td>      
                                </tr>      
                            </table>      
                        </ItemTemplate>      
                        <EditItemStyle CssClass="itemstyle" />      
                        <EditItemTemplate>      
                            <table border="1">      
                                <tr>      
                                    <td>Employee Id:</td>      
                                    <td>      
                                        <asp:TextBox ID="txtempid" ReadOnly="true" runat="server" Text='<%# Eval("EmpId") %>'>      
                                        </asp:TextBox>      
                                    </td>      
                                    <td rowspan="5">      
                                        <asp:Image ID="empimg" runat="server" ImageUrl='      
                                            <%# "~/Images/" + Eval("EmpImage") %>' Height="180px" />      
                                            <br />      
                                            <asp:FileUpload ID="fu1" runat="server" />      
                                        </td>      
                                    </tr>      
                                    <tr>      
                                        <td>Employee Name</td>      
                                        <td>      
                                            <asp:TextBox ID="txtempname" runat="server" Text='<%# Eval("EmpName") %>'>      
                                            </asp:TextBox>      
                                        </td>      
                                    </tr>      
                                    <tr>      
                                        <td>Employee EmailId</td>      
                                        <td>      
                                            <asp:TextBox ID="txtempmail" runat="server" Text='<%# Eval("EmpEmailId") %>'>      
                                            </asp:TextBox>      
                                        </td>      
                                    </tr>      
                                    <tr>      
                                        <td>Employee Mobile Number</td>      
                                        <td>      
                                            <asp:TextBox ID="txtmbnum" runat="server" Text='<%# Eval("EmpMobileNumber") %>'>      
                                            </asp:TextBox>      
                                        </td>      
                                    </tr>      
                                    <tr>      
                                        <td colspan="3" style="text-align:left;">   
                                            <asp:Button ID="btn3" runat="server" CommandName="update" Text="update" />   
                                            <asp:Button ID="btn4" runat="server" CommandName="cancel" Text="Cancel" />      
                                        </td>      
                                    </tr>      
                                </table>      
                            </EditItemTemplate>      
                        </asp:DataList>      
                    </div>    
    </form>
</body>
</html>
