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
    public class FavoritePage
    {
        private readonly IBrowser _browser;

        public FavoritePage(IBrowser browser)
        {
            _browser = browser;
        }

        public bool IsThereFavoriteItem(string productCode)
        {
            try
            {
                WebDriverWait wait = new WebDriverWait(_browser.Driver, TimeSpan.FromSeconds(3));
                wait.Until(ExpectedConditions.ElementIsVisible(By.Id(productCode)));

                var result = _browser.Driver.FindElements(By.Id(productCode));
                return result != null && result.Any();
            }
            catch(Exception ex)
            {
                Console.WriteLine(ex.Message);
                return false;
            }
        }

        public void RemoveFavoriteItem(string productCode)
        {
            var selectedItem = _browser.Driver.FindElement(By.Id(productCode));
            if(selectedItem != null)
            {
                selectedItem.FindElement(By.ClassName("deleteProFromFavorites")).Click();

                string xPathConfirm = "//div[@class='lightBox']/div/div[@class='btnHolder']";
                WebDriverWait wait = new WebDriverWait(_browser.Driver, TimeSpan.FromSeconds(2));
                wait.Until(ExpectedConditions.ElementIsVisible(By.XPath(xPathConfirm)));
                _browser.Driver.FindElement(By.XPath(xPathConfirm)).Click();
            }

            System.Threading.Thread.Sleep(4000);
        }
    }
}
