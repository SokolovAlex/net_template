using MvcRouteTester;
using NUnit.Framework;

namespace App.UnitTests.Routes
{
    [TestFixture]
    public class AuthRoutesTest : RouteTest
    {
        [Test]
        public void NewsIndex_WithoutParams_ShouldMapToIndex()
        {
            //Routes.ShouldMap("/auth/login").To<AuthController>(x => x.Login());
        }
    }
}
