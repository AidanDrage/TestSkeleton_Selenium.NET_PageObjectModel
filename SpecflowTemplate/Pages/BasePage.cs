using OpenQA.Selenium;
using SpecflowTemplate.Contexts;

namespace SpecflowTemplate.Pages
{
    public class BasePage
    {
        protected IWebDriver Driver;

        public BasePage (DriverContext driver) { Driver = driver.Driver; }

    }
}
