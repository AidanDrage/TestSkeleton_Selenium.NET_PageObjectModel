using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using SpecflowTemplate.Contexts;
using System;
using System.Net.NetworkInformation;

namespace SpecflowTemplate
{
    public class NavigationHelper
    {
        private readonly DriverContext Driver;

        public NavigationHelper(DriverContext driverContext)
        {
            Driver = driverContext;
        }

        public void GoToURL(string url)
        {
            Driver.Driver.Navigate().GoToUrl(url);
        }

        public string GetCurrentPageTitle()
        {
            return Driver.Driver.Title;
        }

        public void WaitUntillVisible(IWebElement element, int maxSeconds) 
        {

            WebDriverWait wait = new WebDriverWait(Driver.Driver, TimeSpan.FromSeconds(maxSeconds));

            wait.Until((IWebDriver driver) => element.Displayed);
        }

        public PingReply Ping(string uri) 
        {
            using var ping = new Ping();
            var reply = ping.Send(uri);
            var status = reply.Status;
            bool pingable = reply.Status == IPStatus.Success;
            return reply;
        }
    }
}
