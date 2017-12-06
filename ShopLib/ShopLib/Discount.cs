using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShopLib
{
    public class Discount
    {
        public int ProductCount { get; private set; }
        public int DicountedPrice { get; private set; }

        public  int CountPriceWithDiscount(int count)
        {
            int result = 0;

            result = count / ProductCount;

            result *= DicountedPrice;

            return result;
        }
    }
}
