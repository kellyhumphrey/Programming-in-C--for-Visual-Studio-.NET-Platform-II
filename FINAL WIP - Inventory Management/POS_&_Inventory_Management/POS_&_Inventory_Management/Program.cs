// Project: 
// Author: Kelly Humphrey
// Date: 
// Description:
//      The intention of this program is to manage inventory items which correspond to ingredients of a products sold in a coffee shop. 
//      The program connects to a Microsoft SQL Server file (stored locally).
//      
//      
//      Product class is created to hold ingredients and corresponding amounts. 
//      
//      
//      
//      
//      
//      
//      
//      
//      
//      
//      


using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Runtime.Remoting.Messaging;
using System.Text;
using System.Threading.Tasks;

namespace POS___Inventory_Management
{
    public class Program
    {
        static void Main(string[] args)
        {
            /*InventoryReport myReport = new InventoryReport();
            myReport.printInventoryValue();

            Console.WriteLine("\nPress <ENTER> to quit...");
            Console.ReadKey();

            myReport.printProductProfitMargin();
            */

            /*
            List<object> myTestList = new List<object>() {1234,2345,3456,4567,5678,6789};

            foreach(object item in myTestList) 
            {
                Console.WriteLine("Value: " + item + " ---- Index Value: " + myTestList.IndexOf(item));
            }


            Console.WriteLine("\nPress <ENTER> to quit...");
            Console.ReadKey();

            myTestList.RemoveAt(3);
            foreach (object item in myTestList)
            {
                Console.WriteLine("Value: " + item + " ---- Index Value: " + myTestList.IndexOf(item));
            }


            Console.WriteLine("\nPress <ENTER> to quit...");
            Console.ReadKey();
            */
            Product myProduct = new Product("MyProduct");
            myProduct.AddIngredient("P001", 1);
            myProduct.AddIngredient("P002", 2);
            myProduct.AddIngredient("P003", 3);
            myProduct.AddIngredient("P004", 4);
            myProduct.AddIngredient("P005", 5);
            myProduct.printIngredients();

            Console.WriteLine("\nPress <ENTER> to quit...");
            Console.ReadKey();




        }
    }
}
