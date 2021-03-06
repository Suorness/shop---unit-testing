﻿using System.Collections.Generic;

namespace ShopLib.Products
{
    public class Basket
    {
        //id и product
        internal Dictionary<int, Product> items;

        public void Add(Product product)
        {
            if (items.ContainsKey(product.Id))
            {
                items[product.Id].Count += product.Count;
            }
            else
            {
                items.Add(product.Id, product);
            }
        }


        public void Remove(Product product, int count = 1)
        {
            if ( (items.ContainsKey(product.Id)) && (count >= 0) )
            {
                items[product.Id].Count -= count;
                if (items[product.Id].Count <= 0)
                {
                    items.Remove(product.Id);
                }
            }
        }


        //public void Delete(Product product)
        //{
        //    if (items.ContainsKey(product.Id))
        //    {
        //        Remove(product, items[product.Id].Count);
        //    }
        //}
        

        public Basket()
        {
            items = new Dictionary<int, Product>();
        }


        //id и скидка к соответствующему товару
        public Bill CalculateBill(Dictionary<int, Discount> discounts)
        {
            var itemsOnBill = new Dictionary<Product, int>();
            foreach(var item in items)
            {
                int totalCost = Discounting(item.Value, discounts);
                itemsOnBill.Add(item.Value, totalCost);
            }
            var result = new Bill(itemsOnBill);
            return result;
        }

        internal int Discounting(Product product, Dictionary<int, Discount> discounts)
        {
            var result = 0;

            result = GetCost(product);
            result -= GetDiscount(product, discounts);

            return result;

        }

        public virtual int GetDiscount(Product product, Dictionary<int, Discount> discounts)
        {
            int result = 0;
            if (discounts.ContainsKey(product.Id))
            {
                var discount = discounts[product.Id];
                result = discount.CountPriceWithDiscount(product.Count);

            }
            return result;
        }

        public virtual int GetCost(Product product)
        {
            int result = 0;

            if ((product.Cost > 0) && (product.Count > 0) )
            {
                result = product.Cost * product.Count;
            }
            return result;
        }
    }
}
