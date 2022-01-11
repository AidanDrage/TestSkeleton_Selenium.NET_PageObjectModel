using OpenQA.Selenium;
using SpecflowTemplate.Contexts;

namespace SpecflowTemplate.Pages
{
    internal class WikipediaArticlePage : BasePage
    {
        public WikipediaArticlePage(DriverContext driver) : base(driver) {}

        public IWebElement ArticleHeader => Driver.FindElement(By.CssSelector("h1#firstHeading"));
    }
}
