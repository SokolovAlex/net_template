using System.Web.Routing;
using NUnit.Framework;
using App.Web;

namespace App.UnitTests
{
    public class RouteTest
    {
        public RouteCollection Routes;

        [SetUp]
        public void SetUp()
        {
            Routes = RouteTable.Routes;
            RouteConfig.RegisterRoutes(Routes);
        }

        [TearDown]
        public void TearDown()
        {
            RouteTable.Routes.Clear();
        }
    }
}
