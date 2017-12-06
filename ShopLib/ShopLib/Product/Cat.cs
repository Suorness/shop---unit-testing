using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShopLib.Product
{
    public class Cat: Product
    {
        public override int GetTotalCost()
        {
            return 1;
        }

        public override int GetTotalDiscount()
        {
            return GetTotalCost() * 2;
        }

        //public virtual int GetTotalDiscount2()
        //{
        //    return 1;
        //}

        //public virtual int GetTotalDiscount3()
        //{
        //    return GetTotalDiscount2() * 2;
        //}
    }
}
