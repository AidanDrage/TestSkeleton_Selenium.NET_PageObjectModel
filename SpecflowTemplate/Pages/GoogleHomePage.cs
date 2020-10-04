using OpenQA.Selenium;
using SpecflowTemplate.Contexts;

namespace SpecflowTemplate.Pages
{
    public class GoogleHomePage
    {

        private DriverContext _driver;

        public GoogleHomePage(DriverContext driver)
        {
            _driver = driver;
        }

        //Page factory is deprecated
        //[FindsBy(How = How.Id, Using = "hplogo")]
        //private IWebElement logo { get; set; }

        public IWebElement GoogleLogo => _driver.Driver.FindElement(By.Id("hplogo"));

        public IWebElement SearchBox => _driver.Driver.FindElement(By.XPath("//input[@class=\"gLFyf gsfi\"]"));

        public void PerformSearch(string searchTerm)
        {
            SearchBox.Click();
            SearchBox.SendKeys(searchTerm);
            SearchBox.SendKeys(Keys.Return);
        }

    }
}
