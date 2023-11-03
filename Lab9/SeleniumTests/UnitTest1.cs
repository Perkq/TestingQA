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
        private string baseURL;

        [SetUp]
        public void Setup()
        {
            driver = new ChromeDriver();
            baseURL = "https://wdl.by/";
            verificationErrors = new StringBuilder();
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
        public void Test1()
        {
            driver.Navigate().GoToUrl(baseURL);

            Assert.That(driver.Title, Is.EqualTo("������ WDL: �������� ������ � ������ � ������ (���� ��� ������, ������, �������������� ����, ���������� �����)"));
            
            driver.FindElement(By.ClassName("bottom-menu__ankor")).Click();

            Assert.That(driver.Title, Is.EqualTo("������� ������ WDL: ������ ��� �����, �������������� ����, ���������� ����� � ����������"));

            driver.FindElement(By.ClassName("product-item")).Click();

            Assert.That(driver.Title, Is.EqualTo("�������������� ���� NOISES GZ1222 ������ � ������ � ������� WDL ������"));

            driver.FindElement(By.ClassName("js-add-to-basket-detail")).Click();
            driver.Navigate().GoToUrl("https://wdl.by/basket/");

            Assert.That(driver.FindElements(By.ClassName("cart-item")).Count, Is.EqualTo(1));
        }
    }
}