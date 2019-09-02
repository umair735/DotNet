<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Template.aspx.cs" Inherits="eLeave.Admin.Template" MasterPageFile="~/Admin/AdminMaster.Master" %>

<asp:Content ID="head" runat="server" ContentPlaceHolderID="head">
</asp:Content>

<asp:Content ID="content" runat="server" ContentPlaceHolderID="CPH_Master">

    <div class="ContentItem">

        <div>
            <h1>Template</h1>
        </div>

        <table>
            <tr>
                <td>
                    <asp:Label Text="Leave Type" ID="lblLeaveType" runat="server" />
                </td>
                <td>
                    <asp:DropDownList runat="server" ID="ddLeaveType" CssClass="textBox" DataTextField="LeaveTypeText" DataValueField="LeaveTypeValue" Height="43px" Width="330px">
                    </asp:DropDownList>

                </td>
            </tr>

            <tr>
                <td></td>
                <td>
                    <asp:TextBox runat="server" ID="txtTemplate" CssClass="textBox" TextMode="MultiLine" Height="125px" Width="320px" /></td>

            </tr>

            <tr>
                <td></td>
                <td>
                    <asp:Button Text="Save" ID="btnSave" CssClass="button" runat="server" OnClick="btnSave_Click" />
                    <asp:Button Text="Update" ID="btnUpdate" CssClass="button" runat="server" OnClick="btnUpdate_Click" />
                </td>
            </tr>

        </table>

        <asp:GridView runat="server" ID="grdTemplate" AutoGenerateColumns="false" CssClass="mydatagrid" PagerStyle-CssClass="pager"
            HeaderStyle-CssClass="header" RowStyle-CssClass="rows" AllowPaging="True">
            <Columns>
                <asp:BoundField DataField="Template" HeaderText="Template" />
                <asp:BoundField DataField="IsActive" HeaderText="IsActive" />
                <asp:TemplateField HeaderText="Action">
                    <ItemTemplate>
                        <asp:ImageButton ID="Delete" AlternateText="Delete" CommandArgument='<%# Eval("TemplateID")%>' OnClick="Delete_Click" runat="server" />
                        <asp:ImageButton ID="Edit" AlternateText="Edit" CommandArgument='<%# Eval("TemplateID")%>' runat="server" OnClick="Edit_Click" />
                    </ItemTemplate>
                </asp:TemplateField>

            </Columns>
        </asp:GridView>



    </div>



</asp:Content>
