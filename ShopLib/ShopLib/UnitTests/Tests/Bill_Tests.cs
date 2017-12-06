using ShopLib.Products;
using ShopLib.UnitTests.Utils;
using System.Collections.Generic;
using Xunit;

namespace ShopLib.UnitTests.Tests
{
    public class Bill_Tests
    {
        [Fact]
        public void Ctor_empyBill()
        {
            var products = new Dictionary<Product, int>();

            var bill = new Bill(products);

            Assert.Empty(bill.items);
        }

        [Fact]
        public void Ctor_emptyBill_0TotalCost()
        {
            //arrange
            var products = new Dictionary<Product, int>();

            //act
            var bill = new Bill(products);

            //assert
            Assert.Equal(0, bill.TotalCost);
        }


        [Fact]
        public void Ctor_2Item_10ReturnTotalCost()
        {
            //arrange

            var products = new Dictionary<Product, int>(); 
            var product1 = RandomData.Create<Candy>();
            var product2 = RandomData.Create<Candy>();
            products.Add(product1, 4);
            products.Add(product2, 6);

            //act
            var bill = new Bill(products);

            //assert
            Assert.Equal(10, bill.TotalCost);
        }
    }
}
