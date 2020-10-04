using OpenQA.Selenium;
using SpecflowTemplate.Contexts;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Runtime.CompilerServices;

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

        public ReadOnlyCollection<IWebElement> Languages => _driver.Driver.FindElements(By.XPath("//*[@class='central-featured']/div"));

        public List<string> GetTopLanguages()
        {
            var LanguageText = new List<string>();

            foreach (var item in Languages)
            {
                var languagetext = item.FindElement(By.XPath("./a/strong")).Text;
                LanguageText.Add(languagetext);
            }

            return LanguageText;
    }
    }
}
