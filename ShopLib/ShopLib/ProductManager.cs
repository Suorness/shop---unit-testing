
using System.Collections.Generic;


namespace ShopLib.Products
{
    public class ProductManager
    {
        private List<Product> allProducts;
        //id и скидка 
        private Dictionary<int, Discount> discounts;


        public ProductManager()
        {
            allProducts = new List<Product>();
            discounts = new Dictionary<int, Discount>();
        }


        public void AddProduct(Product product)
        {
            allProducts.Add(product);
        }


        public void DeleteProduct(Product product)
        {
            allProducts.Remove(product);
        }


        //public IEnumerator<Product> GetPrice()
        //{
        //    var price = allProducts.GetEnumerator();
        //    return price;
        //}


        public void AddDiscount(int id, Discount discount)
        {
            if (discounts.ContainsKey(id))
            {
                discounts[id] = discount;
            }
            else
            {
                discounts.Add(id, discount);
            }
        }


        public void Delete(int id)
        {
            if (discounts.ContainsKey(id))
            {
                discounts.Remove(id);
            }
        }


    }
}
