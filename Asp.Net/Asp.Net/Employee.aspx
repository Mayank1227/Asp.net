<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Employee.aspx.cs" Inherits="Asp.Net.Employee" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
            <div>
            <asp:GridView ID="GridView1" runat="server" AutoGenerateColumns="False" DataKeyNames="Id"
                OnRowEditing="GridView1_RowEditing" OnRowUpdating="GridView1_RowUpdating"
                OnRowDeleting="GridView1_RowDeleting" OnRowCancelingEdit="GridView1_RowCancelingEdit">
                <Columns>
                     <asp:TemplateField HeaderText="Name">
        <ItemTemplate>
            <%# Eval("Name") %>
        </ItemTemplate>
        <EditItemTemplate>
            <asp:TextBox ID="txtName" runat="server" Text='<%# Bind("Name") %>'></asp:TextBox>
        </EditItemTemplate>
    </asp:TemplateField>

   
    <asp:TemplateField HeaderText="Salary">
        <ItemTemplate>
            <%# Eval("Salary") %>
        </ItemTemplate>
        <EditItemTemplate>
            <asp:TextBox ID="txtSalary" runat="server" Text='<%# Bind("Salary") %>'></asp:TextBox>
        </EditItemTemplate>
    </asp:TemplateField>

   
    <asp:TemplateField HeaderText="Image">
        <ItemTemplate>
          
            <asp:Image ID="imgPhoto" runat="server" ImageUrl='<%# Eval("ImagePath") %>' Width="100px" Height="100px" />
        </ItemTemplate>
        <EditItemTemplate>
          
            <asp:FileUpload ID="FileUpload1" runat="server" />
            <br />
            <asp:Image ID="imgPhoto" runat="server" ImageUrl='<%# Eval("ImagePath") %>' Width="100px" Height="100px" />
        </EditItemTemplate>
    </asp:TemplateField>
                    <asp:CommandField ShowEditButton="True" ShowDeleteButton="True" />
                </Columns>
            </asp:GridView>

            <h2>Add Employee</h2>
            <asp:Label ID="lblName" runat="server" Text="Name:"></asp:Label>
            <asp:TextBox ID="txtName" runat="server"></asp:TextBox>
                <br />
                <br />
            <br />
            <asp:Label ID="lblSalary" runat="server" Text="Salary:"></asp:Label>
            <asp:TextBox ID="txtSalary" runat="server"></asp:TextBox>
                <br />
                <br />
            <br />
            <asp:Label ID="lblImage" runat="server" Text="Image:"></asp:Label>
            <asp:FileUpload ID="FileUpload1" runat="server" />
                <br />
                <br />
            <br />
            <asp:Button ID="btnAdd" runat="server" Text="Add Employee" OnClick="btnAdd_Click" />
        </div>
    </form>
</body>
</html>
