using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Fuel_Management
{
    public partial class Site : System.Web.UI.MasterPage
    {
        protected void Page_Load(object sender, EventArgs e)
        {

            if (!Page.IsPostBack)
            {

                if (Session["user"] != null)
                {
                    title.Text = "Hi " + Session["user"].ToString();

                    Response.Cache.SetExpires(DateTime.UtcNow.AddDays(-1));
                    Response.Cache.SetCacheability(HttpCacheability.NoCache);
                    Response.Cache.SetNoStore();

                    Response.ClearHeaders();
                    Response.AddHeader("Cache-Control", "no-cache, no-store, max-age=0, must-revalidate");
                    Response.AddHeader("Pregma", "no-cache");

                }

            }
            Response.Cache.SetExpires(DateTime.UtcNow.AddDays(-1));
            Response.Cache.SetCacheability(HttpCacheability.NoCache);
            Response.Cache.SetNoStore();

            Response.ClearHeaders();
            Response.AddHeader("Cache-Control", "no-cache, no-store, max-age=0, must-revalidate");
            Response.AddHeader("Pregma", "no-cache");
            Response.AppendHeader("Refresh", Convert.ToString((Session.Timeout * 2)) + ";URL=LoginPage.aspx");

        }

                

        protected void Logout_btnClick(Object sender, EventArgs e)
        {
            Session.Abandon();
            Session.Clear();
            Session["user"] = null;
            Session.RemoveAll();
            Response.Redirect("~/LoginPage.aspx");
        }
    }
}