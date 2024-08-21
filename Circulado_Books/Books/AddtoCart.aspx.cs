using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
namespace Circulado_Books.Books
{
    public partial class BookDetails : System.Web.UI.Page
    {
        // Use the correct connection string
        string mycon = "Data Source=(localdb)\\Projects;Initial Catalog=Circulado_Database;Integrated Security=True;Connect Timeout=30;Encrypt=False;TrustServerCertificate=False";

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                if (Request.QueryString["id"] != null)
                {
                    int bookId = Convert.ToInt32(Request.QueryString["id"]);
                    LoadBookDetails(bookId);
                }
                else
                {
                    Response.Redirect("BookStore.aspx");
                }
            }
        }

        private void LoadBookDetails(int bookId)
        {
            using (SqlConnection connection = new SqlConnection(mycon))
            {
                try
                {
                    connection.Open();

                    string selectQuery = "SELECT title, author, genre, price, i_Type, Quantity FROM Items WHERE i_id = @BookId";

                    using (SqlCommand cmd = new SqlCommand(selectQuery, connection))
                    {
                        cmd.Parameters.AddWithValue("@BookId", bookId);

                        using (SqlDataReader reader = cmd.ExecuteReader())
                        {
                            if (reader.Read())
                            {
                                lblTitle.Text = "Title: " + reader["title"].ToString();
                                lblAuthor.Text = "Author: " + reader["author"].ToString();
                                lblGenre.Text = "Genre: " + reader["genre"].ToString();
                                lblPrice.Text = "Price: " + Convert.ToDecimal(reader["price"]).ToString("C");
                                lbli_Type.Text = "Book Type: " + reader["i_Type"].ToString();

                                // Display the quantity in the "quantity" label
                                quantity.Text = reader["Quantity"].ToString() + " stocks remaining";
                            }
                            else
                            {
                                Response.Redirect("BookStore.aspx");
                            }
                        }
                    }
                }
                catch (Exception ex)
                {
                    Response.Write("An error occurred: " + ex.Message);
                }
                finally
                {
                    connection.Close();
                }
            }
        }

        protected void Back_Click(object sender, EventArgs e)
        {
            Response.Redirect("BookStore.aspx");
        }

        protected void Button1_Click(object sender, EventArgs e)
        {
            if (Session["CustomerId"] == null)
            {
                // Redirect to the login page or display a message indicating the user needs to be logged in
                Response.Redirect("~/Default.aspx");
                return;
            }

            int customerId = Convert.ToInt32(Session["CustomerId"]);
            int bookId = Convert.ToInt32(Request.QueryString["id"]);

            if (!int.TryParse(BookQtyText.Text, out int temp))
            {
                Response.Write("<script>alert('Please enter a valid quantity');</script>");
                return;
            }
            else if (temp <= 0)
            {
                Response.Write("<script>alert('Please enter a quantity greater than 0');</script>");
                return;
            }

            int quantity = temp; // You can adjust this based on user input

            using (SqlConnection connection = new SqlConnection("Data Source=(localdb)\\Projects;Initial Catalog=Circulado_Database;Integrated Security=True;Connect Timeout=30;Encrypt=False;TrustServerCertificate=False"))
            {
                connection.Open();

                // Check if the quantity will go below 0 after the update
                string checkQuantityQuery = "SELECT Quantity FROM Items WHERE i_id = @BookId";

                using (SqlCommand checkQuantityCmd = new SqlCommand(checkQuantityQuery, connection))
                {
                    checkQuantityCmd.Parameters.AddWithValue("@BookId", bookId);

                    int currentQuantity = Convert.ToInt32(checkQuantityCmd.ExecuteScalar());

                    if (currentQuantity - quantity < 0)
                    {
                        Response.Write("<script>alert('Na hurot na dol');</script>");
                        return;
                    }
                }

                // Update the quantity in the Items table
                string updateQuantityQuery = "UPDATE Items SET Quantity = Quantity - @Quantity WHERE i_id = @BookId";

                using (SqlCommand updateCmd = new SqlCommand(updateQuantityQuery, connection))
                {
                    updateCmd.Parameters.AddWithValue("@BookId", bookId);
                    updateCmd.Parameters.AddWithValue("@Quantity", quantity);

                    updateCmd.ExecuteNonQuery();
                }

                // Check if the item is already in the user's cart
                string checkCartItemQuery = "SELECT COUNT(*) FROM CartItems WHERE c_id = @CustomerId AND i_id = @BookId";
                using (SqlCommand checkCmd = new SqlCommand(checkCartItemQuery, connection))
                {
                    checkCmd.Parameters.AddWithValue("@CustomerId", customerId);
                    checkCmd.Parameters.AddWithValue("@BookId", bookId);

                    int existingItemCount = Convert.ToInt32(checkCmd.ExecuteScalar());

                    if (existingItemCount > 0)
                    {
                        // If the item already exists, update the quantity
                        string updateCartQuantityQuery = "UPDATE CartItems SET qty = qty + @Quantity " +
                                                         "WHERE c_id = @CustomerId AND i_id = @BookId";

                        using (SqlCommand updateCartCmd = new SqlCommand(updateCartQuantityQuery, connection))
                        {
                            updateCartCmd.Parameters.AddWithValue("@CustomerId", customerId);
                            updateCartCmd.Parameters.AddWithValue("@BookId", bookId);
                            updateCartCmd.Parameters.AddWithValue("@Quantity", quantity);

                            updateCartCmd.ExecuteNonQuery();
                        }
                    }
                    else
                    {
                        // If the item doesn't exist, insert a new row
                        string insertCartItemQuery = "INSERT INTO CartItems (c_id, i_id, qty) VALUES (@CustomerId, @BookId, @Quantity)";

                        using (SqlCommand insertCmd = new SqlCommand(insertCartItemQuery, connection))
                        {
                            insertCmd.Parameters.AddWithValue("@CustomerId", customerId);
                            insertCmd.Parameters.AddWithValue("@BookId", bookId);
                            insertCmd.Parameters.AddWithValue("@Quantity", quantity);

                            insertCmd.ExecuteNonQuery();
                        }
                    }
                }
            }

            // Optionally, you can display a confirmation message
            Response.Write("<script>alert('Item added to cart successfully');</script>");
            Response.Redirect("Bookstore.aspx");
        }



    }
}