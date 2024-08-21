<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="AdminPage.aspx.cs" Inherits="Circulado_Books.Books.AdminPage" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Admin Page</title>
    <style>
        body {
            font-family: Arial, sans-serif;
            text-align: center;
            margin: 20px;
        }

        #formContainer {
            display: flex;
            flex-direction: column;
            align-items: center;
        }

        #logoutButton {
            margin-bottom: 20px;
        }

        #buttonContainer {
            display: flex;
            justify-content: space-around;
        }

        .actionButton {
            width: 150px;
            height: 80px;
            font-size: 16px;
        }
    </style>
</head>
<body>
    <form id="form1" runat="server">
        <div id="formContainer">
            <asp:Button ID="Button3" runat="server" OnClick="Button3_Click" Text="Logout" CssClass="actionButton" />
            <p>Hi Admin!</p>
            <p>Where would you like to go?</p>
            
            <div id="buttonContainer">
                <asp:Button ID="Button1" runat="server" OnClick="Button1_Click" Text="Customers" CssClass="actionButton" />
                <asp:Button ID="Button2" runat="server" OnClick="Button2_Click" Text="Items" CssClass="actionButton" />
            </div>
        </div>
    </form>
</body>
</html>
