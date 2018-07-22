- Config Keys
```xml
<appSettings>

    <!--<add key="Browser" value="Firefox"/>-->
    <add key="Browser" value="Chrome"/>

    <add key="BaseUrl" value="https://www.n11.com/" />
    <add key="Username" value="" />
    <add key="Password" value="" />
    
  </appSettings>
```




- Test Class

```csharp
   
    [TestFixture]
    [Parallelizable]
    public class N11TestCase : TestBase
    {
        [Test]
        public void TestMethod()
        {
            HomePage homePage = new HomePage(browser);

            //1
            homePage.OpenPage(Config.BaseUrl);
            Assert.IsTrue(homePage.IsOpenedPage(Config.BaseUrl));

            //2
            homePage.ClickBtnSignIn();
            LoginPage loginPage = new LoginPage(browser);
            loginPage.ClickLoginButton(Config.Username, Config.Password);

            //3
            homePage.SearchData("samsung");
            
            SearchResultPage searchResultPage = new SearchResultPage(browser);

            //4
            Assert.IsTrue(searchResultPage.IsThereSearchData);

            //5
            searchResultPage.GoPageNumber("2");
            Assert.IsTrue(searchResultPage.IsOpenPageNumer("2"));

            //6
            searchResultPage.AddItemFavoriteList(2, out string productCode);

            //7
            ClaimListPage claimListPage = new ClaimListPage(browser);
            claimListPage.GoClaimListPage();
            claimListPage.ClickMyFavorites();
            
            FavoritePage favoritePage = new FavoritePage(browser);

            //8
            Assert.IsTrue(favoritePage.IsThereFavoriteItem(productCode));

            //9
            favoritePage.RemoveFavoriteItem(productCode);

            //10
            Assert.IsFalse(favoritePage.IsThereFavoriteItem(productCode));
        }
    }

```