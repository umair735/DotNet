<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="AdminLogin.aspx.cs" Inherits="eLeave.Admin.AdminLogin" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Administration</title>
    <link href="../Contents/StyleSheet.css" rel="stylesheet" />
    <link href="../Contents/Style.css" rel="stylesheet" />
</head>
<body>
    <form id="form1" runat="server">
        <div class="ContentItem">
            <div class="AdminForm">

                <h1 style="background-color: rgb(7, 64, 97)">Administration login</h1>
                <span>Admin:</span>
                <%--<asp:RequiredFieldValidator ID="rfvName" ControlToValidate="txtemail" runat="server" ErrorMessage="Enter Name" ForeColor="Red"></asp:RequiredFieldValidator>--%>
                <asp:TextBox ID="txtemail" CssClass="textBox" runat="server" Height="30px" Width="100%"></asp:TextBox>
                <span>Password:</span>
                <%--<asp:RequiredFieldValidator ID="rfvPassword" ControlToValidate="txtpass" runat="server" ErrorMessage="Enter Password" ForeColor="Red"></asp:RequiredFieldValidator>--%>
                <asp:TextBox ID="txtpass" TextMode="Password" CssClass="textBox" runat="server" Height="30px" Width="100%"></asp:TextBox>
                <span>
                    <asp:Label ID="lblmsg" runat="server" ForeColor="Red"></asp:Label></span>

                <asp:Button ID="btnLogin" CssClass="button" Style="background-color: rgb(7, 64, 97)" runat="server" Text="Login" OnClick="btnLogin_Click" />
            </div>
        </div>
    </form>
</body>
</html>
