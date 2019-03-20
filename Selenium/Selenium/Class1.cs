using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using System;
using System.Linq;

namespace Selenium
{
    [TestFixture] //class will test suite and for every test will be as test case
    public class Class1
    {
        private string search = "macbook";
        [Test]
        public void Test1()
        {
            IWebDriver driver = new ChromeDriver();
            driver.Navigate().GoToUrl("https://www.foxtrot.com.ua/ru/search?query=macbook");
            IWebElement element = driver.FindElement(By.Name("query"));
            element.SendKeys(search);
            element.Submit();
            var list = driver.FindElements(By.XPath("//div[contains(@text,'macbook')]"));
            var value = list.All(p => p.Text.Contains(search));
            Assert.Equals(true,value);
            driver.Quit();
        }
    }
}
