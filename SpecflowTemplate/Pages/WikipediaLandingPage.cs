using OpenQA.Selenium;
using SpecflowTemplate.Contexts;
using System.Collections.Generic;
using System.Collections.ObjectModel;

namespace SpecflowTemplate.Pages
{
    public class WikipediaLandingPage : BasePage
    {
        public WikipediaLandingPage(DriverContext driver) : base(driver) { }

        public IWebElement WikipediaHeader => Driver.FindElement(By.ClassName("central-textlogo-wrapper"));

        public IWebElement WikipideaGlobeLogo => Driver.FindElement(By.ClassName("central-featured-logo"));

        public IWebElement LanguageDropdown => Driver.FindElement(By.ClassName("js-lang-list-button"));

        public ReadOnlyCollection<IWebElement> Languages => Driver.FindElements(By.XPath("//*[@class='central-featured']/div"));

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
