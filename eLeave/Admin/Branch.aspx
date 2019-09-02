<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Branch.aspx.cs" Inherits="eLeave.Admin.Branch" MasterPageFile="~/Admin/AdminMaster.Master" %>


<asp:Content runat="server" ContentPlaceHolderID="head" ID="head">
</asp:Content>

<asp:Content ID="content" ContentPlaceHolderID="CPH_Master" runat="server">
    <div class=" ContentItem">
        <div>
            <h1>Department</h1>
        </div>
        <br />
        <table>
            <tr>
                <td>
                    <asp:Label Text="Department Name" ID="lblDepartmentName" runat="server" /></td>
                <td>
                    <asp:TextBox runat="server" ID="txtDepartmentName" CssClass="textBox" Height="30px" Width="100%" />
                </td>
            </tr>
            <tr>
                <td></td>
                <td>
                    <asp:Button Text="Save" ID="btnSave" CssClass="button" runat="server" OnClick="btnSave_Click" />
                    <asp:Button Text="Update" ID="btnUpdate" CssClass="button" OnClick="btnUpdate_Click" runat="server" />
                </td>
            </tr>
        </table>
        <asp:GridView runat="server" ID="grdDepartment" AutoGenerateColumns="false" CssClass="mydatagrid" PagerStyle-CssClass="pager"
            HeaderStyle-CssClass="header" RowStyle-CssClass="rows" AllowPaging="True">
            <Columns>
                <asp:BoundField DataField="BranchName" HeaderText="Department Name" />
                <asp:BoundField DataField="IsActive" HeaderText="IsActive" />
                <asp:TemplateField HeaderText="Action">
                    <ItemTemplate>
                        <asp:ImageButton ID="Edit" AlternateText="Edit" CommandArgument='<%# Eval("BranchID") %>' OnClick="Edit_Click" runat="server" CssClass="btn btn-info" />
                        <asp:ImageButton ID="Delete" AlternateText="Delete" CommandArgument='<%#Eval("BranchID") %>' CssClass="btn btn-info" OnClick="Delete_Click" OnClientClick="return confirm('Are You Sure TO Delete This Record')" runat="server" />
                    </ItemTemplate>
                </asp:TemplateField>
            </Columns>
        </asp:GridView>
    </div>
</asp:Content>





