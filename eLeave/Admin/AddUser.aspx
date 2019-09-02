<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="AddUser.aspx.cs" Inherits="eLeave.Admin.AddUser" MasterPageFile="~/Admin/AdminMaster.Master" %>

<asp:Content ID="head" runat="server" ContentPlaceHolderID="head">
</asp:Content>

<asp:Content ID="content" runat="server" ContentPlaceHolderID="CPH_Master">
    <table style="width: 100%;">
        <tr>
            <td style="width: 50%;">
                <div class=" Form">
                    <h1>Employee Registration Form</h1>
                    <asp:Label Text="User Name" runat="server" /><br />
                    <asp:TextBox runat="server" ID="txtUserName" CssClass="textBox" Height="30px" Width="100%" />
                    <br />
                    <asp:Label Text="Email" runat="server" /><br />
                    <asp:TextBox runat="server" ID="txtEmail" CssClass="textBox" Height="30px" Width="100%" />
                    <br />
                    <asp:Label Text="Password" runat="server" /><br />
                    <asp:TextBox runat="server" ID="txtPassword" TextMode="Password"  CssClass="textBox" Height="30px" Width="100%" />
                    <br />
                    <asp:Label Text="Re-Password" runat="server" /><br />
                    <asp:TextBox runat="server" ID="txtRePassword" TextMode="Password"  CssClass="textBox" Height="30px" Width="100%" />
                    <br />
                    <asp:CompareValidator ValidationGroup="GrpSave" ID="CompareValidator1" runat="server" ErrorMessage="RePassword Is Not Match With Password"
                        ControlToValidate="txtRePassword" ControlToCompare="txtPassword" Operator="Equal" Type="String" ForeColor="Red" Display="Dynamic">
                    </asp:CompareValidator>
                    <asp:Button Text="Add User" ID="btnSignUp" OnClick="btnSignUp_Click" CssClass="button" ValidationGroup="GrpSave" runat="server" />
                </div>
            </td>
        </tr>
    </table>
</asp:Content>
