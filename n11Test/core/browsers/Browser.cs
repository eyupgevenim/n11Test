using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace n11Test.core.browsers
{
    public sealed class Browser : IBrowser
    {
        public Browser(IWebDriver driver)
        {
            _driver = driver;
        }

        IWebDriver _driver;
        IWebDriver IBrowser.Driver => _driver;
    }
}
