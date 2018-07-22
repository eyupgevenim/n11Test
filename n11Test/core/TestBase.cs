using n11Test.core.browsers;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace n11Test.core
{
    [SetUpFixture]
    public class TestBase
    {
        private readonly Lazy<BrowserFactory> _factory = new Lazy<BrowserFactory>();
        protected IBrowser browser;

        [OneTimeSetUp]
        public void OneTimeSetUp()
        {
            browser = _factory.Value.GetBrowser(Config.Browser);
        }

        [OneTimeTearDown]
        public void OneTimeTearDown()
        {
            browser.Driver.Quit();
        }
    }
}
