using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ShopLib.Product;

namespace ShopLib
{
    public class Shop
    {
        private ProductManager productManager;
        private Basket basket;

        public Shop()
        {
            productManager = new ProductManager();
            basket = new Basket();

        }
    }
}
