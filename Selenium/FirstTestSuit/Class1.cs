using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Support.UI;
using System;
using System.Collections.Generic;
using System.Linq;


namespace FirstTestSuit
{
        [TestFixture] //class will test suite and for every test will be as test case
        public class Class1
        {
            private string search1 = "macbook";
            private string search2 = "LG";
            private readonly string link = "https://allo.ua/";
            private readonly string link1 = "https://allo.ua/ua/televizory-i-mediapleery/";
            private readonly string link3 = "https://allo.ua/ua/televizory/";

        [Test]
            public void Test1()
            {
                IWebDriver driver = new ChromeDriver();
                driver.Navigate().GoToUrl(link);
                IWebElement element = driver.FindElement(By.Id("search"));
                element.SendKeys(search1);
                element.Submit();
                var list = driver.FindElements(By.XPath("//div[@class='category-products']"));
                var value = list.All(p => p.Text.Contains(search1));
                Assert.IsTrue(value,"Search elemets don't contain 'MacBook' in title");
                driver.Quit();
            }

        [Test]
        public void Test2()
        {
            IWebDriver driver = new ChromeDriver();
            driver.Navigate().GoToUrl(link1);
            IWebElement element1 = driver.FindElement(By.XPath("//ul[@class='links']/li/a[contains(@href, '//allo.ua/ua/televizory-i-mediapleery/proizvoditel-lg/')]"));
            element1.Click();

            var list = driver.FindElements(By.XPath("//li[@class='item']/div[contains(@class,'item')]"));
            var actualList = list.All(p => p.Text.Contains(search2));
            var actualDisplay = driver.FindElement(By.XPath("//li[@class='active-filter']/a[contains(text(), 'LG')]")).Displayed;

            Assert.IsTrue(actualList, "Search elemets don't contain 'LG' in title");
            Assert.IsTrue(actualDisplay, "LG pill don't displayed");

            driver.Quit();
        }

        [Test]
        public void Test3()
        {
            IWebDriver driver = new ChromeDriver();
            driver.Navigate().GoToUrl(link1);
            var list = driver.FindElements(By.XPath("//div[@class='main-products container']/ul/li"));
            var name = list[1].FindElement(By.XPath("//a[@class='product-name']"));
            var saveName = "Проектор "+name.Text;
            var savePrice = list[1].FindElement(By.XPath("//span[@class='price price-sym-7']")).Text;
            name.Click();
            var actualName = driver.FindElement(By.XPath("//*[@id='product-title-h1']")).Text;
            var actualPrice = driver.FindElement(By.XPath("//div[@class='price-box']/div/p[@class='regular-price price-sym-7']")).Text;
            Assert.AreEqual(actualName, saveName);
            Assert.AreEqual(actualPrice, savePrice);
            driver.Quit();
        }
        
        [Test]
        public void Test4()
        {
            var filters = new List<string>() { "Ціна, грн", "Виробник", "Швидкий вибір", "Діагональ екрану","Розширення екрану", "Тип телевізора", "Частота оновлення", "Операційна система", "Smart TV", "HDR", "Тв-тюнер","Колір" };
            IWebDriver driver = new ChromeDriver();
            driver.Navigate().GoToUrl(link3);
            var list = driver.FindElements(By.XPath("//div[@class='filter-name-container']")).Select(c=>c.Text);        
            Assert.AreEqual(filters, list);
            driver.Quit();
        }
        }
    }


