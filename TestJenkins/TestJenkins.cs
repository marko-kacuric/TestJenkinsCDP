using Microsoft.VisualStudio.TestTools.UnitTesting;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Support.UI;
using System;
using System.Threading;


namespace UnderTests.Dashboard_MainPage
{
    [TestClass]
    public class CDP_COUNT
    {
        IWebDriver driver = new ChromeDriver();

        public void goToandLogin(string username, string password)
        {
            driver.Navigate().GoToUrl("https://customer-portal.p3-group.com");
            driver.Manage().Window.Maximize();
            var usernameField = driver.FindElement(By.Name("username"));
            var passwordField = driver.FindElement(By.Name("password"));
            usernameField.SendKeys(username);
            passwordField.SendKeys(password);

            driver.FindElement(By.XPath("/html/body/cdp-root/cdp-sign-in/div/div/div[2]/div/button")).Click();
        }

        public void waitForElement(string locator)
        {
            WebDriverWait wait = new WebDriverWait(driver, TimeSpan.FromSeconds(10));
            IWebElement myDynamicElement = wait.Until(drajver => drajver.FindElement(By.XPath(locator)));
        }

        [TestMethod]
        public void CDPcountRowsInProject()
        {
            goToandLogin("swtest", "$greenteA01");
            waitForElement("/html/body/cdp-root/cdp-user/cdp-sidebar/div");
            driver.FindElement(By.XPath("/html/body/cdp-root/cdp-user/cdp-sidebar/div/div/ul/li[1]/div")).Click();
            waitForElement("/html/body/cdp-root/cdp-user/div/cdp-projects/div[2]/div[1]/div[4]/div/div/table/tbody/tr/td[2]");
            Thread.Sleep(250);
            driver.FindElement(By.XPath("/html/body/cdp-root/cdp-user/div/cdp-projects/div[2]/div[1]/div[4]/div/div/table/tbody/tr/td[2]")).Click();
            waitForElement("/html/body/cdp-root/cdp-user/div/cdp-projects/div[2]/div[1]/div[4]/div/div/table/tbody/tr[10]/td[5]/div/cdp-check-box/div");
            int broj = 2155;
            var rows = driver.FindElements(By.TagName("tr")).Count;

            Assert.AreEqual(broj, rows, "ACTUAL ROW NUMBER IS: " + rows + "");

            driver.Close();
            driver.Quit();

        }
    }
}

