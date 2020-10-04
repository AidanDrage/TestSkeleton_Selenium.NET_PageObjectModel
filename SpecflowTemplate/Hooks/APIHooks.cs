using SpecflowTemplate.Contexts;
using SpecflowTemplate.Helpers;
using TechTalk.SpecFlow;

namespace SpecflowTemplate.Hooks
{
    [Binding]
    public sealed class APIHooks
    {
        // For additional details on SpecFlow hooks see http://go.specflow.org/doc-hooks

        public APIHelper _server;

        public APIHooks(APIHelper server)
        {
            _server = server;
        }

        [BeforeScenario]
        public void BeforeScenario()
        {
            _server.InitialiseServer();
        }

        [AfterScenario]
        public void AfterScenario()
        {
            _server.CloseServer();
        }
    }
}
