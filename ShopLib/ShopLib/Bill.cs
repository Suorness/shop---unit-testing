using System.Collections.Generic;

namespace ShopLib.Products
{
    public class Bill
    {
        /// <summary>
        /// цена полностью и товар?
        /// </summary>
        public readonly Dictionary<Product, int> items;
        
        public int TotalCost { get; internal set; }

        public Bill(Dictionary<Product, int> items)  
        {
            this.items = items;
            
            foreach(var item in items)
            {
                TotalCost += item.Value;
            }
        }
    }
}
