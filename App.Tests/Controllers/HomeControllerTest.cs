using System.Linq;
using NUnit.Framework;
using OpenQA.Selenium;

namespace App.Tests.Controllers
{
    [TestFixture]
    public class HomeControllerTest : ViewTest
    {
        #region Index

        [Test]
        public void HomeIndex_AllUsers_ValidHeader()
        {
            GoToUrl("/");

            Assert.That(Driver.Title, Does.Contain("Boilerplate"));
        }

        //[Test]
        //public void HomeIndex_AllUsers_HasUsers()
        //{
        //    GoToUrl("/");

        //    var departments = Driver.FindElements(By.CssSelector(".home-departments > li > a"));
        //    var dotNetUser = departments.FirstOrDefault(x => x.Text == ".NET");

        //    Assert.GreaterOrEqual(departments.Count, 3);
        //    Assert.IsNotNull(dotNetUser);
        //    Assert.IsTrue(dotNetUser.GetAttribute("href").Contains("/ok"));
        //}

        #endregion
    }
}
