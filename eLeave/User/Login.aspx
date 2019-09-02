<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Login.aspx.cs" Inherits="eLeave.User.Login" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
    
    <link href="../Contents/Style.css" rel="stylesheet" />
    <link href="../Contents/StyleSheet.css" rel="stylesheet" />

</head>
<body>
    <form id="form1" runat="server">
    <div class="logo">
            <div class="logoimage"></div>
            <div class="logotxt">
                <h2>Employee(s) Leave Management System Admin Panel</h2>
            </div>
        </div>
        <table style="width: 100%;">
            <tr>
                <td style="width: 50%;">
                    <img src="../Images/a.jpg" width="100%" alt="Alternate Text" />
                </td>

                <td style="width: 50%;">
                    <div class=" Form">

                        <h1>Employee Login </h1>

                        <asp:Label ID="lblEmail" Text="Email" runat="server" /><br />
                        <asp:TextBox runat="server" ID="txtEmail" CssClass="textBox" Height="30px" Width="100%" />
                        <br />

                        <asp:Label ID="lblPassword" Text="Password" runat="server" /><br />
                        <asp:TextBox runat="server" ID="txtPassword" TextMode="Password" CssClass="textBox" Height="30px" Width="100%" />
                        <br />

                        <br />
                        

                        <asp:Button Text="Sign In" ID="btnSignIn" CssClass="button" OnClick="btnSignIn_Click"  runat="server" />

                    </div>


                </td>
            </tr>
        </table>
    </form>
</body>
</html>
