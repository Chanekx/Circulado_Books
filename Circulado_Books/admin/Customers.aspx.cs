using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Data.SqlClient;

namespace Circulado_Books.admin
{
    public partial class Customers : System.Web.UI.Page
    {
        SqlConnection con = new SqlConnection(@"Data Source=(localdb)\Projects;Initial Catalog=Circulado_Database;Integrated Security=True;Connect Timeout=30;Encrypt=False;TrustServerCertificate=False");
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void AddButton_Click(object sender, EventArgs e)
        {
            con.Open();
            SqlCommand cmd = con.CreateCommand();
            cmd.CommandType = CommandType.Text;
            cmd.CommandText = "INSERT INTO customers (c_name, c_address, UserName, Email, Password) VALUES (@c_name, @c_address, @UserName, @Email, @Password)";

            // Assuming cmd is a SqlCommand object and con is a SqlConnection object
            String na = "N/A";
            cmd.Parameters.AddWithValue("@c_name", TextBox2.Text);
            cmd.Parameters.AddWithValue("@c_address", string.IsNullOrEmpty(TextBox4.Text) ? DBNull.Value : (object)TextBox4.Text);
            cmd.Parameters.AddWithValue("@UserName",na);
            cmd.Parameters.AddWithValue("@Email", TextBox3.Text);
            cmd.Parameters.AddWithValue("@Password", na);

            cmd.ExecuteNonQuery();
            con.Close();
            Response.Redirect("Customers.aspx");
        }

        protected void Srch_Button_Click(object sender, EventArgs e)
        {
            string searchCriteria = TextBox1.Text;
            SqlDataSource1.FilterExpression = "c_name LIKE '%" + searchCriteria + "%' OR Email LIKE '%" + searchCriteria + "%' OR c_address LIKE '%" + searchCriteria + "%'";
            GridView3.DataBind();

        }

        protected void Button1_Click(object sender, EventArgs e)
        {
            Response.Redirect("~/admin/AdminPage.aspx");
        }


    }
}