using System;
using System.Data.SqlClient;
using System.Web.UI;

namespace Circulado_Books
{
    public partial class UserLogin : Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
        }

        protected void Login_Click(object sender, EventArgs e)
        {
            string enteredUsername = TextUser.Text.Trim();
            string enteredPassword = TextPassword.Text;

            // Validate the username and password against the database
            if (ValidateUser(enteredUsername, enteredPassword))
            {
                int customerId = GetUserId(enteredUsername);
                string customerName = GetUserName(enteredUsername);

                Session["CustomerId"] = customerId;
                Session["CustomerName"] = customerName;
                Session["Username"] = enteredUsername;

                if (enteredUsername.ToLower().Contains("admin"))
                {
                    // Redirect to a different page for admin
                    Response.Redirect("~/admin/AdminPage.aspx");
                }
                else
                {
                    Response.Redirect("~/Books/Bookstore.aspx");
                }
            }
            else
            {
                Response.Write("<script>alert('Wrong password or Username');</script>");
               
            }
        }

        private bool ValidateUser(string username, string password)
        {
            // Validate the username and password against the database
            using (SqlConnection con = new SqlConnection("Data Source=(localdb)\\Projects;Initial Catalog=Circulado_Database;Integrated Security=True;Connect Timeout=30;Encrypt=False;TrustServerCertificate=False"))
            {
                con.Open();

                using (SqlCommand cmd = new SqlCommand("SELECT COUNT(*) FROM Customers WHERE UserName = @username AND Password = @password", con))
                {
                    cmd.Parameters.AddWithValue("@username", username);
                    cmd.Parameters.AddWithValue("@password", password);
                    int userCount = Convert.ToInt32(cmd.ExecuteScalar());

                    return userCount > 0;
                }
            }
        }

        private int GetUserId(string username)
        {
            // Retrieve the UserId based on the entered username
            using (SqlConnection con = new SqlConnection("Data Source=(localdb)\\Projects;Initial Catalog=Circulado_Database;Integrated Security=True;Connect Timeout=30;Encrypt=False;TrustServerCertificate=False"))
            {
                con.Open();

                using (SqlCommand cmd = new SqlCommand("SELECT c_id FROM Customers WHERE UserName = @username", con))
                {
                    cmd.Parameters.AddWithValue("@username", username);
                    object c_id = cmd.ExecuteScalar();

                    // Check if userId is not null before converting
                    return c_id != null ? Convert.ToInt32(c_id) : 0;
                }
            }
        }

        private string GetUserName(string username)
        {
            // Retrieve the UserName based on the entered username
            using (SqlConnection con = new SqlConnection("Data Source=(localdb)\\Projects;Initial Catalog=Circulado_Database;Integrated Security=True;Connect Timeout=30;Encrypt=False;TrustServerCertificate=False"))
            {
                con.Open();

                using (SqlCommand cmd = new SqlCommand("SELECT UserName FROM Customers WHERE UserName = @username", con))
                {
                    cmd.Parameters.AddWithValue("@username", username);
                    object userName = cmd.ExecuteScalar();

                    return userName != null ? userName.ToString() : string.Empty;
                }
            }
        }

        protected void TextUser_TextChanged(object sender, EventArgs e)
        {
        }
    }
}
