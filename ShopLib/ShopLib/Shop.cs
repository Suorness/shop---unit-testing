
using ShopLib.Products;

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
