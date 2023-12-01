using System;
using System.Text;
using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
// C:\Users\n2309\.nuget\packages\nunit.consolerunner\3.16.3\tools

namespace SeleniumTests
{
    public class Tests
    {

        private IWebDriver driver;
        private StringBuilder verificationErrors;
        private readonly string _baseURL = "https://wdl.by/";
        private HomePage hp;

        [SetUp]
        public void Setup()
        {
            driver = new ChromeDriver();
            verificationErrors = new StringBuilder();
            hp = new HomePage(driver);
        }

        [TearDown]
        public void TearDownTest()
        {
            try
            {
                driver.Quit();
            } 
            catch (Exception ex)
            {
                Console.WriteLine("Error: " + ex.Message);
            }

            Assert.That(verificationErrors.ToString(), Is.EqualTo(""));
        }

        [Test]
        public void TestCompareItems()
        {
            hp.GoToUrl(_baseURL);
            Assert.That(hp.GetPageTitle, Is.EqualTo("Оптика WDL: магазины оптики в Минске и Гомеле (очки для зрения, оправы, солнцезащитные очки, контактные линзы)"));

            hp.GetElementByClass("bottom-menu__ankor").Click();
            Assert.That(hp.GetPageTitle, Is.EqualTo("Каталог оптики WDL: оправы для очков, солнцезащитные очки, контактные линзы и аксессуары"));

            hp.GetElementsByClass("product-item")[0].Click();
            hp.GetElementByClass("js-add-compare").Click();

            hp.GoToUrl("https://wdl.by/catalog/");
            hp.GetElementsByClass("product-item")[1].Click();
            hp.GetElementByClass("js-add-compare").Click();
            Thread.Sleep(1000);
            hp.GoToUrl("https://wdl.by/compare/");
            Assert.That(hp.GetElementsByClass("swiper-slide"), Has.Count.EqualTo(2));
        }

        [Test]
        public void TestAddItemToBasket()
        {
            hp.GoToUrl(_baseURL);
            Assert.That(hp.GetPageTitle, Is.EqualTo("Оптика WDL: магазины оптики в Минске и Гомеле (очки для зрения, оправы, солнцезащитные очки, контактные линзы)"));

            hp.GetElementByClass("bottom-menu__ankor").Click();
            Assert.That(hp.GetPageTitle, Is.EqualTo("Каталог оптики WDL: оправы для очков, солнцезащитные очки, контактные линзы и аксессуары"));

            hp.GetElementsByClass("product-item")[0].Click();
            Assert.That(hp.GetPageTitle, Is.EqualTo("Солнцезащитные очки NOISES GZ1222 купить в Минске в салонах WDL Оптика"));

            hp.GetElementByClass("js-add-to-basket-detail").Click();
            Thread.Sleep(1000);
            hp.GoToUrl("https://wdl.by/basket/");

            Assert.That(hp.GetElementsByClass("cart-item"), Has.Count.EqualTo(1));
        }
    }
}