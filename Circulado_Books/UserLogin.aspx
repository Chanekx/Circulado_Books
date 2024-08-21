<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="UserLogin.aspx.cs" Inherits="Circulado_Books.UserLogin" %>

<style>
    body {
        font-family: Arial, sans-serif;
        background-color: #f0f2f5;
        margin: 0;
        padding: 0;
        display: flex;
        justify-content: center;
        align-items: center;
        height: 100vh;
    }

    main {
        background-color: white;
        padding: 2rem;
        border-radius: 8px;
        box-shadow: 0 4px 12px rgba(0, 0, 0, 0.1);
        max-width: 400px;
        width: 100%;
    }

    h1 {
        color: #333;
        margin-bottom: 1rem;
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

    p {
        margin: 1rem 0;
    }

    label {
        display: block;
        margin-bottom: 0.5rem;
        color: #333;
    }

    input[type="text"],
    input[type="password"] {
        width: calc(100% - 20px);
        padding: 10px;
        margin-top: 0.5rem;
        border: 1px solid #ccc;
        border-radius: 4px;
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

    #IamMessage {
        color: red;
        margin-top: 1rem;
    }
</style>

<form id="Form1" runat="server">
    <main>
        <section aria-labelledby="aspnetTitle">
            <ul>
                <li><a id="A1" runat="server" href="~/Default.aspx">Home</a></li>
                <li><a id="A2" runat="server" href="~/RegisterForm.aspx">Register</a></li>
            </ul>
            <h1 id="aspnetTitle">Welcome to Circulado's BookStore</h1>
            <p>
                <asp:Label ID="Label1" runat="server" Text="Username:"></asp:Label>
                <asp:TextBox ID="TextUser" runat="server" CssClass="input-field"></asp:TextBox>
            </p>
            <p>
                <asp:Label ID="Label2" runat="server" Text="Password:"></asp:Label>
                <asp:TextBox ID="TextPassword" runat="server" TextMode="Password" CssClass="input-field"></asp:TextBox>
            </p>
            <p>
                <asp:Label ID="IamMessage" runat="server" Text=""></asp:Label>
            </p>
            <p>
                <asp:Button ID="Login" runat="server" OnClick="Login_Click" Text="Login" CssClass="button" />
            </p>
        </section>
    </main>
</form>
