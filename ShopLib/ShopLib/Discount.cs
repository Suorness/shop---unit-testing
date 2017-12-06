using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShopLib
{
    public class Discount
    {
        public int ProductCount { get; internal set; }
        public int DicountedPrice { get; internal set; }

        public virtual int CountPriceWithDiscount(int count)
        {
            int result = 0;
            if (ProductCount > 0)
            {
                result = count / ProductCount;
                result *= DicountedPrice;
            }

            return result;
        }
    }
}
