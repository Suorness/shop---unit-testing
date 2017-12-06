using Xunit;

namespace ShopLib.UnitTests.Tests
{
    public class Discount_Tests
    {
        [Theory]
        [InlineData(5, 5, 4, 0)]
        [InlineData(5, 4, 5, 4)]
        [InlineData(5, 4, 6, 4)]
        [InlineData(5, 4, 10, 8)]
        [InlineData(5, 4, 0, 0)]
        public void CountPriceWithDiscount_ReturnDiscount(int CountItemForDiscount, int DiscountPrice,int countItem, int totalDiscount)
        {

            ////arrange
            var discount = new Discount
            {
                ProductCount = CountItemForDiscount,
                DicountedPrice = DiscountPrice
            };

            //act
            var result = discount.CountPriceWithDiscount(countItem);

            ////assert
            Assert.Equal(result, totalDiscount);
        }
    }
}
