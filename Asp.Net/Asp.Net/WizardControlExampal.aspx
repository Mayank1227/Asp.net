<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="WizardControlExampal.aspx.cs" Inherits="Asp.Net.WizardControlExampal" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
    <style type="text/css">
        .auto-style1 {
            width: 455px;
        }
        .auto-style2 {
            width: 463px;
        }
        .auto-style3 {
            width: 623px;
        }
        .auto-style4 {
            margin-right: 113px;
        }
        .auto-style5 {
            width: 555px;
            height: 241px;
        }
        .auto-style6 {
            width: 651px;
        }
        .auto-style7 {
            width: 532px;
        }
        .auto-style8 {
            width: 499px;
        }
        .auto-style9 {
            width: 668px;
        }
    </style>
</head>
<body>
   <form id="form1" runat="server">
        <table class="auto-style1">
            <tr>
                <td>&nbsp;</td>
                <td>&nbsp;</td>
                <td class="auto-style3">&nbsp;</td>
                <td class="auto-style2">&nbsp;</td>
                <td>&nbsp;</td>
            </tr>
            <tr>
                <td>&nbsp;</td>
                <td>&nbsp;</td>
                <td class="auto-style3">
                    <asp:Wizard ID="Wizard1" runat="server" Height="371px" Width="346px" ActiveStepIndex="2" OnFinishButtonClick="Wizard1_FinishButtonClick" CssClass="auto-style4">
                        <CancelButtonStyle BackColor="Red" Font-Italic="True" />
                        <FinishCompleteButtonStyle BackColor="#FF9999" />
                        <HeaderStyle BackColor="#CCFF33" Height="300px" HorizontalAlign="Center" />
                        <NavigationButtonStyle BackColor="#993300" />
                        <NavigationStyle BackColor="#FF3399" />
                        <StartNextButtonStyle BackColor="#660033" ForeColor="Black" />
                        <StepNextButtonStyle BackColor="#FF0066" />
                        <StepPreviousButtonStyle BackColor="#CC0000" />
                        <SideBarButtonStyle BackColor="#CC0066" />
                        <SideBarStyle BackColor="Red" ForeColor="Black" Height="120px" HorizontalAlign="Center" />
                        <StepStyle BackColor="#FF3300" />
                        <WizardSteps>
                            <asp:WizardStep runat="server" title="StudentDetails">
                                <table class="auto-style1">
                                    <tr>
                                        <td>&nbsp;</td>
                                        <td>&nbsp;</td>
                                        <td>Student Details</td>
                                        <td>&nbsp;</td>
                                        <td>&nbsp;</td>
                                    </tr>
                                    <tr>
                                        <td>&nbsp;</td>
                                        <td>First Name</td>
                                        <td>
                                            <asp:TextBox ID="TextBox1" runat="server"></asp:TextBox>
                                        </td>
                                        <td>&nbsp;</td>
                                        <td>&nbsp;</td>
                                    </tr>
                                    <tr>
                                        <td>&nbsp;</td>
                                        <td>Last Name</td>
                                        <td>
                                            <asp:TextBox ID="TextBox2" runat="server"></asp:TextBox>
                                        </td>
                                        <td>&nbsp;</td>
                                        <td>&nbsp;</td>
                                    </tr>
                                    <tr>
                                        <td>&nbsp;</td>
                                        <td>&nbsp;</td>
                                        <td>&nbsp;</td>
                                        <td>&nbsp;</td>
                                        <td>&nbsp;</td>
                                    </tr>
                                    <tr>
                                        <td>&nbsp;</td>
                                        <td>&nbsp;</td>
                                        <td>&nbsp;</td>
                                        <td>&nbsp;</td>
                                        <td>&nbsp;</td>
                                    </tr>
                                </table>



                            </asp:WizardStep>
                             <asp:WizardStep runat="server" title="Student Course Details">
                                <table class="auto-style1">
                                    <tr>
                                        <td>&nbsp;</td>
                                        <td>&nbsp;</td>
                                        <td>Student Course Detail</td>
                                        <td>&nbsp;</td>
                                        <td>&nbsp;</td>
                                    </tr>
                                    <tr>
                                        <td>&nbsp;</td>
                                        <td>Student Course<br /> </td>
                                        <td>
                                            <asp:TextBox ID="TextBox3" runat="server"></asp:TextBox>
                                        </td>
                                        <td>&nbsp;</td>
                                        <td>&nbsp;</td>
                                    </tr>
                                    <tr>
                                        <td>&nbsp;</td>
                                        <td>Branch</td>
                                        <td>
                                            <asp:TextBox ID="TextBox4" runat="server"></asp:TextBox>
                                        </td>
                                        <td>&nbsp;</td>
                                        <td>&nbsp;</td>
                                    </tr>
                                    <tr>
                                        <td>&nbsp;</td>
                                        <td>&nbsp;</td>
                                        <td>&nbsp;</td>
                                        <td>&nbsp;</td>
                                        <td>&nbsp;</td>
                                    </tr>
                                    <tr>
                                        <td>&nbsp;</td>
                                        <td>&nbsp;</td>
                                        <td>&nbsp;</td>
                                        <td>&nbsp;</td>
                                        <td>&nbsp;</td>
                                    </tr>
                                </table>
                            </asp:WizardStep>
                            <asp:WizardStep runat="server" Title="Student Personal Details">
                                <table class="auto-style1">
                                    <tr>
                                        <td class="auto-style8">&nbsp;</td>
                                        <td class="auto-style6">&nbsp;</td>
                                        <td class="auto-style9">Student Personal Detail</td>
                                        <td>&nbsp;</td>
                                        <td>&nbsp;</td>
                                    </tr>
                                    <tr>
                                        <td class="auto-style8">&nbsp;</td>
                                        <td class="auto-style6">Student Email</td>
                                        <td class="auto-style9">
                                            <asp:TextBox ID="TextBox5" runat="server"></asp:TextBox>
                                        </td>
                                        <td>&nbsp;</td>
                                        <td>&nbsp;</td>
                                    </tr>
                                    <tr>
                                        <td class="auto-style8">&nbsp;</td>
                                        <td class="auto-style6">City</td>
                                        <td class="auto-style9">
                                            <asp:TextBox ID="TextBox6" runat="server"></asp:TextBox>
                                        </td>
                                        <td>&nbsp;</td>
                                        <td>&nbsp;</td>
                                    </tr>
                                    <tr>
                                        <td class="auto-style8"></td>
                                        <td class="auto-style6">State</td>
                                        <td class="auto-style9">
                                            <asp:TextBox ID="TextBox7" runat="server"></asp:TextBox>
                                        </td>
                                        <td class="auto-style2"></td>
                                        <td class="auto-style2"></td>
                                    </tr>
                                    <tr>
                                        <td class="auto-style8">&nbsp;</td>
                                        <td class="auto-style6">&nbsp;</td>
                                        <td class="auto-style9">&nbsp;</td>
                                        <td>&nbsp;</td>
                                        <td>&nbsp;</td>
                                    </tr>
                                </table>
                            </asp:WizardStep>
                            <asp:WizardStep runat="server" Title="Student  Summary">
                                
                                          
                                <table class="auto-style1">  
                         <tr>  
                             <td><strong>Student Details</strong></td>  
                               
                             <td> </td>  
                               
                         </tr>  
                         <tr>  
                             <td>  
                                 Student FirstName:</td>  
                             <td>  
                                 <asp:Label ID="Label1" runat="server" Text=""></asp:Label>  
                                 </td>  
                             <td> </td>  
                               
                         </tr>  
                         <tr>  
                             <td>Student LastName:</td>  
                               
                             <td>  
                                 <asp:Label ID="Label2" runat="server" Text=""></asp:Label>  
                             </td>  
                               
                         </tr>  
                           
                         <tr>  
                             <td></td>  
                             <td> </td>  
                         </tr>  
                         <tr>  
                             <td><strong>Student Course Details</strong></td>  
                             <td> </td>  
                         </tr>  
                           
                         <tr>  
                             <td>Student Course:</td>  
                             <td>  
                                 <asp:Label ID="Label3" runat="server" Text=""></asp:Label>  
                             </td>  
                         </tr>  
                          <tr>  
                             <td>Student Branch:</td>  
                             <td>  
                                 <asp:Label ID="Label4" runat="server" Text=""></asp:Label>  
                              </td>  
                         </tr>  
                           
                         <tr>  
                             <td> </td>  
                             <td> </td>  
                         </tr>  
                         <tr>  
                             <td><strong>Student Personal Details</strong></td>  
                             <td> </td>  
                         </tr>  
                         <tr>  
                             <td>Student EmailId:</td>  
                             <td>  
                                 <asp:Label ID="Label5" runat="server" Text=""></asp:Label>  
                             </td>  
                         </tr>  
                         <tr>  
                             <td>Student City:</td>  
                             <td>  
                                 <asp:Label ID="Label6" runat="server" Text=""></asp:Label>  
                             </td>  
                         </tr>  
                         <tr>  
                             <td>Student State:</td>  
                             <td>  
                                 <asp:Label ID="Label7" runat="server" Text=""></asp:Label>  
                             </td>  
                         </tr>  
                           
                     </table>  



                            </asp:WizardStep>
                        </WizardSteps>
                    </asp:Wizard>
                </td>
                <td class="auto-style2">&nbsp;</td>
                <td>
                  <%--  <asp:Literal ID="Literal1" runat="server" Text="Enter the value of a and b"></asp:Literal>--%>
                </td>
            </tr>
            <tr>
                <td>&nbsp;</td>
                <td>&nbsp;</td>
                <td class="auto-style3">&nbsp;</td>
                <td class="auto-style2">&nbsp;</td>
                <td>&nbsp;</td>
            </tr>
            <tr>
                <td>&nbsp;</td>
                <td>&nbsp;</td>
                <td class="auto-style3">&nbsp;</td>
                <td class="auto-style2">&nbsp;</td>
                <td>&nbsp;</td>
            </tr>
            <tr>
                <td>&nbsp;</td>
                <td>&nbsp;</td>
                <td class="auto-style3">&nbsp;</td>
                <td class="auto-style2">&nbsp;</td>
                <td>&nbsp;</td>
            </tr>
        </table>
        <div>
        </div>
    </form>
</body>
</html>
