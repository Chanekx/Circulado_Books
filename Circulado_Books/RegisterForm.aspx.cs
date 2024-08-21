using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Data.SqlClient;

namespace Circulado_Books
{
    public partial class RegisterForm : System.Web.UI.Page
    {
        SqlConnection con = new SqlConnection(@"Data Source=(localdb)\Projects;Initial Catalog=Circulado_Database;Integrated Security=True;Connect Timeout=30;Encrypt=False;TrustServerCertificate=False");
        protected void Page_Load(object sender, EventArgs e)
        {
        }

        protected void regButton_Click(object sender, EventArgs e)
        {
            con.Open();
            string query = "INSERT INTO Customers VALUES (@c_name,@c_address,@UserName, @Email, @Password)";

            using (SqlCommand cmd = new SqlCommand(query, con))
            {
                // Assuming 'userName', 'email', and 'pass' are your input values
                cmd.Parameters.AddWithValue("@c_name", TextName.Text);
                cmd.Parameters.AddWithValue("@c_address", TextAddress.Text);
                cmd.Parameters.AddWithValue("@UserName", userName.Text);
                cmd.Parameters.AddWithValue("@Email", email.Text);
                cmd.Parameters.AddWithValue("@Password", pass.Text);

                cmd.ExecuteNonQuery();
                con.Close();
                Response.Redirect("~/UserLogin.aspx");
            }
        }


    }
}