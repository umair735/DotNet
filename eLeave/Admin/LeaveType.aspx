<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="LeaveType.aspx.cs" Inherits="eLeave.Admin.LeaveType" MasterPageFile="~/Admin/AdminMaster.Master" %>

<asp:Content ID="head" runat="server" ContentPlaceHolderID="head">
</asp:Content>


<asp:Content ID="content" runat="server" ContentPlaceHolderID="CPH_Master">
    <div class="ContentItem">
        <div>
            <h1>Leave Type</h1>
        </div>

        <br />

        <table>
            <tr>
                <td>
                    <asp:Label Text="Leaave Type" ID="lblLeaveType" runat="server" /></td>
                <td><asp:TextBox runat="server" ID="txtLeaveType" CssClass="textBox" /></td>
                
            </tr>
            <tr>
                <td></td>
                <td>
                    <asp:Button Text="Save" ID="btnSave" CssClass="button" runat="server" OnClick="btnSave_Click" />
                <asp:Button Text="Update" ID="btnUpdate" CssClass="button" runat="server" OnClick="btnUpdate_Click" /></td>
            </tr>

        </table>

        <asp:GridView runat="server" ID="grdLeaveType" AutoGenerateColumns="false" CssClass="mydatagrid" PagerStyle-CssClass="pager"
            HeaderStyle-CssClass="header" RowStyle-CssClass="rows" AllowPaging="True">
            <Columns>

                <asp:BoundField DataField="LeaveType" HeaderText="Leave Type" />
                <asp:BoundField DataField="IsActive" HeaderText="IsActive" />

                <asp:TemplateField HeaderText="Action">
                    <ItemTemplate>

                        <asp:ImageButton ID="Edit" AlternateText="Edit" CommandArgument='<%# Eval("LeaveTypeID") %>' OnClick="Edit_Click" runat="server" CssClass="btn btn-info" />
                        <asp:ImageButton ID="Delete" AlternateText="Delete" CommandArgument='<%#Eval("LeaveTypeID") %>' OnClick="Delete_Click" CssClass="btn btn-info" OnClientClick="return confirm('Are You Sure TO Delete This Record')" runat="server" />

                    </ItemTemplate>
                </asp:TemplateField>
            </Columns>
        </asp:GridView>




    </div>


</asp:Content>
