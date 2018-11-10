using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LocationArithmetic
{
    /// <summary>
    /// class for interacting with the db with examples of CRUD and search
    /// </summary>
    class DBInteract
    {
        SqlConnection conn = new SqlConnection(Properties.Settings.Default.connection);

        /// <summary>
        /// finds a specifc entry via its orderID
        /// </summary>
        /// <param name="id">the id of the entry being searched for</param>
        public void FindOrderByID(int id)
        {
            string query = String.Format("SELECT * " +
                                         "FROM SalesOrder " +
                                         "WHERE OrderID = {0}", id);
            SqlCommand searchByOrderID = new SqlCommand(query, conn);
            try
            {
                conn.Open();
                SqlDataReader dataReader = searchByOrderID.ExecuteReader();

                SalesOrder salesOrder = new SalesOrder();
                //assuming columns are ordered in same order the columns are created
                salesOrder.OrderID = (int)dataReader.GetValue(0);
                salesOrder.OrderNumber = (int)dataReader.GetValue(1);
                salesOrder.UserName = dataReader.GetValue(2).ToString();

                
                dataReader.Close();

            }
            catch (Exception e)
            {
                Console.WriteLine("An error occured while retrieving order information.\n" + e.StackTrace);
            }
            finally
            {
                conn.Close();
            }
        }

        /// <summary>
        /// Updates the SalesOrderDetails table price column according to the new price
        /// provided
        /// </summary>
        /// <param name="id">id of the entry that is to be updated</param>
        /// <param name="newPrice">the new price</param>
        public void ChangeSalesOrderPriceByID(int id, double newPrice)
        {
            string query = String.Format("UPDATE SalesOrderDetails" +
                                         "SET Price = " + newPrice +
                                         "WHERE OrderID = " + id);
            SqlCommand command = new SqlCommand(query, conn);
            try
            {
                conn.Open();

                command.ExecuteNonQuery();

            }
            catch (Exception e)
            {
                Console.WriteLine("An error occured while updating order price.\n" + e.StackTrace);
            }
            finally
            {
                conn.Close();
            }
        }

        /// <summary>
        /// accepts an id param that corresponds to the entry to be deleted
        /// do not have to explicitly delete the related SalesOrderDetails entry
        /// because of the FK constraint inside of the SalesOrderDetails table
        /// </summary>
        /// <param name="id">id of the entry to be deleted</param>
        public void DeleteEntryByID(int id)
        {
            string orderQuery = String.Format("DELETE FROM SalesOrders" +
                                              "WHERE OrderID = {0}", id);
            SqlCommand orderCommand = new SqlCommand(orderQuery, conn);
            try
            {
                conn.Open();

                orderCommand.ExecuteNonQuery();

            }
            catch (Exception e)
            {
                Console.WriteLine("An error occured while deleting order.\n" + e.StackTrace);
            }
            finally
            {
                conn.Close();
            }
        }

        /// <summary>
        /// creates a new sales order assuming that OrderID, OrderNumber, and Sequence are all
        /// auto incremented values
        /// </summary>
        /// <param name="userName">string representing the user making the order</param>
        /// <param name="description">description of the order(ie. products included)</param>
        /// <param name="price">the price of the order</param>
        public void CreateNewSalesOrder(string userName, string description, double price)
        {
            string orderInsert = String.Format("INSERT INTO SalesOrders (UserName)" +
                               "VALUES ({0}", userName);
            string detailsInsert = String.Format("INSERT INTO SalesOrderDetails (Description, Price)" +
                                                 "VALUES ({0}, {1}", description, price);
            SqlCommand orderCommand = new SqlCommand(orderInsert, conn);
            SqlCommand detailsCommand = new SqlCommand(detailsInsert, conn);

            try
            {
                conn.Open();

                orderCommand.ExecuteNonQuery();
                detailsCommand.ExecuteNonQuery();

            }
            catch (Exception e)
            {
                Console.WriteLine("An error occured while inserting order information.\n" + e.StackTrace);
            }
            finally
            {
                conn.Close();
            }
        }

    }
}
