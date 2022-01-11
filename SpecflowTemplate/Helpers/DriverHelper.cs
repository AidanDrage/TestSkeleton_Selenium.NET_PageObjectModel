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
            _driverContext.Driver = new ChromeDriver();
        }

        public void Destroy()
        {
            _driverContext.Driver.Close();
            _driverContext.Driver.Dispose();
            _driverContext.Driver = null;
        }
    }
}
