using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Firefox;
using System.IO;
using System.Reflection;

namespace n11Test.core.browsers
{
    public sealed class BrowserFactory
    {
        private string driverPathFolder { get; set; }
        public BrowserFactory()
        {
            string assemblyFolder = Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location);
            driverPathFolder = Path.Combine(assemblyFolder, "..\\..\\libs");
        }

        //https://chromedriver.storage.googleapis.com/index.html?path=2.40/
        private IBrowser Chrome()
        {
            return new Browser(new ChromeDriver(driverPathFolder));
        }

        //https://github.com/mozilla/geckodriver/releases
        private IBrowser Firefox()
        {
            FirefoxDriverService service = FirefoxDriverService.CreateDefaultService(driverPathFolder);
            return new Browser(new FirefoxDriver(service));
        }

        public IBrowser GetBrowser(BrowserType type)
        {
            switch (type)
            {
                case BrowserType.Firefox:
                    return Firefox();
                case BrowserType.Chrome:
                    return Chrome();
                default:
                    throw new DriveNotFoundException();
            }
        }
    }
}
