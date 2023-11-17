using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace POS___Inventory_Management
{
    public class Drink : OrderItem
    {
        Boolean hotFlag;
        
        public Drink(int sKU, string productName, string category, decimal price, Boolean hotFlag) : base(sKU, productName, category, price)
        {
            this.hotFlag = hotFlag;
        }
    }
}
