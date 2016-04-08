using MvcRouteTester;
using NUnit.Framework;

namespace App.UnitTests.Routes
{
    [TestFixture]
    public class NewsRoutesTest : RouteTest
    {
        [Test]
        public void NewsIndex_WithoutParams_ShouldMapToIndex()
        {
            //Routes.ShouldMap("/news").To<NewsController>(x => x.Index());
        }
    }
}
