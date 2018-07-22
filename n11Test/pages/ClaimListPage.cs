using n11Test.core.browsers;
using OpenQA.Selenium;
using OpenQA.Selenium.Interactions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace n11Test.pages
{
    public class ClaimListPage
    {
        private readonly IBrowser _browser;

        public ClaimListPage(IBrowser browser)
        {
            _browser = browser;
        }

        public void GoClaimListPage()
        {
            var elementToHover = _browser.Driver.FindElement(By.XPath("//div[@class='myAccount']/a[@title='Hesabım']"));
            var elementToClick = _browser.Driver.FindElement(By.CssSelector("a[href*='https://www.n11.com/hesabim/istek-listelerim']"));

            HoverAndClick(_browser, elementToHover, elementToClick);

            System.Threading.Thread.Sleep(4000);
        }

        public void ClickMyFavorites()
        {
            var element = _browser.Driver.FindElement(By.CssSelector("a[href*='https://www.n11.com/hesabim/favorilerim']"));
            element.Click();

            System.Threading.Thread.Sleep(3000);
        }

        private void HoverAndClick(IBrowser browser, IWebElement elementToHover, IWebElement elementToClick)
        {
            Actions action = new Actions(browser.Driver);
            ((IJavaScriptExecutor)browser.Driver).ExecuteScript("arguments[0].scrollIntoView(true);", elementToHover);

            action.MoveToElement(elementToHover).Build().Perform();
            elementToClick.Click();
        }
    }
}
