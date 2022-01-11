using OpenQA.Selenium;
using SpecflowTemplate.Contexts;
using SpecflowTemplate.Helpers;
using TechTalk.SpecFlow;

namespace SpecflowTemplate.Hooks
{
    [Binding]
    internal sealed class DriverHooks
    {
        [BeforeScenario(Order = 2)]
        public void BeforeScenario(ScenarioContext scenarioContext)
        {
            IWebDriver Webdriver;

            Webdriver = DriverHelper.Initialise();

            scenarioContext.ScenarioContainer.RegisterInstanceAs(Webdriver);
        }

        [AfterScenario]
        public void AfterScenario(IWebDriver driver)
        {
            DriverHelper.Destroy(driver);
        }
    }
}
