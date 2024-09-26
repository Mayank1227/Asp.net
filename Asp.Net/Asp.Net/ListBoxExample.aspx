<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="ListBoxExample.aspx.cs" Inherits="Asp.Net.ListBoxExample" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
    <style type="text/css">
        .auto-style1 {
            width: 100%;
        }
        .auto-style2 {
            width: 388px;
        }
        .auto-style3 {
            margin-left: 67px;
        }
        .auto-style4 {
            width: 485px;
        }
    </style>
</head>
<body>
    <form id="form1" runat="server">
        <table class="auto-style1">
            <tr>
                <td class="auto-style2">
                    <asp:ListBox ID="ListBox1" runat="server" AutoPostBack="True" Width="170px"></asp:ListBox>
                    <br />
                    <br />
                </td>
                <td class="auto-style4">&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
                    <asp:Button ID="Button1" runat="server" CssClass="auto-style3" OnClick="Button1_Click" Text="Button" Width="186px" />
                </td>
                <td>
                    <asp:ListBox ID="ListBox2" runat="server" AutoPostBack="True" Width="176px"></asp:ListBox>
                </td>
            </tr>
        </table>
        <div>
        </div>
    </form>
</body>
</html>
