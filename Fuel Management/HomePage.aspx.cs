using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data.SqlClient;
using System.Data;
using System.Drawing;
using System.Windows;
using System.Configuration;
using Excel = Microsoft.Office.Interop.Excel;
using System.IO;

namespace Fuel_Management
{
    public partial class HomePage : System.Web.UI.Page
    {
        private DatabaseConnection con;
        int FuelID = 0;

       

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {

                this.BindGrid();


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

            this.BindGrid();
        }

        protected void DropDownList1_SelectedIndexChanged(object sender, EventArgs e)
        {
            string s = DropDownList1.Items[DropDownList1.SelectedIndex].Value.ToString();
            if (s=="Site")
            {
                selectInFuelRegister();
                foreach (DataRow dr in con.QueryEx().Rows)
                {
                    DropDownList2.Items.Clear();
                    DropDownList2.Items.Add(dr[8].ToString());
                }
            }
            
            else if (s == "Date Fueling")
            {
                selectInFuelRegister();
                DropDownList2.Items.Clear();
                foreach (DataRow dr in con.QueryEx().Rows)
                {
                    
                    DropDownList2.Items.Add(dr[1].ToString());

                }
            }
            else if (s == "Username")
            {
                selectInFuelRegister();
                DropDownList2.Items.Clear();
                foreach (DataRow dr in con.QueryEx().Rows)
                {
                    
                    DropDownList2.Items.Add(dr[5].ToString());

                }
            }
           
            
        }

        protected void selectInFuelRegister()
        {
            con = new DatabaseConnection();
            con.OpenConnection();

            con.ExecuteQueries("select * from Fuel_register");
        }

        protected void DropDownList2_SelectedIndexChanged(object sender, EventArgs e)
        {
            con = new DatabaseConnection();
            con.OpenConnection();

            string s = DropDownList1.Items[DropDownList1.SelectedIndex].Value.ToString();
            if (s == "Site")
            {
                con.ShowDataInGridView("select e.SiteID, Cluster, Region,DateFueling, levelBefore,levelAfter,Qty,username,FinRWeek,ReceiptNumber from Fuel_register e, Site t, tabl_cluster1 c where e.SiteID = t.SiteID and t.SiteID=c.SiteID And e.SiteID LIKE '%" + DropDownList2.Text+"%'");
                gridManage.DataSource = con.dt;
                gridManage.DataBind();

                Console.WriteLine(con.dt);
            }
            else if(s == "Date Fueling")
            {
                con.ShowDataInGridView("select e.SiteID,Cluster, Region,DateFueling, levelBefore,levelAfter,Qty,username,FinRWeek,ReceiptNumber from Fuel_register e, Site t, tabl_cluster1 c where e.SiteID = t.SiteID and t.SiteID=c.SiteID And DateFueling LIKE ' % " + DropDownList2.Text + "%'");
                gridManage.DataSource = con.dt;
                gridManage.DataBind();

                Console.WriteLine(con.dt);
            }
            else if (s == "Username")
            {
                con.ShowDataInGridView("select e.SiteID,Cluster, Region,DateFueling, levelBefore,levelAfter,Qty,username,FinRWeek,ReceiptNumber from Fuel_register e, Site t,tabl_cluster1 c where e.SiteID = t.SiteID and t.SiteID=c.SiteID And username LIKE ' % " + DropDownList2.Text + "%'");
                gridManage.DataSource = con.dt;
                gridManage.DataBind();

                Console.WriteLine(con.dt);
            }

            
        }

        protected void OnPageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            gridManage.PageIndex = e.NewPageIndex;
            this.BindGrid();
        }

        private void BindGrid()
        {
            con = new DatabaseConnection();
            con.OpenConnection();

            con.ShowDataInGridView("select e.SiteID, Cluster, Region,DateFueling, levelBefore,levelAfter,Qty,username,FinRWeek,ReceiptNumber from Fuel_register e, Site t, tabl_cluster1 c where e.SiteID = t.SiteID and t.SiteID=c.SiteID");
            gridManage.DataSource = con.dt;
            gridManage.DataBind();

            Console.WriteLine(con.dt);
        }

        protected void Export_Click(object sender, EventArgs e)
        {
            Response.Clear();
            Response.Buffer = true;
            Response.AddHeader("content-disposition", "attachment;filename=GridViewExport.xls");
            Response.Charset = "";
            Response.ContentType = "application/vnd.ms-excel";
            using (StringWriter sw = new StringWriter())
            {
                HtmlTextWriter hw = new HtmlTextWriter(sw);

                //To Export all pages
                gridManage.AllowPaging = false;
                this.DataBind();

                gridManage.HeaderRow.BackColor = Color.White;
                foreach (TableCell cell in gridManage.HeaderRow.Cells)
                {
                    cell.BackColor = gridManage.HeaderStyle.BackColor;
                }
                foreach (GridViewRow row in gridManage.Rows)
                {
                    row.BackColor = Color.White;
                    foreach (TableCell cell in row.Cells)
                    {
                        if (row.RowIndex % 2 == 0)
                        {
                            cell.BackColor = gridManage.AlternatingRowStyle.BackColor;
                        }
                        else
                        {
                            cell.BackColor = gridManage.RowStyle.BackColor;
                        }
                        cell.CssClass = "textmode";
                    }
                }

                gridManage.RenderControl(hw);

                //style to format numbers to string
                string style = @"<style> .textmode { } </style>";
                Response.Write(style);
                Response.Output.Write(sw.ToString());
                Response.Flush();
                Response.End();
            }
        }

        public override void VerifyRenderingInServerForm(Control control)
        {
            /* Verifies that the control is rendered */
        }

       
        protected void gridManage_RowDeleting(object sender, GridViewDeleteEventArgs e)
        {
            string FuelID = e.Keys["FuelID"].ToString();

            con.ExecuteQueries("Delete from Fuel_register where FuelID =" + FuelID);
            con.OpenConnection();

            if (con.cmd.ExecuteNonQuery() > 0)
            {
                Response.Write("Record Deleted Sucessfully!!!");
                this.BindGrid();
            }
            else
            {
                Response.Write("Record Deleting Failed!!!");

            }
            con.CloseConnection();
        }

        protected void gridManage_RowEditing(object sender, GridViewEditEventArgs e)
        {

        }
    }

       
    

}