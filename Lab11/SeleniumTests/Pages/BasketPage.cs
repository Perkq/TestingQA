using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SeleniumExtras.PageObjects;

namespace Lab11.Pages
{
    public class BasketPage
    {
        private const string BASE_URL = "https://wdl.by/basket/";

        [FindsBy(How = How.ClassName, Using = "cart-item")]
        private readonly IList<IWebElement> _basketItems;

        public IWebDriver _driver;

        public BasketPage(IWebDriver driver)
        {
            Thread.Sleep(2000);
            _driver = driver;
            PageFactory.InitElements(driver, this);
        }

        public void OpenPage()
        {
            _driver.Navigate().GoToUrl(BASE_URL);
        }

        public int GetBasketItemsCount()
        {
            return _basketItems.Count;
        }
    }
}
