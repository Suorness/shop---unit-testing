using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShopLib.Product
{
    public abstract class Product
    {
        public int Cost { get; private set; }
        public String Name { get; set; }
        public int Id { get; set; }
        public int Count { get; set; }

        public abstract int GetTotalCost();
        public abstract int GetTotalDiscount();


    }
}
