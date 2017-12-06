using Ploeh.AutoFixture;

namespace ShopLib.UnitTests.Utils
{
    public static class RandomData
    {
        private static readonly Fixture Fixture = new Fixture();

        public static T Create<T>()
        {
            return Fixture.Create<T>();
        }
    }
}
