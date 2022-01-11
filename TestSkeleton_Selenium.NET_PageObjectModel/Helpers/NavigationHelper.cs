using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using System;

namespace SpecflowTemplate
{
    internal interface INavigationHelper
    {
        void GoToURL(string url);
        void WaitUntillVisible(IWebElement element, int maxSeconds);
    }

    internal class NavigationHelper : INavigationHelper
    {
        private readonly IWebDriver Driver;

        public NavigationHelper(IWebDriver driver)
        {
            Driver = driver;
        }

        public void GoToURL(string url)
        {
            Driver.Navigate().GoToUrl(url);
        }

        public void WaitUntillVisible(IWebElement element, int maxSeconds)
        {
            WebDriverWait wait = new WebDriverWait(Driver, TimeSpan.FromSeconds(maxSeconds));

            wait.Until((IWebDriver driver) => element.Displayed);
        }
    }
}
