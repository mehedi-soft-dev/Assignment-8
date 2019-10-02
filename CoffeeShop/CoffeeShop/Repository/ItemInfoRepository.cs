using System;
using System.Collections.Generic;
using System.Linq;
using System.Data;
using System.Data.SqlClient;
using System.Text;
using System.Threading.Tasks;
using CoffeeShop.Model;

namespace CoffeeShop.Repository
{
    public class ItemInfoRepository
    {
        public bool AddItem(Item item)
        {
            string commandString = @"INSERT INTO Items (Name, Price) VALUES('" + item.Name + "'," + item.Price + ")";
            SqlConnection sqlConnection = null;

            ConnectionClass connectionClass = new ConnectionClass();
            sqlConnection = connectionClass.CreateConnection();

            sqlConnection.Open();

            bool isAdded = connectionClass.ExecuteQueries(commandString);

            sqlConnection.Close();

            return isAdded;
        }

        public DataTable Display()
        {
            string commandString = @"SELECT * FROM Items";
            SqlConnection sqlConnection = null;

            ConnectionClass connectionClass = new ConnectionClass();
            sqlConnection = connectionClass.CreateConnection();

            sqlConnection.Open();

            DataTable dataTable = connectionClass.ExcecuteDataAdapter(commandString);

            sqlConnection.Close();

            return dataTable;
        }

        public bool IsItemExist(Item item)
        {
            string commandString = @"SELECT * FROM Items WHERE Name='" + item.Name + "'";
            SqlConnection sqlConnection = null;

            ConnectionClass connectionClass = new ConnectionClass();
            sqlConnection = connectionClass.CreateConnection();

            sqlConnection.Open();

            DataTable result = connectionClass.ExcecuteDataAdapter(commandString);

            sqlConnection.Close();

            if (result.Rows.Count > 0)
                return true;
            else
                return false;
        }

        public DataTable SearchItemByName(Item item)
        {
            string commandString = @"SELECT * FROM Items WHERE Name = '" + item.Name + "'";
            SqlConnection sqlConnection = null;

            ConnectionClass connectionClass = new ConnectionClass();
            sqlConnection = connectionClass.CreateConnection();

            sqlConnection.Open();

            DataTable dataTable = connectionClass.ExcecuteDataAdapter(commandString);

            sqlConnection.Close();

            return dataTable;
        }

        public DataTable SearchItemById(Item item)
        {
            string commandString = @"SELECT * FROM Items WHERE ID = '" + item.ID + "'";
            SqlConnection sqlConnection = null;

            ConnectionClass connectionClass = new ConnectionClass();
            sqlConnection = connectionClass.CreateConnection();

            sqlConnection.Open();

            DataTable dataTable = connectionClass.ExcecuteDataAdapter(commandString);

            sqlConnection.Close();

            return dataTable;
        }

        public bool DeleteItem(Item item)
        {
            string commandString = @"DELETE FROM Items WHERE ID = " + item.ID + "";
            SqlConnection sqlConnection = null;

            ConnectionClass connectionClass = new ConnectionClass();
            sqlConnection = connectionClass.CreateConnection();

            sqlConnection.Open();

            bool isDeleted = connectionClass.ExecuteQueries(commandString);

            sqlConnection.Close();

            return isDeleted;
        }

        public bool UpdateItem(Item item)
        {
            string commandString = @"UPDATE Items SET Name = '" + item.Name + "', Price = " + item.Price + " WHERE ID = " + item.ID + "";
            SqlConnection sqlConnection = null;

            ConnectionClass connectionClass = new ConnectionClass();
            sqlConnection = connectionClass.CreateConnection();

            sqlConnection.Open();

            bool isUpdated = connectionClass.ExecuteQueries(commandString);

            sqlConnection.Close();

            return isUpdated;
        }
    }
}
