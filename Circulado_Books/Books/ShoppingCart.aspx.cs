using System;
using System.Data;
using System.Data.SqlClient;
using System.Net;
using System.Web.UI;
using System.Web.UI.WebControls;


namespace Circulado_Books.Books
{
    public partial class ShoppingCart : System.Web.UI.Page
    {
        String mycon = "Data Source=(localdb)\\Projects;Initial Catalog=Circulado_Database;Integrated Security=True;Connect Timeout=30;Encrypt=False;TrustServerCertificate=False";
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["CustomerId"] == null)
            {
                // User is not authenticated, redirect to the login page
                Response.Redirect("/Default.aspx");
            }

            if (!IsPostBack)
            {
                if (Session["CustomerId"] != null)
                {
                    int customerId = Convert.ToInt32(Session["CustomerId"]);
                    LoadCustomerOrderedItems(customerId);
                }
                else
                {
                    // Handle the case when no customer ID is available
                    // You may redirect the user or display an error message
                }

                LoadShoppingCart();
            }
        }

        private void MoveCartItemsToItemsOrdered(int customerId, int orderId)
        {
            using (SqlConnection connection = new SqlConnection("Data Source=(localdb)\\Projects;Initial Catalog=Circulado_Database;Integrated Security=True;Connect Timeout=30;Encrypt=False;TrustServerCertificate=False"))
            {
                connection.Open();

                // Insert items from CartItems to ItemsOrdered
                string insertItemsOrderedQuery = "INSERT INTO ItemsOrdered (o_id, i_id, qty) SELECT @OrderId, i_id, qty FROM CartItems WHERE c_id = @CustomerId";

                using (SqlCommand cmd = new SqlCommand(insertItemsOrderedQuery, connection))
                {
                    cmd.Parameters.AddWithValue("@OrderId", orderId);
                    cmd.Parameters.AddWithValue("@CustomerId", customerId);

                    cmd.ExecuteNonQuery();
                }

                // Clear the user's shopping cart
                ClearShoppingCart(customerId);
            }
        }

        private void ClearShoppingCart(int customerId)
        {
            using (SqlConnection connection = new SqlConnection("Data Source=(localdb)\\Projects;Initial Catalog=Circulado_Database;Integrated Security=True;Connect Timeout=30;Encrypt=False;TrustServerCertificate=False"))
            {
                connection.Open();

                // Delete items from CartItems
                string clearCartQuery = "DELETE FROM CartItems WHERE c_id = @CustomerId";

                using (SqlCommand cmd = new SqlCommand(clearCartQuery, connection))
                {
                    cmd.Parameters.AddWithValue("@CustomerId", customerId);

                    cmd.ExecuteNonQuery();
                }
            }
        }

        protected void Order_Click(object sender, EventArgs e)
        {
            if (Session["CustomerId"] != null)
            {
                int customerId = Convert.ToInt32(Session["CustomerId"]);

                using (SqlConnection connection = new SqlConnection("Data Source=(localdb)\\Projects;Initial Catalog=Circulado_Database;Integrated Security=True;Connect Timeout=30;Encrypt=False;TrustServerCertificate=False"))
                {
                    connection.Open();

                    // Insert a new order record
                    string insertOrderQuery = "INSERT INTO Orders (o_date, ship_address, c_id) VALUES (GETDATE(), @ShipAddress, @CustomerId); SELECT SCOPE_IDENTITY();";

                    using (SqlCommand cmd = new SqlCommand(insertOrderQuery, connection))
                    {
                        cmd.Parameters.AddWithValue("@ShipAddress", shipaddress.Text); // You should get the shipping address from the user input or another source.
                        cmd.Parameters.AddWithValue("@CustomerId", customerId);

                        int orderId = Convert.ToInt32(cmd.ExecuteScalar());

                        // Move items from CartItems to ItemsOrdered
                        MoveCartItemsToItemsOrdered(customerId, orderId);
                    }
                }

                // Optionally, you can display a confirmation message
                Response.Write("<script>alert('Order placed successfully');</script>");
                Response.Redirect("ShoppingCart.aspx");
            }
        }

        protected void Button2_Click(object sender, EventArgs e)
        {
            Response.Redirect("BookStore.aspx");
        }

        private void LoadCustomerOrderedItems(int customerId)
        {
            using (SqlConnection connection = new SqlConnection(mycon))
            {
                connection.Open();

                string selectQuery = "SELECT O.o_id, O.o_date, I.title, I.price, IO.qty " +
                                     "FROM ItemsOrdered IO " +
                                     "INNER JOIN Items I ON IO.i_id = I.i_id " +
                                     "INNER JOIN Orders O ON IO.o_id = O.o_id " +
                                     "WHERE O.c_id = @CustomerId";

                using (SqlCommand cmd = new SqlCommand(selectQuery, connection))
                {
                    cmd.Parameters.AddWithValue("@CustomerId", customerId);

                    SqlDataAdapter adapter = new SqlDataAdapter(cmd);
                    DataTable dt = new DataTable();
                    adapter.Fill(dt);

                    gvCustomerOrderedItems.DataSource = dt;
                    gvCustomerOrderedItems.DataBind();

                    decimal totalPrice = CalculateTotalPrice(dt);
                    total.Text = totalPrice.ToString("C"); // Format as currency
                }
            }
        }


        private void LoadShoppingCart()
        {
            if (Session["CustomerId"] != null)
            {
                int customerId = Convert.ToInt32(Session["CustomerId"]);

                using (SqlConnection connection = new SqlConnection("Data Source=(localdb)\\Projects;Initial Catalog=Circulado_Database;Integrated Security=True;Connect Timeout=30;Encrypt=False;TrustServerCertificate=False"))
                {
                    connection.Open();

                    string selectQuery = "SELECT C.cart_item_id, I.title, I.price, C.qty " +
                                         "FROM CartItems C " +
                                         "INNER JOIN Items I ON C.i_id = I.i_id " +
                                         "WHERE C.c_id = @CustomerId";

                    using (SqlCommand cmd = new SqlCommand(selectQuery, connection))
                    {
                        cmd.Parameters.AddWithValue("@CustomerId", customerId);

                        SqlDataAdapter adapter = new SqlDataAdapter(cmd);
                        DataTable dt = new DataTable();
                        adapter.Fill(dt);

                        gvCart.DataSource = dt;
                        gvCart.DataBind();

                        // Calculate and display the total price
                        decimal totalPrice = CalculateTotalPrice(dt);
                        totalprice.Text = totalPrice.ToString("C"); // Format as currency
                        
                    }
                }
            }
        }

        private decimal CalculateTotalPrice(DataTable cartDataTable)
        {
            decimal totalPrice = 0;

            foreach (DataRow row in cartDataTable.Rows)
            {
                decimal price = Convert.ToDecimal(row["price"]);
                int quantity = Convert.ToInt32(row["qty"]);

                totalPrice += price * quantity;
            }

            return totalPrice;
        }

        protected void ClearCart_Click(object sender, EventArgs e)
        {
            if (Session["CustomerId"] != null)
            {
                int customerId = Convert.ToInt32(Session["CustomerId"]);

                // Clear the user's shopping cart
                ClearShoppingCart(customerId);

                // Refresh the GridView to reflect the changes
                LoadShoppingCart();

                // Optionally, you can display a confirmation message
                Response.Write("<script>alert('Shopping cart cleared successfully');</script>");
            }
        }

        protected void clearOrdered_Click(object sender, EventArgs e)
        {
            if (Session["CustomerId"] != null)
            {
                int customerId = Convert.ToInt32(Session["CustomerId"]);

                using (SqlConnection connection = new SqlConnection(mycon))
                {
                    connection.Open();

                    // Delete items from ItemsOrdered for the specified customer
                    string clearOrderedItemsQuery = "DELETE FROM ItemsOrdered WHERE o_id IN (SELECT o_id FROM Orders WHERE c_id = @CustomerId)";

                    using (SqlCommand cmd = new SqlCommand(clearOrderedItemsQuery, connection))
                    {
                        cmd.Parameters.AddWithValue("@CustomerId", customerId);

                        cmd.ExecuteNonQuery();
                    }

                    // Reset the identity value for ItemsOrdered to 1
                    
                    string resetIdentityQuery = "DBCC CHECKIDENT('ItemsOrdered', RESEED, 1)";


                    using (SqlCommand resetCmd = new SqlCommand(resetIdentityQuery, connection))
                    {
                        resetCmd.ExecuteNonQuery();
                    }
                }

                // Refresh the ordered items GridView
                LoadCustomerOrderedItems(customerId);

                // Optionally, you can display a confirmation message
                Response.Write("<script>alert('Ordered items cleared successfully');</script>");
            }
        }

        protected void shipaddress_TextChanged(object sender, EventArgs e)
        {

        }
    }

}



