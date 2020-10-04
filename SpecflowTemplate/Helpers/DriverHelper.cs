using OpenQA.Selenium.Chrome;
using SpecflowTemplate.Contexts;

namespace SpecflowTemplate.Helpers
{
    public class DriverHelper
    {
        public DriverContext _driverContext;

        public DriverHelper(DriverContext driverContext)
        {
            _driverContext = driverContext;
        }

        public void Initialise()
        {
            //Setting the chrome bianry location manually because my PC stopped finsing it after a windows reinstall, investigate
            ChromeOptions chromeoptions = new ChromeOptions();
            chromeoptions.BinaryLocation = "C:\\Program Files\\Google\\Chrome\\Application\\chrome.exe";

            //Call driver factory instead
            //Have to set driver location manually because of .NET Core, investigate for a workaround
            _driverContext.Driver = new ChromeDriver("D:\\GIT\\SpecflowTemplate\\SpecflowTemplate\\bin\\Debug\\netcoreapp2.2", chromeoptions);
        }

        public void Destroy()
        {
            _driverContext.Driver.Close();
            _driverContext.Driver.Dispose();
            _driverContext.Driver = null;
        }
    }
}
