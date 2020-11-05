using OpenQA.Selenium;
using SpecflowTemplate.Contexts;

namespace SpecflowTemplate.Pages
{
    public class GoogleHomePage : BasePage
    {
        public GoogleHomePage(DriverContext driver) : base (driver) {}

        public IWebElement GoogleLogo => Driver.FindElement(By.Id("hplogo"));

        public IWebElement SearchBox => Driver.FindElement(By.XPath("//input[@class=\"gLFyf gsfi\"]"));

        public void PerformSearch(string searchTerm)
        {
            SearchBox.Click();
            SearchBox.SendKeys(searchTerm);
            SearchBox.SendKeys(Keys.Return);
        }
    }
}
