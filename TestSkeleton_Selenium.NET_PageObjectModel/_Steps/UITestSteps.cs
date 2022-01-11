using FluentAssertions;
using SpecflowTemplate.Contexts;
using SpecflowTemplate.Pages;
using TechTalk.SpecFlow;

namespace SpecflowTemplate.Steps
{
    [Binding]
    internal class UITestSteps
    {
        private readonly INavigationHelper _navigation;
        private readonly IDataContext _context;
        private readonly IWikipediaLandingPage _wikipediaLandingPage;
        private readonly IWikipediaArticlePage _wikipediaArticlePage;

        public UITestSteps(IDataContext context, INavigationHelper navigationHelper, IWikipediaLandingPage wikipediaLandingPage, IWikipediaArticlePage wikipediaArticlePage)
        {
            _navigation = navigationHelper;
            _context = context;
            _wikipediaLandingPage = wikipediaLandingPage;
            _wikipediaArticlePage = wikipediaArticlePage;
        }

        #region Givens
        [Given(@"The User has Navigated to (.*)")]
        public void GivenTheUserHasNavigatedTo(string url)
        {
            _navigation.GoToURL(url);
        }
        #endregion

        #region Whens
        [When(@"The User Searches for ""(.*)""")]
        public void WhenTheUserSearchesFor(string searchTerm)
        {
            _context.ArticleSearchedFor = searchTerm;
            _wikipediaLandingPage.SearchBox.SendKeys(searchTerm);
            _wikipediaLandingPage.SearchBox.Submit();
        }
        #endregion

        #region Thens
        [Then(@"The Wikipedia Homepage will be displayed")]
        public void ThenTheWikipediaHomepageWillBeDisplayed()
        {
            _navigation.WaitUntillVisible(_wikipediaLandingPage.WikipideaGlobeLogo, 10);
            _wikipediaLandingPage.WikipediaHeader.Should().NotBeNull("Beacuse the wikipedia logo should be displayed");
        }

        [Then(@"Then The Wikipedia Homepage will list (.*) as one of the top 10 languages")]
        public void ThenThenTheWikipediaHomepageWillListEnglishAsOneOfTheTopLanguages(string language)
        {
            _wikipediaLandingPage.GetTopLanguages().Should().Contain(
                language, $"Because {language} should be listed on the home page as one of the top languages"
                );           
        }

        [Then(@"The Wikipedia article that the user search for will be displayed")]
        public void ThenTheWikipediaArticleForPlanetEarthWillDisplay()
        {
            _wikipediaArticlePage.ArticleHeader.Text.Should().Be(_context.ArticleSearchedFor, "Because the title of the article should be the same as the search term");
        }
        #endregion
    }
}
