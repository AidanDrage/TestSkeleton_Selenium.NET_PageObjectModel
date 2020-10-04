using AventStack.ExtentReports;
using AventStack.ExtentReports.Gherkin.Model;
using AventStack.ExtentReports.Reporter;
using TechTalk.SpecFlow;
using TechTalk.SpecFlow.Bindings;

namespace SpecflowTemplate.Hooks
{
    [Binding]
    sealed class ExtentReportHooks
    {
        private static ScenarioContext _scenarioContext;
        private static AventStack.ExtentReports.ExtentReports _extentReports;
        private static ExtentHtmlReporter _extentHtmlReporter;
        private static ExtentTest _feature;
        private static ExtentTest _scenario;

        [BeforeTestRun]
        private static void BeforeTestRun()
        {
            _extentHtmlReporter = new ExtentHtmlReporter("..\\..\\..\\TestOutput\\");
            _extentReports = new AventStack.ExtentReports.ExtentReports();
            _extentReports.AttachReporter(_extentHtmlReporter);
        }

        [BeforeFeature]
        private static void BeforeFeature(FeatureContext featureContext)
        {
            _feature = _extentReports.CreateTest<Feature>(featureContext.FeatureInfo.Title);
        }

        [BeforeScenario]
        private void BeforeScenario(ScenarioContext scenrioContext)
        {
            _scenarioContext = scenrioContext;
            _scenario = _feature.CreateNode<Scenario>(scenrioContext.ScenarioInfo.Title);
        }

        [AfterStep]
        private void AfterStep()
        {
            if (_scenarioContext.TestError != null)
            {
                switch (_scenarioContext.StepContext.StepInfo.StepDefinitionType)
                {
                    case StepDefinitionType.Given:
                        _scenario.CreateNode<Given>($"Given: {_scenarioContext.StepContext.StepInfo.Text}")
                            .Fail(_scenarioContext.TestError.StackTrace);
                        break;
                    case StepDefinitionType.When:
                        _scenario.CreateNode<When>($"When: {_scenarioContext.StepContext.StepInfo.Text}")
                            .Fail(_scenarioContext.TestError.StackTrace);
                        break;
                    case StepDefinitionType.Then:
                        _scenario.CreateNode<Then>($"Then: {_scenarioContext.StepContext.StepInfo.Text}")
                            .Fail(_scenarioContext.TestError.StackTrace);
                        break;
                    default:
                        _scenario.CreateNode<Given>($"Unknown Step Type: {_scenarioContext.StepContext.StepInfo.Text}")
                            .Fail(_scenarioContext.TestError.StackTrace);
                        break;
                }
            }
            else
            {
                switch (_scenarioContext.StepContext.StepInfo.StepDefinitionType)
                {
                    case StepDefinitionType.Given:
                        _scenario.CreateNode<Given>($"Given: {_scenarioContext.StepContext.StepInfo.Text}")
                            .Pass("Passed");
                        break;
                    case StepDefinitionType.When:
                        _scenario.CreateNode<When>($"When: {_scenarioContext.StepContext.StepInfo.Text}")
                            .Pass("Passed");
                        break;
                    case StepDefinitionType.Then:
                        _scenario.CreateNode<Then>($"Then: {_scenarioContext.StepContext.StepInfo.Text}")
                            .Pass("Passed");
                        break;
                    default:
                        _scenario.CreateNode<Given>($"Unknown Step Type: {_scenarioContext.StepContext.StepInfo.Text}")
                            .Pass("Passed");
                        break;
                }
            }
        }

        [AfterTestRun]
        private static void AfterTestRun()
        {
            _extentReports.Flush();
        }
    }
}
