using FluentAssertions;
using SpecflowTemplate.Contexts;
using SpecflowTemplate.Pages;
using TechTalk.SpecFlow;

namespace SpecflowTemplate.Steps
{
    [Binding]
    public class UITestSteps
    {
        private readonly NavigationHelper _navigation;
        private readonly DataContext _context;
        private readonly HomePage _homePage;

        public UITestSteps(DataContext context, HomePage home, NavigationHelper navigationHelper)
        {
            _navigation = navigationHelper;
            _context = context;
            _homePage = home;
        }

        #region Givens
        [Given(@"The User has Navigated to (.*)")]
        public void GivenTheUserHasNavigatedTo(string url)
        {
            _navigation.GoToURL(url);
        }

        [Given(@"The Google Homepage is Displayed")]
        public void GivenTheGoogleHomepageIsDisplayed()
        {
            _navigation.GoToURL("https://www.google.com");
        }
        #endregion

        #region Whens
        [When(@"The User performs a search for (.*)")]
        public void WhenTheUserPerformsASearchFor(string search)
        {
            _homePage.PerformSearch(search);
            _context.ScenarioDataContext.Add("Search Term", search);
        }
        #endregion

        #region Thens
        [Then(@"The Google Homepage will be displayed")]
        public void ThenTheGoogleHomepageWillBeDisplayed()
        {

            _navigation.WaitUntillVisible(_homePage.SearchBox, 10);
            _homePage.GoogleLogo.Should().NotBeNull("Beacuse the google logo should be displayed");
        }

        [Then(@"The Title of the search results page will reflect the search term")]
        public void EachResultWillContainTheSearchTerm()
        {
            _context.ScenarioDataContext.TryGetValue("Search Term", out dynamic searchTerm);
            string pagetitle = _navigation.GetCurrentPageTitle();

            pagetitle.Should().Be($"{searchTerm} - Google Search", 
                "Because the title of the search results page should reflect the search term");
        }
        #endregion
    }
}
