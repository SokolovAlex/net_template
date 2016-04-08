using System;
using System.Configuration;
using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Firefox;
using OpenQA.Selenium.Remote;

namespace App.Tests
{
    public class ViewTest
    {
        public IWebDriver Driver;
        private string _host;
        private bool _showBrowser;

        [SetUp]
        public void SetUp()
        {
            _host = ConfigurationManager.AppSettings["HostRelease"];
            _showBrowser = false;

            #if DEBUG
            _host = ConfigurationManager.AppSettings["HostDebug"];
            _showBrowser = bool.Parse(ConfigurationManager.AppSettings["ShowBrowser"]);
            #endif

            Driver = _showBrowser ? new FirefoxDriver() : new RemoteWebDriver(new Uri("http://127.0.0.1:4444/wd/hub"), DesiredCapabilities.Firefox());
            Driver.Manage().Timeouts().SetPageLoadTimeout(TimeSpan.FromSeconds(5));
        }

        [TearDown]
        public void TearDown()
        {
            Driver.Quit();
        }

        public void GoToUrl(string url)
        {
            Driver.Navigate().GoToUrl($"http://{_host}{url}");
        }
    }
}
