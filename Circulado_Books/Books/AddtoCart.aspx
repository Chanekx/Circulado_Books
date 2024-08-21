<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="AddtoCart.aspx.cs" Inherits="Circulado_Books.Books.BookDetails" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head id="Head1" runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
        <div>
            <h2>
                <asp:Button ID="Back" Text="Back" OnClick="Back_Click" runat="server" style="margin-bottom: 0px" Height="59px" Width="105px" />
                &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
                <asp:Label ID="Label1" runat="server" Text="Input Quantity:"></asp:Label>
                </h2>
            <h2>&nbsp;Details:&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
             
                &nbsp;<asp:TextBox ID="BookQtyText" runat="server" Width="221px"></asp:TextBox>
&nbsp;&nbsp;&nbsp;&nbsp;
                <asp:Button ID="Button1" runat="server" OnClick="Button1_Click" Text="Add to Cart" />
                
                &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
                <asp:Label ID="quantity" runat="server" Text="Label"></asp:Label>
                
                </h2>
            <div>
                <asp:Label ID="lblTitle" runat="server" Text=""></asp:Label>
                <br />
            </div>
            <div>
                <asp:Label ID="lblAuthor" runat="server" Text=""></asp:Label>
                <br />
            </div>
            <div>
                <asp:Label ID="lblGenre" runat="server" Text=""></asp:Label>
                <br />
            </div>
            <div>
                <asp:Label ID="lblPrice" runat="server" Text=""></asp:Label>
                <br />
                <asp:Label ID="lbli_Type" runat="server"></asp:Label>
                <br />
                <br />
            </div>
            <!-- Add more labels for other book details as needed -->

            <div>
                <br />
                <br />
                <br />
                <br />
                <br />
            </div>
        </div>
    </form>
</body>
</html>

