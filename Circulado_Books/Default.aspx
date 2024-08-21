<%@ Page Title="Home Page" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Default.aspx.cs" Inherits="Circulado_Books._Default" %>

<asp:Content ID="BodyContent" ContentPlaceHolderID="MainContent" runat="server">

    <style>
        body {
            font-family: Arial, sans-serif;
            background-color: #f0f2f5;
        }

        main {
            display: flex;
            justify-content: center;
            align-items: center;
            height: 100vh;
        }

        section {
            background-color: white;
            padding: 2rem;
            border-radius: 8px;
            box-shadow: 0 4px 12px rgba(0, 0, 0, 0.1);
            max-width: 600px;
            text-align: center;
        }

        h1 {
            color: #333;
            margin-bottom: 1rem;
        }

        p {
            margin-top: 2rem;
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

    <main>
        <section aria-labelledby="aspnetTitle">
            <h1 id="aspnetTitle">Welcome to CIRCULABOOK</h1>
            <h2>Circulado's BookStore</h2>
            <h3>PANG KALAWAKANG BOOKSTORE, MAG LOGIN OR MAG SIGN UP</h3>
            
            <p>
                <asp:Button ID="Login" runat="server" OnClick="Login_Click" Text="Login" CssClass="button" />
                &nbsp;&nbsp;&nbsp;
                <asp:Button ID="Register" runat="server" OnClick="Register_Click" Text="Register" CssClass="button" />
            </p>
        </section>
    </main>

</asp:Content>
