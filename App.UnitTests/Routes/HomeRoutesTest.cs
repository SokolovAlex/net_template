using MvcRouteTester;
using NUnit.Framework;

namespace App.UnitTests.Routes
{
    [TestFixture]
    public class HomeRoutesTest : RouteTest
    {
        [Test]
        public void HomeIndex_WithoutParams_ShouldMapToIndex()
        {
            //Routes.ShouldMap("/").To<HomeController>(x => x.Index());
        }
    }
}
