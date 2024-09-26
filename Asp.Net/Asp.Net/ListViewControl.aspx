<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="ListViewControl.aspx.cs" Inherits="Asp.Net.ListViewControl" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
      <title>ListView Control - ASP.NET Tutorials</title>  
    <style type="text/css">  
        .TableCSS   
        {   
            border-style:none;   
            background-color:#3BA0D8;   
            width: 850px;   
        }   
        .TableHeader   
        {   
            background-color:#66CCFF;   
            color:#0066FF;   
            font-size:large;   
            font-family:Verdana;   
            }   
        .TableData   
        {   
            background-color:#82C13E;  
            color:#fff;   
            font-family:Courier New;   
            font-size:medium;   
            font-weight:bold;   
        }  
    </style>  
</head>  
<body>  
    <form id="form1" runat="server">  
    <div>  
    <h2 style="color:#3BA0D8; font-style:italic;">ListView Control Example in ASP.NET: How To Use ListView Control</h2>     
       <asp:ListView ID="ListView1" runat="server">
    <LayoutTemplate>
        <table id="Table1" runat="server" class="TableCSS">
            <tr id="Tr1" runat="server" class="TableHeader">
                <td id="Td1" runat="server">Comment ID</td>
                <td id="Td2" runat="server">Blog ID</td>
                <td id="Td3" runat="server">Date</td>
                <td id="Td4" runat="server">Name</td>
                <td id="Td5" runat="server">Comments</td>
            </tr>
            <tr id="ItemPlaceholder" runat="server"></tr>
            <tr id="Tr2" runat="server">
                <td id="Td6" runat="server" colspan="2">
                    <asp:DataPager ID="DataPager1" runat="server">
                        <Fields>
                            <asp:NextPreviousPagerField ButtonType="Link" />
                            <asp:NumericPagerField />
                            <asp:NextPreviousPagerField ButtonType="Link" />
                        </Fields>
                    </asp:DataPager>
                </td>
            </tr>
        </table>
    </LayoutTemplate>
    <ItemTemplate>
        <tr class="TableData">
            <td><asp:Label ID="Label1" runat="server" Text='<%# Eval("id") %>'></asp:Label></td>
            <td><asp:Label ID="Label2" runat="server" Text='<%# Eval("Blog Id") %>'></asp:Label></td>
            <td><asp:Label ID="Label3" runat="server" Text='<%# Eval("Date") %>'></asp:Label></td>
            <td><asp:Label ID="Label4" runat="server" Text='<%# Eval("Name") %>'></asp:Label></td>
            <td><asp:Label ID="Label5" runat="server" Text='<%# Eval("Comments") %>'></asp:Label></td>
        </tr>
    </ItemTemplate>
</asp:ListView>

    </div>  
    </form>  
</body>  
</html>
