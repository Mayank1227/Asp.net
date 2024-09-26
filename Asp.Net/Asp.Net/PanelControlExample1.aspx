<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="PanelControlExample1.aspx.cs" Inherits="Asp.Net.PanelControlExample1" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
<style type="text/css">  
        .style1  
        {  
            text-align: center;  
            background-color: #999999;  
        }  
        .style2  
        {  
            background-color: #999999;  
        }  
    </style>  
</head>
<body>
    
   <%-- <form id="form1" runat="server">
        <div>
        </div>
    </form>--%>

     <form id="form1" runat="server">  
    <div>  
    <table class="style3" align="center">  
        <tr>  
            <td class="style1">  
                <strong style="background-color: #999999">Payment Mode</strong></td>  
        </tr>  
        <tr>  
            <td class="style2">  
                <asp:RadioButtonList ID="RadioButtonList1" runat="server" AutoPostBack="True"   
                    onselectedindexchanged="RadioButtonList1_SelectedIndexChanged">  
                    <asp:ListItem>Via Debit Card</asp:ListItem>  
                    <asp:ListItem>Via Credit Card</asp:ListItem>  
                    <asp:ListItem>Via Internet Banking</asp:ListItem>  
                    <asp:ListItem>Via Cash On Delivery</asp:ListItem>  
                </asp:RadioButtonList>  
            </td>  
        </tr>  
        <tr>  
            <td class="style2">  
                <asp:Panel ID="Panel1" runat="server" CssClass="style2">  
                    Bank          
                    <asp:DropDownList ID="DropDownList2" runat="server" AutoPostBack="True">  
                        <asp:ListItem>SBI</asp:ListItem>  
                        <asp:ListItem>PNB</asp:ListItem>  
                        <asp:ListItem>CBI</asp:ListItem>  
                        <asp:ListItem>BOI</asp:ListItem>  
                    </asp:DropDownList>  
                    <br />  
                    Card No    
                    <asp:TextBox ID="TextBox3" runat="server"></asp:TextBox>  
                    <br />  
                    CVV No   
                    <asp:TextBox ID="TextBox4" runat="server"></asp:TextBox>  
                </asp:Panel>  
            </td>  
        </tr>  
        <tr>  
            <td class="style2">  
                <asp:Panel ID="Panel2" runat="server" CssClass="style2">  
                    Bank         
                    <asp:DropDownList ID="DropDownList3" runat="server">  
                        <asp:ListItem>SBI</asp:ListItem>  
                        <asp:ListItem>IOB</asp:ListItem>  
                    </asp:DropDownList>  
                    <br />  
                    Card No   
                    <asp:TextBox ID="TextBox5" runat="server"></asp:TextBox>  
                </asp:Panel>  
            </td>  
        </tr>  
        <tr>  
            <td class="style2">  
                <asp:Panel ID="Panel3" runat="server" CssClass="style2">  
                    Bank         
                    <asp:DropDownList ID="DropDownList4" runat="server">  
                        <asp:ListItem>SBI</asp:ListItem>  
                        <asp:ListItem>IOB</asp:ListItem>  
                        <asp:ListItem>CBI</asp:ListItem>  
                        <asp:ListItem>PNB</asp:ListItem>  
                        <asp:ListItem>HDFC</asp:ListItem>  
                    </asp:DropDownList>  
                </asp:Panel>  
            </td>  
        </tr>  
        <tr>  
            <td class="style2">  
                <asp:Panel ID="Panel4" runat="server" CssClass="style2">  
                    Pay Bill on Delivery Time                                         
                    <asp:Button ID="Button5" runat="server" Text="I Agree" />  
                </asp:Panel>  
</td> </tr></table>  
    </div>  
    </form>  

</body>
</html>

