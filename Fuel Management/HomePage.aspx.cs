using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data.SqlClient;
using System.Data;

namespace Fuel_Management
{
    public partial class HomePage : System.Web.UI.Page
    {
        private DatabaseConnection con;
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            { 

                con = new DatabaseConnection();
                con.OpenConnection();

                con.ShowDataInGridView("select * from Fuel_register");
                //gridManage.DataSource = con.dt;

                Console.WriteLine(con.dt);
            }
        }


        

        
        
    }

}