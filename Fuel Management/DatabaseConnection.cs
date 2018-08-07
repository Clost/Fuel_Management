
using System.Data;
using System.Data.SqlClient;
using System.Configuration;

namespace Fuel_Management
{
    public class DatabaseConnection
    {
        string connectionString = @"Data Source=.;Integrated Security= true;Initial Catalog=FuelManagement";
        SqlConnection connect;
        public SqlCommand cmd;
        SqlDataAdapter dr;
        public SqlDataReader rd;
        public DataTable dt;
        public int x;

        public void OpenConnection()
        {
            connect = new SqlConnection(connectionString);
            connect.Open();
        }

        public void CloseConnection()
        {
            connect.Close();
        }

        public void ExecuteQueries(string Query)
        {
            cmd = new SqlCommand(Query, connect);
           
            x = cmd.ExecuteNonQuery();
        }

        public SqlDataReader DataReader(string Query)
        {
            cmd = new SqlCommand(Query, connect);
            rd = cmd.ExecuteReader();
            return rd;

        }

        public object QueryDropdownList(string Query)
        {
            cmd.CommandType = CommandType.Text;
            dr = new SqlDataAdapter(cmd);
            DataSet ds = new DataSet();
            dr.Fill(ds);
            object datum = ds.Tables[0];
            return datum;
        }

        public object ShowDataInGridView(string Query)
        {
            dr = new SqlDataAdapter(Query, connectionString);
            dt = new DataTable();
            dr.Fill(dt);
            object datum = dt;
            return datum;
        }
        public void NonQueryEx()
        {
            cmd.ExecuteNonQuery();
        }

        public DataTable QueryEx()
        {
            dr = new SqlDataAdapter(cmd);
            dt = new DataTable();
            dr.Fill(dt);
            return dt;
        }

       
    }

    
}