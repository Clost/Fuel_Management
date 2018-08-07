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
            con.CloseConnection();
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

            con.CloseConnection();
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

            con.ShowDataInGridView("select FuelID, e.SiteID, Cluster, Region,DateFueling, levelBefore,levelAfter,Qty,username,FinRWeek,ReceiptNumber from Fuel_register e, Site t, tabl_cluster1 c where e.SiteID = t.SiteID and t.SiteID=c.SiteID");
            gridManage.DataSource = con.dt;
            gridManage.DataBind();

            Console.WriteLine(con.dt);

            con.CloseConnection();
        }

        protected void Export_Click(object sender, EventArgs e)
        {
            Response.ClearContent();
            Response.AddHeader("content-disposition", "attachment;filename=GridViewExport.xls");
            Response.ContentType = "application/vnd.ms-excel";

            StringWriter sw = new StringWriter();
            
            HtmlTextWriter hw = new HtmlTextWriter(sw);

                //To Export all pages
                gridManage.AllowPaging = false;
                this.DataBind();

          
            gridManage.RenderControl(hw);
            
                Response.Write(sw.ToString());
                
                Response.End();
            
        }

        public override void VerifyRenderingInServerForm(Control control)
        {
            /* Verifies that the control is rendered */
        }

       
        

        protected void gridManage_RowEditing(object sender, GridViewEditEventArgs e)
        {

        }

        protected void lnkRemove_Click(object sender, EventArgs e)
        {
            try
            {
                con = new DatabaseConnection();
                LinkButton lnk = sender as LinkButton;
                GridViewRow gridViewRow = lnk.NamingContainer as GridViewRow;
                int FuelID = Convert.ToInt32(gridManage.DataKeys[gridViewRow.RowIndex].Value.ToString());
                con.OpenConnection();
                con.ExecuteQueries("delete from [Fuel_register] where FuelID=" + FuelID);
                int a = con.cmd.ExecuteNonQuery();
                con.CloseConnection();
                BindGrid();
                if (a > 0)
                {
                    Response.Write("<script>alert('Record Deleted Sucessfully!!!')</script>");
                }
            }catch(Exception)
            {
                Response.Write("<script>alert('empty')</script>");
            }
        }

        protected void gridManage_RowDataBound(object sender, GridViewRowEventArgs e)
        {
            if(e.Row.RowType==DataControlRowType.DataRow)
            {
                string SiteID = Convert.ToString(DataBinder.Eval(e.Row.DataItem, "SiteID"));
                LinkButton lnkbutton = (LinkButton)e.Row.FindControl("lnkRemove");
                lnkbutton.Attributes.Add("onclick", "JavaScript:return ConfirmationBox('" + SiteID + "')");
                
            }
        }
    }

       
    

}