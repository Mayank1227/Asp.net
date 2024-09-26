<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="CookieExample1.aspx.cs" Inherits="Asp.Net.CookieExample1" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
 <style type="text/css">
        .auto-style1 {
            width: 100%;
        }
    </style>
</head>
<body>
    
    <form id="form1" runat="server">
       <div>
            
    UserName:
    <asp:TextBox ID="txtUserName" runat="server"></asp:TextBox>
           <br />
           <br />
           <br />
    Password:
    <asp:TextBox ID="txtPassword" TextMode="Password" runat="server"></asp:TextBox>
           <br />
           <br />
           <br />
    Remember me:
    <asp:CheckBox ID="chkRememberMe" runat="server" />
            <br />
            <br />
            <br />
            <asp:Button ID="btnLogin" runat="server" Text="Login" OnClick="btnLogin_Click" />
            <br />

           </div>
    </form>
</body>
</html>

