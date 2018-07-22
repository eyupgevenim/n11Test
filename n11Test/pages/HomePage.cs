using n11Test.core.browsers;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace n11Test.pages
{
    public class HomePage
    {
        private readonly IBrowser _browser;

        public HomePage(IBrowser browser)
        {
            _browser = browser;
        }

        public void OpenPage(string url)
        {
            _browser.Driver.Navigate().GoToUrl(url);
        }

        public bool IsOpenedPage(string url)
        {
            try
            {
                WebDriverWait wait = new WebDriverWait(_browser.Driver, TimeSpan.FromSeconds(3));
                wait.Until(ExpectedConditions.ElementIsVisible(By.TagName("body")));

                return _browser.Driver.Url == url;
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                return false;
            }
        }

        public void ClickBtnSignIn()
        {
            WebDriverWait wait = new WebDriverWait(_browser.Driver, TimeSpan.FromSeconds(2));
            wait.Until(ExpectedConditions.ElementIsVisible(By.ClassName("btnSignIn")));

            var elemet = _browser.Driver.FindElement(By.ClassName("btnSignIn"));
            elemet.Click();
        }

        public void SearchData(string text)
        {
            WebDriverWait wait = new WebDriverWait(_browser.Driver, TimeSpan.FromSeconds(3));
            wait.Until(ExpectedConditions.ElementIsVisible(By.Id("searchData")));

            var searchDataInput = _browser.Driver.FindElement(By.Id("searchData"));
            searchDataInput.Click();
            searchDataInput.SendKeys(text);


            var searchBtn = _browser.Driver.FindElement(By.ClassName("searchBtn"));
            searchBtn.Click();
        }
    }
}
