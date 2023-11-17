using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace POS___Inventory_Management
{
    public class OrderItem
    {
        int SKU;
        String ProductName;
        Decimal Price;
        String Category;

        public OrderItem(int sKU, string productName, string category, decimal price)
        {
            SKU = sKU;
            ProductName = productName;
            Category = category;
            Price = price;

        }

        public void addProduct(String ingredient)
        {
            
        }

    }



    



}
