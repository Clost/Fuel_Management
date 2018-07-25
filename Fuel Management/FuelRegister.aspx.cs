﻿using System;
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
    public partial class FuelRegisterPage : System.Web.UI.Page
    {
        private DatabaseConnection con;

        protected void Page_Load(object sender, EventArgs e)
        {
           
            con = new DatabaseConnection();
            con.OpenConnection();

            con.ExecuteQueries("select * from Site");
            foreach (DataRow dr in con.QueryEx().Rows)
            {
                IdSite.Items.Add(dr[0].ToString());
            }



            IdSite.Items.Insert(0, new ListItem("Select Site ID", "0"));




        }

        protected void Save_btnClick(Object sender, EventArgs e)
        {
            con = new DatabaseConnection();
            con.OpenConnection();
            con.ExecuteQueries("insert into Site values('" + IdSite.Text + "', '" + cluster.Text + "', '" + ADrefueled.Text + "', '" + Levelbefore.Text + "', '" + Levelafter.Text + "', '" + Qty.Text + "', '" + username.Text + ",'" + FinRWeek.Text + "','" + receiptNumber.Text + "'')");
            //v
            


            if (con.x > 0)
            {
                ResultInfo.Text = "New Fuel have inserted successfully";
            }
            else
            {
                ResultInfo.Text = "New Fuel not Inserted";
            }
            con.CloseConnection();

        }

        
    }

}