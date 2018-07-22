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
    public class LoginPage
    {
        private readonly IBrowser _browser;
        public LoginPage(IBrowser browser)
        {
            _browser = browser;
        }

        public void ClickLoginButton(string email, string password)
        {
            WebDriverWait wait = new WebDriverWait(_browser.Driver, TimeSpan.FromSeconds(3));
            wait.Until(ExpectedConditions.ElementIsVisible(By.Id("loginButton")));

            var emailInput = _browser.Driver.FindElement(By.Id("email"));
            emailInput.Click();
            emailInput.SendKeys(email);

            var passwordInput = _browser.Driver.FindElement(By.Id("password"));
            passwordInput.Click();
            passwordInput.SendKeys(password);

            var loginButton = _browser.Driver.FindElement(By.Id("loginButton"));
            loginButton.Click();
        }
    }
}
