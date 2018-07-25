using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Data.SqlClient;
using System.Configuration;

namespace Fuel_Management
{
    public partial class LoginPage : System.Web.UI.Page
    {
        private DatabaseConnection con;

        protected void Page_Load(object sender, EventArgs e)
        {

        }

       protected void Btn_connectClick(object sender, EventArgs e)
        {
            
                con = new DatabaseConnection();
                con.OpenConnection();
                con.ExecuteQueries("select count(*) from Tabl_users where user_name='" + username.Text + "' and passwd='" + btn_login.Text + "'");


                string output = con.cmd.ExecuteScalar().ToString();

                if (output == "1")
                {
                    Session["user"] = username.Text;
                    Response.Redirect("~/HomePage.aspx");

                }
                else
                {
                    Response.Write("Login Failed");
                }

                con.CloseConnection();
           

        }
    }
}