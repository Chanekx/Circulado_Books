using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Circulado_Books
{
    public partial class _Default : Page
    {

        protected void Login_Click(object sender, EventArgs e)
        {
            Response.Redirect("~/UserLogin.aspx");
        }

        protected void Register_Click(object sender, EventArgs e)
        {
            Response.Redirect("~/RegisterForm.aspx");
        }

    }

}