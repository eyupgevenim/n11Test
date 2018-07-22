using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace n11Test.core.browsers
{
    public interface IBrowser
    {
        IWebDriver Driver { get; }
    }
}
