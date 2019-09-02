<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Alerts.aspx.cs" Inherits="eLeave.User.Alerts" MasterPageFile="~/User/User.Master" %>

<asp:Content ID="head" runat="server" ContentPlaceHolderID="head">
</asp:Content>

<asp:Content ID="Content" runat="server" ContentPlaceHolderID="CPH_User">

    <div class="ContentItem">
        <div>
            <h1>Alerts
            </h1>
        </div>

        <asp:GridView runat="server" ID="grdAlerts" AutoGenerateColumns="false" CssClass="mydatagrid" PagerStyle-CssClass="pager"
            HeaderStyle-CssClass="header" RowStyle-CssClass="rows" AllowPaging="True">
            <Columns>
                <asp:BoundField DataField="UserName" HeaderText="User Name" />
                <asp:BoundField DataField="DepartmentName" HeaderText="Department Name" />
                <asp:BoundField DataField="LeaveType" HeaderText="Leave Type" />
                <asp:BoundField DataField="FormDate" HeaderText="Form Date" />
                <asp:BoundField DataField="ToDate" HeaderText="To Date" />


                <asp:TemplateField HeaderText="Action">
                    <ItemTemplate>

                        
                        <asp:ImageButton ID="Delete" AlternateText="Delete" CommandArgument='<%#Eval("SubmitLeaveID") %>'  OnClick="Delete_Click" OnClientClick="return confirm('Are You Sure TO Delete This Record')" runat="server" />
                        <asp:ImageButton ID="Approved" AlternateText="Approved" runat="server"  CommandArgument='<%#Eval("SubmitLeaveID") %>'  OnClick="Approved_Click" />
                        <asp:ImageButton ID="Deny" AlternateText="Deny" runat="server" CommandArgument='<%#Eval("SubmitLeaveID") %>' OnClick="Deny_Click" />


                    </ItemTemplate>
                </asp:TemplateField>
            </Columns>
        </asp:GridView>
    </div>
</asp:Content>
