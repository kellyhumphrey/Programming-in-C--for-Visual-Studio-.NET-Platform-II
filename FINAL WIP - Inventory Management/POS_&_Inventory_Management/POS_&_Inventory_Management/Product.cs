// Project: 
// Author: Kelly Humphrey
// Date: 
// Description:
//      Product class is a static class which contains methods that are used to create products, modify products, and decrement the SQL database
//      
//      
//      
//      
//      
//      

using System;
using System.Collections.Generic;
using System.Data.Common;
using System.Data.SqlClient;
using System.Dynamic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace POS___Inventory_Management
{
    public static class Product
    {

        private static SqlConnection myConnection = new SqlConnection("Data Source=(LocalDB)\\MSSQLLocalDB;" +
            "AttachDbFilename=C:\\InventoryDatabase\\Inventory_Database.mdf;" +
            "Integrated Security=True");


        public static void addProductRecord()
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
            }

        //Create Product (add to product table)



        //Add Ingredients (add line item to product ingredient table)

        //Remove Ingredient (remove ingredient from product ingredient table)

        //Verify Product SKU Exists

        //Verify Ingredient SKU exists



















        /*
        string productName;
        string productID;
        decimal aveLaborCost;
        static  int productCounter = 1;

        List<string> ingredientSKU = new List<string>();
        List<int> ingredientAmount = new List<int>();

        public Product(string productName)
        {
            this.productName = productName;
            productCounter++;
            this.productID = "P" + productCounter.ToString();
            //Tech Debt:
                //Consider option to allow manual input of Product ID while verifying it does not conflict with other products.
                // 1. Receive manual input optionally (or auto generate based on counter)
                // 2. Before assignment, process value in "productIDVerification" method
                // 3. "productIDVerification" method should perform SQL Query of Product ID (stripping spaces) and ensuring no matches are found. 
                // Note: Query shoudl not be case sensitive
        }

        public void AddIngredient(string SKU, int amount)
        {
            ingredientSKU.Add(SKU);
            ingredientAmount.Add(amount);
        }

        public Boolean RemoveIngredient(int indexOfItem)
        {
            if (indexOfItem >= 0 && indexOfItem < ingredientSKU.Count)
            {
                ingredientSKU.RemoveAt(indexOfItem);
                return true;
            }
            else
            {
                return false;
            }
        }

        public void printIngredients()
        {
            Console.WriteLine("Ingredient SKUs:");
            foreach (string SKU in ingredientSKU)
            {
                Console.WriteLine(SKU.Trim());
            }
            Console.WriteLine("\n");
            Console.WriteLine("Ingredient Amounts:");
            
            foreach (int amount in ingredientAmount)
            {
                Console.WriteLine(amount);
            }
        } */
    }
}



/*
 * Products should contain a list of ingredients & associated amounts
 * Additionally fields should be price, calculated cost(from ingredients), name, 
 * size (if drink), hot/cold (if food)
 * Methods
 *      Add Ingredient/Amount
 *      Deduct amounts from ingredient inventory (when adding to order)
 *      Add values to inventory (when removing item from Order)
 *      Check if inventory is availalbe for ingredients
 *Sub Classes
 *      Drink
 *      Food
 *      
 *      
 *      
 *      
 *        List<string> itemsList = new List<string>();

        // Adding items
        itemsList.Add("Item 1");
        itemsList.Add("Item 2");

        // Removing items
        itemsList.Remove("Item 1");

        // Iterating through items
        foreach (var item in itemsList)
        {
            Console.WriteLine(item);
        }
*/