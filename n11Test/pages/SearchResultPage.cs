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
    public class SearchResultPage
    {
        private readonly IBrowser _browser;
        public SearchResultPage(IBrowser browser)
        {
            _browser = browser;
        }

        public bool IsThereSearchData
        {
            get
            {
                try
                {
                    string xPath = "//section[@class='group listingGroup resultListGroup']/div[@id='view']/ul/li";

                    WebDriverWait wait = new WebDriverWait(_browser.Driver, TimeSpan.FromSeconds(5));
                    wait.Until(ExpectedConditions.ElementIsVisible(By.XPath(xPath)));
                    var result = _browser.Driver.FindElements(By.XPath(xPath));

                    return result != null && result.Any();
                }
                catch(Exception ex)
                {
                    Console.WriteLine(ex.Message);
                    return false;
                }
            }
        }

        public void GoPageNumber(string number)
        {
            string cssSelector = $"a[href*='https://www.n11.com/arama?q=samsung&pg={number}']";
            var getPaging = _browser.Driver.FindElement(By.CssSelector(cssSelector));
            getPaging.Click();
        }

        public bool IsOpenPageNumer(string number)
        => IsThereSearchData
            && _browser.Driver.Url == $"https://www.n11.com/arama?q=samsung&pg={number}";

        public void AddItemFavoriteList(int index, out string productCode)
        {
            string xPath = "//section[@class='group listingGroup resultListGroup']/div[@id='view']/ul/li";

            WebDriverWait waitForElement = new WebDriverWait(_browser.Driver, TimeSpan.FromSeconds(5));
            waitForElement.Until(ExpectedConditions.ElementIsVisible(By.XPath(xPath)));

            IList<IWebElement> list = _browser.Driver.FindElements(By.XPath(xPath));

            productCode = "";

            if(list != null && list.Count - 1 >= index)
            {
                var selectedItem = list[index];

                productCode = selectedItem.FindElement(By.ClassName("columnContent")).GetAttribute("id");
                Console.WriteLine($"prodeuct code: {productCode}");

                var favoriteIcon = selectedItem.FindElement(By.CssSelector("span[class*='textImg followBtn']"));
                favoriteIcon.Click();
            }
        }
    }
}
