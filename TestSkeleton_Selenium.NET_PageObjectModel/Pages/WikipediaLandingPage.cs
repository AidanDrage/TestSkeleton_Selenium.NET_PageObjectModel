using OpenQA.Selenium;
using System.Collections.Generic;
using System.Collections.ObjectModel;

namespace SpecflowTemplate.Pages
{
    internal interface IWikipediaLandingPage
    {
        IWebElement LanguageDropdown { get; }
        ReadOnlyCollection<IWebElement> Languages { get; }
        IWebElement SearchBox { get; }
        IWebElement WikipediaHeader { get; }
        IWebElement WikipideaGlobeLogo { get; }

        List<string> GetTopLanguages();
    }

    internal class WikipediaLandingPage : BasePage, IWikipediaLandingPage
    {
        public WikipediaLandingPage(IWebDriver driver) : base(driver) { }

        public IWebElement WikipediaHeader => Driver.FindElement(By.ClassName("central-textlogo-wrapper"));

        public IWebElement WikipideaGlobeLogo => Driver.FindElement(By.ClassName("central-featured-logo"));

        public IWebElement LanguageDropdown => Driver.FindElement(By.ClassName("js-lang-list-button"));

        public IWebElement SearchBox => Driver.FindElement(By.CssSelector("input#searchInput"));

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
