using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data.SqlClient;
using System.Data;
using Excel = Microsoft.Office.Interop.Excel;

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
                gridManage.DataSource = con.dt;
                gridManage.DataBind();

                Console.WriteLine(con.dt);


                DropDownList1.Items.Insert(0, new ListItem("--Select--"));
                DropDownList1.Items.Insert(1, new ListItem("Site"));
                DropDownList1.Items.Insert(2, new ListItem("Date Fueling"));
                DropDownList1.Items.Insert(3, new ListItem("Username"));
               
            }


        }

        protected void Btn_Add(Object sender, EventArgs e)
        {
            Response.Redirect("~/FuelRegister.aspx");
        }

        protected void Button1_Click(object sender, EventArgs e)
        {

            con = new DatabaseConnection();
            con.OpenConnection();

            con.ShowDataInGridView("select * from Fuel_register");
            gridManage.DataSource = con.dt;
            gridManage.DataBind();

            Console.WriteLine(con.dt);
        }

        protected void DropDownList1_SelectedIndexChanged(object sender, EventArgs e)
        {
            string s = DropDownList1.Items[DropDownList1.SelectedIndex].Value.ToString();
            if (s=="Site")
            {
                con = new DatabaseConnection();
                con.OpenConnection();

                con.ExecuteQueries("select * from Fuel_register");
                foreach (DataRow dr in con.QueryEx().Rows)
                {
                    DropDownList2.Items.Add(dr[1].ToString());
                }
            }
            
            else if (s == "Date Fueling")
            {
                con = new DatabaseConnection();
                con.OpenConnection();

                con.ExecuteQueries("select * from Fuel_register");
                foreach (DataRow dr in con.QueryEx().Rows)
                {
                    DropDownList2.Items.Add(dr[3].ToString());

                }
            }
            else if (s == "Username")
            {
                con = new DatabaseConnection();
                con.OpenConnection();

                con.ExecuteQueries("select * from Fuel_register");
                foreach (DataRow dr in con.QueryEx().Rows)
                {
                    DropDownList2.Items.Add(dr[7].ToString());

                }
            }
           
            
        }

        protected void DropDownList2_SelectedIndexChanged(object sender, EventArgs e)
        {
            con = new DatabaseConnection();
            con.OpenConnection();

            string s = DropDownList1.Items[DropDownList1.SelectedIndex].Value.ToString();
            if (s == "Site")
            {
                con.ShowDataInGridView("select * from Fuel_register where SiteID LIKE '%"+DropDownList2.Text+"%'");
                gridManage.DataSource = con.dt;
                gridManage.DataBind();

                Console.WriteLine(con.dt);
            }
            else if(s == "Date Fueling")
            {
                con.ShowDataInGridView("select * from Fuel_register where DateFueling LIKE '%" + DropDownList2.Text + "%'");
                gridManage.DataSource = con.dt;
                gridManage.DataBind();

                Console.WriteLine(con.dt);
            }
            else if (s == "Username")
            {
                con.ShowDataInGridView("select * from Fuel_register where username LIKE '%" + DropDownList2.Text + "%'");
                gridManage.DataSource = con.dt;
                gridManage.DataBind();

                Console.WriteLine(con.dt);
            }

            
        }

        

        protected void Export_Click(object sender, EventArgs e)
        {
            //ExportToExcel();
        }

        /// Exports the datagridview values to Excel. 
        /// </summary> 
       
    }

}