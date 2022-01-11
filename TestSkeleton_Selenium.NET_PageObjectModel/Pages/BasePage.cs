using OpenQA.Selenium;

namespace SpecflowTemplate.Pages
{
    public class BasePage
    {
        protected IWebDriver Driver;

        public BasePage (IWebDriver driver) { Driver = driver; }

    }
}
