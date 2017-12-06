using System;

namespace ShopLib.Products
{
    public abstract class Product
    {
        public int Cost { get; private set; }
        public String Name { get; set; }
        public int Id { get; set; }
        public int Count { get; set; }

    }
}
