<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="EmailSendingFunctionality.aspx.cs" Inherits="Asp.Net.EmailSendingFunctionality" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
                  <div>
            <table border="0" cellpadding="0" cellspacing="0">
    <tr>
        <td class="auto-style1">To:</td>
        <td><asp:TextBox ID="txtTo" runat="server" /></td>
    </tr>
    <tr>
        <td class="auto-style1">&nbsp;</td>
        <td>&nbsp;</td>
    </tr>
    <tr>
        <td valign = "top" class="auto-style1">Subject:</td>
        <td><asp:TextBox ID="txtSubject" runat="server" /></td>
    </tr>
    <tr>
        <td class="auto-style1"></td>
        <td>&nbsp;</td>
    </tr>
    <tr>
        <td class="auto-style1">Body:</td>
        <td><asp:TextBox ID="txtBody" runat="server" TextMode="MultiLine" Height="150" Width="200" /></td>
    </tr>
    <tr>
        <td class="auto-style1">&nbsp;</td>
        <td>&nbsp;</td>
    </tr>
    <tr>
        <td class="auto-style1">
           <%-- <asp:Button ID="Button1" runat="server" OnClick="Button1_Click" Text="Reset" />--%>
            <asp:Label ID="Label1" runat="server" Text="Label"></asp:Label>
        </td>
        <td><%--<asp:Button ID="btnSend" Text="Send" runat="server" OnClick = "SendEmail" />--%>

            <asp:Button ID="btnsend" runat="server" Text="Button" OnClick="btnsend_Click" />


            <asp:Button ID="Button1" runat="server" Text="Clear data" OnClick="Button1_Click" />


        </td>
    </tr>
</table>
        </div>
    </form>
</body>
</html>