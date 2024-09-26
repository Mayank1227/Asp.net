<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="DropDownlist.aspx.cs" Inherits="Asp.Net.DropDownlist" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
    <style type="text/css">
        .auto-style1 {
            width: 100%;
        }
        .auto-style2 {
            width: 328px;
        }
        .auto-style3 {
            width: 328px;
            height: 33px;
        }
        .auto-style4 {
            height: 33px;
        }
    </style>
</head>
<body>
    <form id="form1" runat="server">
        <div>
            DropDownList<br />
        </div>
        <table class="auto-style1">
            <tr>
                <td class="auto-style3">Contary</td>
                <td class="auto-style4">
                    <br />
                    <asp:DropDownList ID="DropDownList1" runat="server" AutoPostBack="True" Height="31px" OnSelectedIndexChanged="DropDownList1_SelectedIndexChanged" Width="190px">
                    </asp:DropDownList>
                </td>
            </tr>
            <tr>
                <td class="auto-style2">&nbsp;</td>
                <td>&nbsp;</td>
            </tr>
            <tr>
                <td class="auto-style2">State</td>
                <td>
                    <br />
                    <asp:DropDownList ID="DropDownList2" runat="server" AutoPostBack="True" Height="32px" Width="190px">
                    </asp:DropDownList>
                </td>
            </tr>
            <tr>
                <td class="auto-style2">&nbsp;</td>
                <td>&nbsp;</td>
            </tr>
        </table>
    </form>
</body>
</html>
