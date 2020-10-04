using SpecflowTemplate.Contexts;
using SpecflowTemplate.Helpers;
using TechTalk.SpecFlow;

namespace SpecflowTemplate.Hooks
{
    [Binding]
    public sealed class UIHooks
    {
        // For additional details on SpecFlow hooks see http://go.specflow.org/doc-hooks

        public DriverHelper _driver;

        public UIHooks(DriverHelper driver)
        {
            _driver = driver;
        }

        [BeforeScenario]
        public void BeforeScenario()
        {
            _driver.Initialise();
        }

        [AfterScenario]
        public void AfterScenario()
        {
            _driver.Destroy();
        }
    }
}
