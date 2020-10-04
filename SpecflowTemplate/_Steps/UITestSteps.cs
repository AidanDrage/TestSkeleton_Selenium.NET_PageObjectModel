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
        private readonly GoogleHomePage _googleHomePage;
        private readonly WikipediaLandingPage _wikipediaLandingPage;

        public UITestSteps(DataContext context, GoogleHomePage googleHome, NavigationHelper navigationHelper, 
            WikipediaLandingPage wikipediaLandingPage)
        {
            _navigation = navigationHelper;
            _context = context;
            _googleHomePage = googleHome;
            _wikipediaLandingPage = wikipediaLandingPage;
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
            _googleHomePage.PerformSearch(search);
            _context.ScenarioDataContext.Add("Search Term", search);
        }
        #endregion

        #region Thens
        [Then(@"The Google Homepage will be displayed")]
        public void ThenTheGoogleHomepageWillBeDisplayed()
        {

            _navigation.WaitUntillVisible(_googleHomePage.SearchBox, 10);
            _googleHomePage.GoogleLogo.Should().NotBeNull("Beacuse the google logo should be displayed");
        }

        [Then(@"The Wikipedia Homepage will be displayed")]
        public void ThenTheWikipediaHomepageWillBeDisplayed()
        {
            _navigation.WaitUntillVisible(_wikipediaLandingPage.WikipideaGlobeLogo, 10);
            _wikipediaLandingPage.WikipediaHeader.Should().NotBeNull("Beacuse the wikipedia logo should be displayed");
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
