using ShopLib.Products;
using ShopLib.UnitTests.Utils;
using System.Collections.Generic;
using System.Linq;
using Xunit;

namespace ShopLib.UnitTests.Tests
{
    public class Basket_Tests
    {
        [Fact]
        public void Add_1Item_1ItemReturn()
        {
            //arrange
            var basket = new Basket();
            var candy = RandomData.Create<Candy>();

            //act
            basket.Add(candy);

            //assert
            Assert.Single(basket.items);

        }

        [Fact]
        public void Add_2ItemWithSameID_Result_MergeItem()
        {
            //arrange
            var basket = new Basket();
            var firstCandy = RandomData.Create<Candy>();
            var secondCandy = RandomData.Create<Candy>();

            firstCandy.Id = 1;
            firstCandy.Count = 1;

            secondCandy.Id = 1;
            secondCandy.Count = 1;

            //act
            basket.Add(firstCandy);
            basket.Add(secondCandy);

            //assert
            Assert.Single(basket.items);

        }

        [Fact]
        public void Add_2ItemWithSameID_4ResultCount()
        {
            //arrange
            var basket = new Basket();
            var firstCandy = RandomData.Create<Candy>();
            var secondCandy = RandomData.Create<Candy>();

            firstCandy.Id = 1;
            firstCandy.Count = 2;

            secondCandy.Id = 1;
            secondCandy.Count = 2;

            //act
            basket.Add(firstCandy);
            basket.Add(secondCandy);
            var totalCount = basket.items.First().Value.Count;

            //assert
            Assert.Equal(4, totalCount);

        }


        [Fact]
        public void Add_2ItemWithDifferendID_2ItemResult()
        {
            //arrange
            var basket = new Basket();
            var firstCandy = RandomData.Create<Candy>();
            var secondCandy = RandomData.Create<Candy>();

            firstCandy.Id = 1;
            secondCandy.Id = 2;

            //act
            basket.Add(firstCandy);
            basket.Add(secondCandy);
            var itemCount = basket.items.Count;

            //assert
            Assert.Equal(2, itemCount);
        }


        [Fact]
        public void Remove_1Item_EmptyItemList()
        {
            //arrange
            var basket = new Basket();
            var items = new Dictionary<int, Product>();
            var product = RandomData.Create<Candy>();

            product.Count = 1;
            items.Add(product.Id,product);

            basket.items = items;

            //act
            basket.Remove(product);

            //assert
            Assert.Empty(basket.items);
        }


        [Fact]
        public void Remove_4DecrimentItemCount_3CountReturn()
        {
            //arrange
            var basket = new Basket();
            var items = new Dictionary<int, Product>();
            var product = RandomData.Create<Candy>();

            product.Count = 4;
            items.Add(product.Id, product);

            basket.items = items;

            //act
            basket.Remove(product);
            var countFirstItem = basket.items.First().Value.Count;
            //assert
            Assert.Equal(3, countFirstItem);
        }


        [Fact]
        public void Remove_4ReduceBy2Count_2CountReturn()
        {
            //arrange
            var basket = new Basket();
            var items = new Dictionary<int, Product>();
            var product = RandomData.Create<Candy>();

            product.Count = 4;
            items.Add(product.Id, product);

            basket.items = items;

            //act
            basket.Remove(product,2);
            var countFirstItem = basket.items.First().Value.Count;
            //assert
            Assert.Equal(2, countFirstItem);
        }


        [Theory]
        [InlineData(5, 5, 25)]
        [InlineData(1, 2, 2)]
        [InlineData(-1, 1, 0)]
        [InlineData(1, -1, 0)]
        public void GetCost_ItemCount_Cost_Return(int itemCount,int itemCost, int result)
        {
            //arrange
            var basket = new Basket();
            var product = RandomData.Create<Candy>();

            product.Count = itemCount;
            product.Cost = itemCost;

            //act
            var totalCost = basket.GetCost(product);
            //assert
            Assert.Equal(result, totalCost);
        }

        [Fact]
        public void GetDiscount_NoDiscount_0Result()
        {
            //arrange
            var basket = new Basket();
            var discounts = new Dictionary<int, Discount>();
            var discount = FakeUtils.Resolve<Discount>().FakeMethod(nameof(Discount.CountPriceWithDiscount),1);

            discounts.Add(1, discount);
            var product = RandomData.Create<Candy>();
            product.Id = 2;

            //act
            var totalDiscount = basket.GetDiscount(product, discounts);

            //assert
            Assert.Equal(0, totalDiscount);
        }


        [Theory]
        [InlineData(2, 1,2)]
        public void GetDiscount_IsPresent_Result(int discountCost,int productCount, int result)
        {
            //arrange
            var basket = new Basket();
            var discounts = new Dictionary<int, Discount>();
            var discount = FakeUtils.Resolve<Discount>().FakeMethod(nameof(Discount.CountPriceWithDiscount), discountCost);

            discounts.Add(1, discount);
            var product = RandomData.Create<Candy>();
            product.Id = 1;
            product.Count = productCount;

            //act
            var totalDiscount = basket.GetDiscount(product, discounts);

            //assert
            Assert.Equal(result, totalDiscount);
        }


        [Fact]
        public void Discounting_5Cost_3Discont_2Result()
        {
            //arrange
            //var basket = new Basket();
            var product = RandomData.Create<Candy>();
            var discounts = RandomData.Create<Dictionary<int, Discount>>();
            var basket = FakeUtils.Resolve<Basket>();
            basket.FakeMethod(nameof(Basket.GetDiscount), 3);
            basket.FakeMethod(nameof(Basket.GetCost), 5);

            //act
            var totalCost = basket.Discounting(product, discounts);

            //assert
            Assert.Equal(2, totalCost);
        }


    }
}
