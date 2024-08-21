<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="RegisterForm.aspx.cs" Inherits="Circulado_Books.RegisterForm" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head id="Head1" runat="server">
    <title>Register - Circulado's BookStore</title>
    <style>
        body {
            font-family: Arial, sans-serif;
            background-color: #f0f2f5;
            display: flex;
            justify-content: center;
            align-items: center;
            height: 100vh;
            margin: 0;
        }

        form {
            background-color: white;
            padding: 2rem;
            border-radius: 8px;
            box-shadow: 0 4px 12px rgba(0, 0, 0, 0.1);
            max-width: 400px;
            width: 100%;
            text-align: center;
        }

        ul {
            list-style: none;
            padding: 0;
            margin-bottom: 2rem;
        }

        ul li {
            display: inline-block;
            margin: 0 10px;
        }

        ul li a {
            text-decoration: none;
            color: #007bff;
            font-weight: bold;
        }

        ul li a:hover {
            text-decoration: underline;
        }

        input[type="text"], input[type="password"] {
            width: calc(100% - 20px);
            padding: 10px;
            margin-top: 0.5rem;
            border: 1px solid #ccc;
            border-radius: 4px;
            margin-bottom: 1rem;
        }

        .error-message {
            color: red;
            font-size: 0.9rem;
        }

        button {
            background-color: #007bff;
            color: white;
            padding: 10px 20px;
            border: none;
            border-radius: 4px;
            cursor: pointer;
            font-size: 1rem;
        }

        button:hover {
            background-color: #0056b3;
        }
    </style>
</head>
<body>
    <form id="Form1" runat="server">
        <ul>
            <li><a id="A1" runat="server" href="~/Default.aspx">Home</a></li>
            <li><a id="A2" runat="server" href="~/UserLogin.aspx">Login</a></li>
        </ul>

        <h1>Register</h1>

        <p>Input name:</p>
        <asp:TextBox ID="TextName" runat="server"></asp:TextBox>

        <p>Create username:</p>
        <asp:TextBox ID="userName" runat="server"></asp:TextBox>

        <p>Input address:</p>
        <asp:TextBox ID="TextAddress" runat="server"></asp:TextBox>

        <p>Input email:</p>
        <asp:TextBox ID="email" runat="server"></asp:TextBox>

        <p>Create Password:</p>
        <asp:TextBox ID="pass" runat="server" TextMode="Password"></asp:TextBox>

        <p>Confirm Password:</p>
        <asp:TextBox ID="pass2" runat="server" TextMode="Password"></asp:TextBox>

        <asp:CompareValidator 
            runat="server" 
            ID="CompareValidator1" 
            ControlToCompare="pass"
            ControlToValidate="pass2" 
            Operator="Equal" 
            Type="String" 
            ErrorMessage="Passwords do not match." 
            CssClass="error-message" />

        <asp:RequiredFieldValidator 
            runat="server" 
            ID="RequiredFieldValidator1" 
            ControlToValidate="pass"
            Display="Dynamic" 
            ErrorMessage="Password is required." 
            CssClass="error-message" />

        <asp:RequiredFieldValidator 
            runat="server" 
            ID="RequiredFieldValidator2" 
            ControlToValidate="pass2"
            Display="Dynamic" 
            ErrorMessage="Confirm password is required." 
            CssClass="error-message" />

        <br />
        <asp:Button ID="regButton" runat="server" Text="Register" CssClass="button" OnClick="regButton_Click" />
    </form>
</body>
</html>
