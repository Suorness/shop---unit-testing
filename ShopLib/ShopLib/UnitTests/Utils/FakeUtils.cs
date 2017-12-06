using FakeItEasy;
using System.Linq;

namespace ShopLib.UnitTests.Utils
{
    public static class FakeUtils
    {
        public static T Resolve<T>()
        {
            return A.Fake<T>(options => options.CallsBaseMethods());
        }

        public static TClass FakeMethod<TClass, TReturnType>(this TClass fakedObject, string methodName, TReturnType value)
        {
            A.CallTo(fakedObject)
                .Where(call => call.Method.Name == methodName)
                .WithReturnType<TReturnType>()
                .Returns(value);

            return fakedObject;
        }
    }
}
