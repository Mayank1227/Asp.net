<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="GridViewImageUploading.aspx.aspx.cs" Inherits="Asp.Net.GridViewImageUploading_aspx" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
         <h3 style="color: #0000FF; font-style: italic">Display Image and update, delete in GridView Using ASP.NET</h3>
        <div>
            <asp:FileUpload ID="fileupload" runat="server" />
            <asp:Button ID="upload" runat="server" Font-Bold="true" Text="Upload" OnClick="upload_Click" />
<asp:Label ID="lblResult" runat="server"/>

            <br />
            <br />
        </div>
        <div>
           <asp:GridView runat="server" ID="gvImage" AutoGenerateColumns="false" AllowPaging="True"
                OnRowCancelingEdit="gvImage_RowCancelingEdit" DataKeyNames="ImageId" CellPadding="4"
                OnRowEditing="gvImage_RowEditing" OnRowUpdating="gvImage_RowUpdating" OnRowDeleting="gvImage_RowDeleting" HeaderStyle-BackColor="Tomato">
                <Columns>
                    <asp:TemplateField HeaderText="Sr.No" HeaderStyle-Width="200px">
                        <ItemTemplate>
                            <asp:Label ID="lblImgId" runat="server" Text='<%#Container.DataItemIndex+1%>'></asp:Label>
                        </ItemTemplate>
                    </asp:TemplateField>
                    <asp:TemplateField HeaderText="Name" HeaderStyle-Width="200px">
                        <ItemTemplate>
                            <asp:Label ID="lblImageName" runat="server" Text='<%# Eval("ImageName") %>'></asp:Label>
                        </ItemTemplate>
                        <EditItemTemplate>
                            <asp:TextBox ID="txt_Name" runat="server" Text='<%# Eval("ImageName") %>'></asp:TextBox>
                        </EditItemTemplate>
                    </asp:TemplateField>
                    <asp:TemplateField HeaderText="Image" HeaderStyle-Width="200px">
                        <ItemTemplate>
                            <asp:Image ID="Image1" runat="server" ImageUrl='<%# Eval("Image") %>'
                                Height="80px" Width="100px" />
                        </ItemTemplate>
                        <EditItemTemplate>
                            <asp:Image ID="img_user" runat="server" ImageUrl='<%# Eval("Image") %>'
                                Height="80px" Width="100px" /><br />
                            <asp:FileUpload ID="FileUpload1" runat="server" />
                        </EditItemTemplate>
                    </asp:TemplateField>
                    <asp:TemplateField HeaderStyle-Width="150px">
                        <ItemTemplate>
                            <asp:LinkButton ID="LkB1" runat="server" CommandName="Edit">Edit</asp:LinkButton>
                            <asp:LinkButton ID="LkB11" runat="server" CommandName="Delete">Delete</asp:LinkButton>
                        </ItemTemplate>
                        <EditItemTemplate>
                            <asp:LinkButton ID="LkB2" runat="server" CommandName="Update">Update</asp:LinkButton>
                            <asp:LinkButton ID="LkB3" runat="server" CommandName="Cancel">Cancel</asp:LinkButton>
                        </EditItemTemplate>
                    </asp:TemplateField>
                </Columns>
            </asp:GridView>
        </div>
    </form>
</body>
</html>
