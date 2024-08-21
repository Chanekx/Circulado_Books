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
    public partial class Items : System.Web.UI.Page
    {
        SqlConnection con = new SqlConnection(@"Data Source=(localdb)\Projects;Initial Catalog=Circulado_Database;Integrated Security=True;Connect Timeout=30;Encrypt=False;TrustServerCertificate=False");
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void add_button_Click(object sender, EventArgs e)
        {
            con.Open();
            SqlCommand cmd = con.CreateCommand();
            cmd.CommandType = CommandType.Text;
            cmd.CommandText = "INSERT INTO items VALUES ('" + TextBox2.Text + "', '" + TextBox3.Text + "', '" + TextBox4.Text + "', '" + TextBox5.Text + "', '" + TextBox6.Text + "', '" + TextBox7.Text + "','" + TextBox8.Text + "')";
            cmd.ExecuteNonQuery();
            con.Close();
            Response.Redirect("Items.aspx");
        }

        protected void srch_button_Click(object sender, EventArgs e)
        {
            string search = TextBox1.Text;
            SqlDataSource2.FilterExpression = "CONVERT(isbn,System.String)LIKE '%" + search + "%' OR title LIKE '%" + search + "%' OR author LIKE '%" + search + "%' OR genre LIKE '%" + search + "%'OR CONVERT(price,System.String) LIKE '%" + search + "%' OR i_type LIKE '%" + search + "%'";
            GridView1.DataBind();

        }

        protected void Button1_Click(object sender, EventArgs e)
        {
            Response.Redirect("~/admin/AdminPage.aspx");
        }
    }
}