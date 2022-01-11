using SpecflowTemplate.Contexts;
using SpecflowTemplate.Pages;
using TechTalk.SpecFlow;

namespace SpecflowTemplate.Hooks
{
    [Binding]
    internal sealed class DIHooks
    {
        [BeforeScenario(Order = 1)]
        public static void BeforeScenario(ScenarioContext scenarioContext)
        {
            scenarioContext.ScenarioContainer.RegisterTypeAs<DataContext, IDataContext>();
            scenarioContext.ScenarioContainer.RegisterTypeAs<NavigationHelper, INavigationHelper>();

            scenarioContext.ScenarioContainer.RegisterTypeAs<WikipediaArticlePage, IWikipediaArticlePage>();
            scenarioContext.ScenarioContainer.RegisterTypeAs<WikipediaLandingPage, IWikipediaLandingPage>();
        }
    }
}
