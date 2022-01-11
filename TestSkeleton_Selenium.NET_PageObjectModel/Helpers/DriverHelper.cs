using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;

namespace SpecflowTemplate.Helpers
{
    internal static class DriverHelper
    {
        public static IWebDriver Initialise()
        {
            return new ChromeDriver();
        }

        public static void Destroy(IWebDriver driver)
        {
            driver.Close();
            driver.Dispose();
        }
    }
}
