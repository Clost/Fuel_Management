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

            if (Session["user"] != null)
            {
                username.Text = Session["user"].ToString();
                username.Enabled = false;
                
            }

            ADrefueled.ReadOnly = true;
            ADrefueled.Text = System.DateTime.Now.ToString("yyyy-MM-dd");

        }

        protected void Save_btnClick(Object sender, EventArgs e)
        {

            
            con = new DatabaseConnection();

            con.OpenConnection();
            float num = float.Parse(Levelbefore.Text);
            float num2 = float.Parse(Levelafter.Text);

            if (num2<=num)
            {
                Response.Write("<script>alert('Level After must be greater than Level Before')</script>");
            }
            else
            {
                con.ExecuteQueries("select count(FuelID) from Fuel_register where SiteID=" + IdSite.Text + " And DateFueling=" + ADrefueled.Text);
                if(con.cmd.Execute)
                {

                }
                else
                {
                    SaveFuel();
                }
               
            }
                
            
            
           

        }

        
        protected void SaveFuel()
        {
            con.ExecuteQueries("insert into Fuel_register(SiteID,DateFueling,levelBefore,levelAfter,Qty,username,FinRWeek,ReceiptNumber) values('" + IdSite.Text + "', '" + ADrefueled.Text + "', '" + Levelbefore.Text + "', '" + Levelafter.Text + "', '" + Qty.Text + "', '" + username.Text + "','" + FinRWeek.Text + "','" + receiptNumber.Text + "')");

            if (con.x > 0)
            {
                Response.Write("<script>alert('Refueling has been done')</script>");
                
            }
            else
            {
                Response.Write("<script>alert('no refueling')</script>");
               
            }
            con.CloseConnection();
        }

        protected void imageButton_click(object sender, ImageClickEventArgs e)
        {
            calendar.Visible = true;
        }

        protected void calendar_selectionchanged(object sender, EventArgs e)
        {
            ADrefueled.Text = calendar.SelectedDate.ToShortDateString();
            calendar.Visible = false;
        }

       
        
    }

}