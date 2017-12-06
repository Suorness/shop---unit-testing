using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShopLib.Product
{
    public class Basket
    {
        //id и product
        private Dictionary<int, Product> items;

        public void Add(Product product)
        {
            if (items.ContainsKey(product.Id))
            {
                items[product.Id].Count++;
            }
            else
            {
                items.Add(product.Id, product);
            }
        }


        public void Remove(Product product, int count = 1)
        {
            if (items.ContainsKey(product.Id))
            {
                items[product.Id].Count -= count;
                if (items[product.Id].Count <= 0)
                {
                    items.Remove(product.Id);
                }
            }
        }


        public void Delete(Product product)
        {
            if (items.ContainsKey(product.Id))
            {
                Remove(product, items[product.Id].Count);
            }
        }
        

        public Basket()
        {
            items = new Dictionary<int, Product>();
        }


        //id и скидка к соответствующему товару
        public Bill CalculateBill(Dictionary<int, Discount> discounts)
        {
            int totalCost;
            var itemsOnBill = new Dictionary<int, Product>();
            foreach(var item in items)
            {
                totalCost = item.Value.GetTotalCost();
                totalCost -= GetDiscount(item.Value, discounts);
                itemsOnBill.Add(totalCost, item.Value);
            }
            var result = new Bill(itemsOnBill);
            return result;
        }

        public int GetDiscount(Product product, Dictionary<int, Discount> discounts)
        {
            int result = 0;
            if (discounts.ContainsKey(product.Id))
            {
                var discount = discounts[product.Id];
                result = discount.CountPriceWithDiscount(product.Count);

            }
            return result;
        }
    }
}
