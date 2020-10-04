using OpenQA.Selenium;
using SpecflowTemplate.Contexts;

namespace SpecflowTemplate.Pages
{
    public class WikipediaLandingPage
    {
        private DriverContext _driver;

        public WikipediaLandingPage(DriverContext driver)
        {
            _driver = driver;
        }

        public IWebElement WikipediaHeader => _driver.Driver.FindElement(By.ClassName("central-textlogo-wrapper"));

        public IWebElement WikipideaGlobeLogo => _driver.Driver.FindElement(By.ClassName("central-featured-logo"));

        public IWebElement LanguageDropdown => _driver.Driver.FindElement(By.ClassName("js-lang-list-button"));
    }
}
