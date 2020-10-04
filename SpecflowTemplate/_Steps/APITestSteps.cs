using FluentAssertions;
using RestSharp;
using SpecflowTemplate.Contexts;
using SpecflowTemplate.Helpers;
using TechTalk.SpecFlow;

namespace SpecflowTemplate.Steps
{
    [Binding]
    public class APITestSteps
    {
        private readonly NavigationHelper _navigation;
        private readonly DataContext _context;
        private readonly APIHelper _api;

        public APITestSteps(NavigationHelper navigationHelper, DataContext dataContext, APIHelper helper)
        {
            _navigation = navigationHelper;
            _context = dataContext;
            _api = helper;
        }

        #region Givens
        [Given(@"Google is Online")]
        public void GivenGoogleIsOnline()
        {
            var replystatus = _navigation.Ping("www.google.com").Status.ToString();
            replystatus.Should().Be("Success", "Because the ping to google should have indicated it is online");
        }

        [Given(@"ReqRes\.in is Online")]
        public void GivenReqRes_InIsOnline()
        {
            var replystatus = _navigation.Ping("reqres.in").Status.ToString();
            replystatus.Should().Be("Success", "Because the ping to google should have indicated it is online");
        }

        [Given(@"The Node JSON Server is spun up")]
        public void GivenTheNodeJSONServerIsSpunUp()
        {
            var replystatus = _navigation.Ping("www.google.com").Status.ToString();
            replystatus.Should().Be("Success", "Because the ping to google should have indicated it is online");
        }

        #endregion

        #region Whens
        [When(@"I send a GET request")]
        public void WhenISendAGETRequest()
        {
            var response = _api.Get("https://www.google.com/");
            _context.ScenarioDataContext.Add("Response", response);
        }

        [When(@"I send a request to get all users")]
        public void WhenISendARequestToGetAllUsers()
        {
            var response = _api.Get("https://reqres.in/api/users?page=1");
            _context.ScenarioDataContext.Add("Response", response);
        }

        [When(@"I send a request to get all posts")]
        public void WhenISendARequestToGetAllPosts()
        {
            var response = _api.Get("http://localhost:3000/posts");
            _context.ScenarioDataContext.Add("Response", response);
        }

        #endregion

        #region Thens
        [Then(@"The Reponse status is OK")]
        public void ThenTheReponseStatusIsOK()
        {
            _context.ScenarioDataContext.TryGetValue("Response", out dynamic response);
            RestResponse rest = response;
            var desc = rest.StatusDescription;
            desc.Should().Be("OK", "Because the response should be OK");
        }
        #endregion
    }
}
