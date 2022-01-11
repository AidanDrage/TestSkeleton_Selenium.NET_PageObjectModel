using OpenQA.Selenium;

namespace SpecflowTemplate.Pages
{
    internal interface IWikipediaArticlePage
    {
        IWebElement ArticleHeader { get; }
    }

    internal class WikipediaArticlePage : BasePage, IWikipediaArticlePage
    {
        public WikipediaArticlePage(IWebDriver driver) : base(driver) { }

        public IWebElement ArticleHeader => Driver.FindElement(By.CssSelector("h1#firstHeading"));
    }
}
