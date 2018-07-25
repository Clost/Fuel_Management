using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Fuel_Management
{
    public partial class ReportWeek1 : System.Web.UI.Page
    {
       private DatabaseConnection con;
        protected void Page_Load(object sender, EventArgs e)
        {

            if (!Page.IsPostBack)
            {

                con = new DatabaseConnection();
                con.OpenConnection();

                con.ExecuteQueries("select * from Site");
            }

        }
    }
}