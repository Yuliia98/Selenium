using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Interactions;
using OpenQA.Selenium.Support.UI;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Wait.Frame
{
    [TestFixture]
    public class Class1
    {
        private string link1 = "http://toolsqa.com";
        private string link2 = "http://toolsqa.com/automation-practice-switch-windows/";

        [Test]
        public void Test1()
        {
            IWebDriver driver = new ChromeDriver();
            WebDriverWait wait = new WebDriverWait(driver, TimeSpan.FromSeconds(15));
            driver.Navigate().GoToUrl(link1); 
            Actions actions = new Actions(driver);
            IWebElement image = wait.Until(ExpectedConditions.ElementIsVisible(By.XPath("//div[@class='tp-bgimg defaultimg ']")));
            IWebElement button = wait.Until(x => x.FindElement(By.XPath("//span[@class='menu-item-text']/span[contains(text(),'DEMO SITES')][1]")));
            actions.MoveToElement(button).Perform();
            IWebElement element = wait.Until(x=>x.FindElement(By.XPath("//span[contains(text(),'Automation Practice Switch Windows')][1]"))); 
            actions.MoveToElement(element).Click().Perform();
            IWebElement pressbutton = wait.Until(x => x.FindElement(By.XPath("//button[contains(text(),'New Browser Tab')]")));
            pressbutton.Click();
            IReadOnlyCollection<string> tabs = driver.WindowHandles;
            var currentTab = driver.SwitchTo().Window(tabs.Last());
            Assert.AreEqual("QA Automation Tools Tutorial",currentTab.Title);
            driver.Quit();

        }

        [Test]
        public void Test2()
        {
            IWebDriver driver = new ChromeDriver();
            WebDriverWait wait = new WebDriverWait(driver, TimeSpan.FromSeconds(10));
            driver.Navigate().GoToUrl(link2);
            IWebElement pressButton = wait.Until(x => x.FindElement(By.Id("timingAlert")));
            pressButton.Click();

            //driver.Quit();

        }
    }
}
