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
    public class OrderInfoRepository
    {
        public bool AddOrder(Order order)
        {
            string commandString = @"INSERT INTO Orders (CustomerId, ItemId, Quantity, TotalPrice) VALUES(" + order.CustomerId + "," + order.ItemId + "," + order.Quantity + ", " + order.TotalPrice + ")";
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
            string commandString = @"SELECT o.ID, c.Name AS Customer, i.Name AS Item, Quantity, TotalPrice FROM Orders AS o LEFT JOIN Customers AS c ON c.ID = o.CustomerID LEFT JOIN Items AS i ON i.ID = o.ItemID";
            SqlConnection sqlConnection = null;

            ConnectionClass connectionClass = new ConnectionClass();
            sqlConnection = connectionClass.CreateConnection();

            sqlConnection.Open();

            DataTable dataTable = connectionClass.ExcecuteDataAdapter(commandString);

            sqlConnection.Close();

            return dataTable;
        }

        public bool IsOrderExist(Order order)
        {
            string commandString = @"SELECT * FROM Orders WHERE ID='" + order.ID + "'";
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

        public DataTable SearchOrderByName(Order order)
        {
            string commandString = @"SELECT * FROM Orders WHERE Name = '" + order.CustomerId + "'";
            SqlConnection sqlConnection = null;

            ConnectionClass connectionClass = new ConnectionClass();
            sqlConnection = connectionClass.CreateConnection();

            sqlConnection.Open();

            DataTable dataTable = connectionClass.ExcecuteDataAdapter(commandString);

            sqlConnection.Close();

            return dataTable;
        }

        public DataTable SearchOrderById(Order order)
        {
            string commandString = @"SELECT o.ID, c.Name AS Customer, i.Name AS Item, Quantity, TotalPrice FROM Orders AS o LEFT JOIN Customers AS c ON c.ID = o.CustomerID LEFT JOIN Items AS i ON i.ID = o.ItemID WHERE CustomerId = '" + order.CustomerId + "'";
            SqlConnection sqlConnection = null;

            ConnectionClass connectionClass = new ConnectionClass();
            sqlConnection = connectionClass.CreateConnection();

            sqlConnection.Open();

            DataTable dataTable = connectionClass.ExcecuteDataAdapter(commandString);

            sqlConnection.Close();

            return dataTable;
        }

        public bool DeleteOrder(Order order)
        {
            string commandString = @"DELETE FROM Orders WHERE ID = " + order.ID + "";
            SqlConnection sqlConnection = null;

            ConnectionClass connectionClass = new ConnectionClass();
            sqlConnection = connectionClass.CreateConnection();

            sqlConnection.Open();

            bool isDeleted = connectionClass.ExecuteQueries(commandString);

            sqlConnection.Close();

            return isDeleted;
        }

        public bool UpdateOrder(Order order)
        {
            string commandString = @"UPDATE Orders SET CustomerID = " + order.CustomerId + ", ItemID = " + order.ItemId + ", Quantity = " + order.Quantity + ", TotalPrice = " + order.TotalPrice + " WHERE ID = " + order.ID + "";
            SqlConnection sqlConnection = null;

            ConnectionClass connectionClass = new ConnectionClass();
            sqlConnection = connectionClass.CreateConnection();

            sqlConnection.Open();

            bool isUpdated = connectionClass.ExecuteQueries(commandString);

            sqlConnection.Close();

            return isUpdated;
        }

        public DataTable CustomerCombo()
        {
            string commandString = @"SELECT ID, Name FROM Customers";
            SqlConnection sqlConnection = null;

            ConnectionClass connectionClass = new ConnectionClass();
            sqlConnection = connectionClass.CreateConnection();

            sqlConnection.Open();

            DataTable dataTable = connectionClass.ExcecuteDataAdapter(commandString);

            sqlConnection.Close();

            return dataTable;
        }

        public DataTable ItemCombo()
        {
            string commandString = @"SELECT ID, Name FROM Items";
            SqlConnection sqlConnection = null;

            ConnectionClass connectionClass = new ConnectionClass();
            sqlConnection = connectionClass.CreateConnection();

            sqlConnection.Open();

            DataTable dataTable = connectionClass.ExcecuteDataAdapter(commandString);

            sqlConnection.Close();

            return dataTable;
        }
    }
}
