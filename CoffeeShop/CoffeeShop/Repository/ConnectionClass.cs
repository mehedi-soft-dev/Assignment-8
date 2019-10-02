using System;
using System.Collections.Generic;
using System.Linq;
using System.Data;
using System.Data.SqlClient;
using System.Text;
using System.Threading.Tasks;

namespace CoffeeShop.Repository
{
    public class ConnectionClass
    {
        string connectionString = @"Server=MH-PC\SQLEXPRESS; Database=CoffeeShop; Integrated Security=True";
        SqlConnection con = null; 

        public SqlConnection CreateConnection()
        {
            con = new SqlConnection(connectionString);

            return con;
        }

        public bool ExecuteQueries(string Query_)
        {
            SqlCommand cmd = new SqlCommand(Query_, con);
            int isExecute = cmd.ExecuteNonQuery();

            if (isExecute > 0)
                return true;
            else
                return false;
        }

        public DataTable ExcecuteDataAdapter(string Query_)
        {
            SqlCommand cmd = new SqlCommand(Query_, con);
            SqlDataAdapter sqlDataAdapter = new SqlDataAdapter(cmd);
            DataTable dataTable = new DataTable();
            sqlDataAdapter.Fill(dataTable);

            return dataTable;
        }
    }
}
