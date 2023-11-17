using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace POS___Inventory_Management
{
    public class InventoryReport
    {
        private static SqlConnection myConnection = new SqlConnection("Data Source=(LocalDB)\\MSSQLLocalDB;" +
            "AttachDbFilename=C:\\InventoryDatabase\\Inventory_Database.mdf;" +
            "Integrated Security=True");


        List<object> SKU = new List<object>();
        List<object> ingredientName = new List<object>();
        List<object> category = new List<object>();
        List<object> supplier = new List<object>();
        List<object> unitCost = new List<object>();
        List<object> quantityInStock = new List<object>();
        List<object> activeFlag = new List<object>();
        List<object> minimumStockLevel = new List<object>();

        public InventoryReport() {}

        public void printInventoryValue()
        {
            try
            {
                myConnection.Open();

                string myQuery = "SELECT Ingredient_Name, Quantity_In_Stock, Unit_Cost" +
                    "\r\n\tFROM IngredientInventory\r\n\t" +
                    "WHERE Active_Inactive_Flag = 'Active'" +
                    "ORDER BY Ingredient_Name";

                SqlCommand myCommand = new SqlCommand(myQuery, myConnection);
                SqlDataReader reader = myCommand.ExecuteReader();

                ingredientName.Clear();
                quantityInStock.Clear();
                unitCost.Clear();

                while (reader.Read())
                {
                    ingredientName.Add(reader.GetValue(0));
                    quantityInStock.Add(reader.GetValue(1));
                    unitCost.Add(reader.GetValue(2));
                }

            }
            catch (Exception ex)
            {
                Console.WriteLine("SQL Exception Details:");
                Console.WriteLine($"Message: {ex.Message}");


                Console.WriteLine("\nPress <ENTER> to quit...");
                Console.ReadKey();

            }
            finally
            {
                myConnection.Close();

                decimal ingredientValue;
                decimal InventoryValue = 0;
                int quantityInStockDec;
                decimal unitCostDec;

                Console.WriteLine("Below is the Ingredient Inventory sorted by Ingredient Name. Total Inventory Value can be found at the bottom.");
                Console.WriteLine("{0,-20}{1,-1}{2,-20}{3,-1}{4,-20}{5,-1}{6,-20}", "Ingredient Name", "|", "Quantity In Stock", "|", "Unit Cost (est)", "|", "Monetary Value ($)");
                Console.WriteLine("===================================================================================");

                for (int i = 0; i < quantityInStock.Count; i++)
                {
                    try
                    {
                        quantityInStockDec = int.Parse(quantityInStock[i].ToString());
                        unitCostDec = decimal.Parse(unitCost[i].ToString());
                        ingredientValue = quantityInStockDec * unitCostDec;

                        Console.WriteLine("{0,-20}{1,-1}{2,-20}{3,-1}{4,-20}{5,-1}{6,-20}", ingredientName[i], "|", quantityInStockDec.ToString("N"), "|", unitCostDec.ToString("C"), "|", ingredientValue.ToString("C"));
                        InventoryValue = InventoryValue + ingredientValue;
                    }
                    catch (InvalidCastException e)
                    {
                        Console.WriteLine("Conversion to decimal failed: " + e.Message);
                    }
                }

                Console.WriteLine("\n");
                Console.WriteLine("Total Inventory Value is: " + InventoryValue.ToString("C"));

            }
        }


        public void printProductProfitMargin()
        {
            List<object> productSKU = new List<object>();
            List<object> productName = new List<object>();
            List<object> productPrice = new List<object>();
            List<object> productCost = new List<object>();
            List<object> margin = new List<object>();

            try
            {
                myConnection.Open();
                string myQuery = "SELECT PI.Product_SKU, P.Product_Name, P.Product_Price, SUM(PI.Ingredient_Quantity*II.Unit_Cost) AS \"Product_Cost\", P.Product_Price-SUM(PI.Ingredient_Quantity*II.Unit_Cost) AS Margin" +
                    "\r\n    FROM IngredientInventory AS II " +
                    "JOIN ProductIngredients AS PI ON II.SKU = PI.Ingredient_SKU " +
                    "JOIN Product AS P ON P.Product_SKU = PI.Product_SKU " +
                    "GROUP BY PI.Product_SKU, P.Product_Name, P.Product_Price";
                    

                SqlCommand myCommand = new SqlCommand(myQuery, myConnection);
                SqlDataReader reader = myCommand.ExecuteReader();

                while (reader.Read())
                {
                    productSKU.Add(reader.GetValue(0));
                    productName.Add(reader.GetValue(1));
                    productPrice.Add(reader.GetValue(2));
                    productCost.Add(reader.GetValue(3));
                    margin.Add(reader.GetValue(4));
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine("SQL Exception Details:");
                Console.WriteLine($"Message: {ex.Message}");


                Console.WriteLine("\nPress <ENTER> to quit...");
                Console.ReadKey();

            }
            finally
            {
                myConnection.Close();

                Console.WriteLine("{0,-20}{1,-1}{2,-20}{3,-1}{4,-20}{5,-1}{6,-20}{7,-1}{8,-20}", "Product SKU", "|", "Product Name", "|", "Product Price", "|", "Product Cost", "|", "Margin");
                Console.WriteLine("==============================================================================================");

                decimal productPriceDec;
                decimal productCostDec;
                decimal marginDec;

                for (int i = 0; i < productSKU.Count; i++)
                {
                    try
                    {
                        productPriceDec = decimal.Parse(productPrice[i].ToString());
                        productCostDec = decimal.Parse(productCost[i].ToString());
                        marginDec = decimal.Parse(margin[i].ToString());

                        Console.WriteLine("{0,-20}{1,-1}{2,-20}{3,-1}{4,-20}{5,-1}{6,-20}{7,-1}{8,-20}", productSKU[i], "|", productName[i], "|", productPriceDec.ToString("C"), "|", productCostDec.ToString("C"), "|", marginDec.ToString("C"));
                    }
                    catch (InvalidCastException e)
                    {
                        Console.WriteLine("Conversion to decimal failed: " + e.Message);
                    }
                }
            }


        }

    }
}
