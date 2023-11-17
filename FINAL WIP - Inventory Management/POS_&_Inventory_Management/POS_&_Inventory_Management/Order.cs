using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace POS___Inventory_Management
{
    public class Order
    {
        String status;          //Open, closed, cancelled.
        Decimal subTotal;        //calculated by summing item costs gathered by get method
        Decimal tax;             //9.5 percentage
        Decimal total;
        Decimal taxRate = 0.095M;
        List<Object> OrderItems = new List<Object>();   //Practicing the use of a generic to hold order items



        private static SqlConnection sqlConnection = new
            SqlConnection("Data Source=(LocalDB)\\MSSQLLocalDB);" +
            "AttachDbFilename=C:\\Users\\kelly\\Downloads\\C# Part 2\\" +
            "Week 10 - FINAL\\Solutions\\POS & Inventory Management\\Inventory_Database.mdf;" +
            "Integrated Security=True");

        public void openDBConnection()
        {
           
        }


        public void addOrderItem<T>(ref T orderItem)
        {
            OrderItems.Add(orderItem);
        }
        
        public void calculateSalesAmounts(List<OrderItem> orderItems)
        {
            //For each orderItem in list orderItems, use a get method to extract the cost, and sum the total
            subTotal = 0.00M;

            foreach (OrderItem orderItem in OrderItems)
            {
                //subTotal = subTotal + orderItem.getPrice();
            }

            tax = subTotal * taxRate;
            total = subTotal + tax;
        }

        public Decimal getSubTotal() { return subTotal; }
        public Decimal getTax() { return tax; } 
        public Decimal getTotal() { return total; }
        public List<object> getOrderItems() {return OrderItems; }

    }

}







/*
 * 
 * 
 *  try
            {
                sqlConnection.Open();
                //lblStatus.Text = "Connection Opened";
            }
            catch (SqlException ex)
            {
                // Display error
                //lblStatus.Text = $"Error SqlExecepton: {ex.Message}";
            }

            //Create Command object
            SqlCommand nonqueryCommand = sqlConnection.CreateCommand();
            
            try
            {
                SqlCommand cmRegion = new SqlCommand();
                cmRegion.CommandText = "dbo.InsertRegionData";
                cmRegion.CommandType = CommandType.StoredProcedure;
                cmRegion.Connection = sqlConnection;
                SqlParameter paramRegionID = new SqlParameter();
                paramRegionID.ParameterName = "@RegionID";
                paramRegionID.SqlDbType = SqlDbType.Int;
                paramRegionID.Direction = ParameterDirection.Input;
                cmRegion.Parameters.Add(paramRegionID);
                SqlParameter paramRegionDescription = new SqlParameter();
                paramRegionDescription.ParameterName = "@RegionDescription";
                paramRegionDescription.SqlDbType = SqlDbType.NVarChar;
                paramRegionDescription.Size = 50;
                paramRegionDescription.Direction = ParameterDirection.Input;
                cmRegion.Parameters.Add(paramRegionDescription);
                cmRegion.Parameters["@RegionID"].Value =
                Convert.ToInt32(txtRegionID.Text);
                cmRegion.Parameters["@RegionDescription"].Value =
                txtRegionDescription.Text;
                cmRegion.ExecuteNonQuery();
                lblStatus.Text = "Region data added " +
                (++countInserts).ToString();
            }
            catch (SqlException ex)
            {
                // Display error
                lblStatus.Text = $"Error: {ex.Message}";
            }
            finally
            {
                // Close connection immediately to avoid problem of memory leaks...
                sqlConnection.Close();
            }
*/



/*
 * Orders will contain list of type product.
 * Products can be added/removed
 * Calculate the subtotal, tax, and total. 
 * Calculations should be made at point of adding a product to order. 
 * 
 * 
 * 
 * 
 * 
 * 
 * class Program
{
    static void Main()
    {
      
    }
}
Using HashSet<T>:
*/