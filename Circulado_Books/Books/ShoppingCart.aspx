<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="ShoppingCart.aspx.cs" Inherits="Circulado_Books.Books.ShoppingCart" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
        <div>
            <h1>
        <asp:Button ID="Button2" runat="server" OnClick="Button2_Click" Text="Back" Height="48px" Width="137px" />
            </h1>
            <h1>Your Shopping Cart</h1>
       </div>
       <asp:GridView ID="gvCart" runat="server" AutoGenerateColumns="False" CellPadding="4" ForeColor="#333333" GridLines="None" Width="850px">
           <AlternatingRowStyle BackColor="White" />
    <Columns>
        <asp:BoundField DataField="Title" HeaderText="Title" SortExpression="Title" />
        <asp:BoundField DataField="Price" HeaderText="Price" SortExpression="Price" DataFormatString="{0:C}" />
        <asp:BoundField DataField="Qty" HeaderText="Quantity" SortExpression="Quantity" />
    </Columns>
           <EditRowStyle BackColor="#7C6F57" />
           <FooterStyle BackColor="#1C5E55" Font-Bold="True" ForeColor="White" />
           <HeaderStyle BackColor="#1C5E55" Font-Bold="True" ForeColor="White" />
           <PagerStyle BackColor="#666666" ForeColor="White" HorizontalAlign="Center" />
           <RowStyle BackColor="#E3EAEB" />
           <SelectedRowStyle BackColor="#C5BBAF" Font-Bold="True" ForeColor="#333333" />
           <SortedAscendingCellStyle BackColor="#F8FAFA" />
           <SortedAscendingHeaderStyle BackColor="#246B61" />
           <SortedDescendingCellStyle BackColor="#D4DFE1" />
           <SortedDescendingHeaderStyle BackColor="#15524A" />
       </asp:GridView>
        &nbsp;&nbsp;&nbsp;<asp:Button ID="ClearCart" runat="server" OnClick="ClearCart_Click" Text="Clear Cart" Height="59px" Width="212px" />
        &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
        &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<asp:Label ID="Label2" runat="server" Text="Total Price:"></asp:Label>
&nbsp;<asp:Label ID="totalprice" runat="server" Text="Label"></asp:Label>
        <br />
        <br />
            <asp:Label ID="Label1" runat="server" Text="Shipping Address"></asp:Label>
        &nbsp;&nbsp;&nbsp;
        <asp:TextBox ID="shipaddress" runat="server" Width="337px" OnTextChanged="shipaddress_TextChanged"></asp:TextBox>
        &nbsp;<div style="margin-left: 400px">
            &nbsp;</div>
        &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
        <asp:Button ID="Order" runat="server" OnClick="Order_Click" Text="Order" Height="45px" Width="137px" />
        <h1>Items Ordered</h1>
        <asp:GridView ID="gvCustomerOrderedItems" runat="server" AutoGenerateColumns="False" EmptyDataText="No ordered items found" CellPadding="4" ForeColor="#333333" GridLines="None" Width="1081px">
            <AlternatingRowStyle BackColor="White" />
    <Columns>
        
        <asp:BoundField DataField="o_date" HeaderText="Order Date" DataFormatString="{0:yyyy-MM-dd}" />
        <asp:BoundField DataField="title" HeaderText="Item Title" />
        <asp:BoundField DataField="price" HeaderText="Item Price" DataFormatString="{0:C}" />
        <asp:BoundField DataField="qty" HeaderText="Quantity" />
    </Columns>
            <EditRowStyle BackColor="#2461BF" />
            <FooterStyle BackColor="#507CD1" Font-Bold="True" ForeColor="White" />
            <HeaderStyle BackColor="#507CD1" Font-Bold="True" ForeColor="White" />
            <PagerStyle BackColor="#2461BF" ForeColor="White" HorizontalAlign="Center" />
            <RowStyle BackColor="#EFF3FB" />
            <SelectedRowStyle BackColor="#D1DDF1" Font-Bold="True" ForeColor="#333333" />
            <SortedAscendingCellStyle BackColor="#F5F7FB" />
            <SortedAscendingHeaderStyle BackColor="#6D95E1" />
            <SortedDescendingCellStyle BackColor="#E9EBEF" />
            <SortedDescendingHeaderStyle BackColor="#4870BE" />
</asp:GridView>
        <br />
        <asp:Button ID="clearOrdered" runat="server" OnClick="clearOrdered_Click" Text="Clear Ordered Items" />
    &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
        <asp:Label ID="Label3" runat="server" Text="Total:"></asp:Label>
        <asp:Label ID="total" runat="server" Text="Label"></asp:Label>
    </form>
</body>
</html>
