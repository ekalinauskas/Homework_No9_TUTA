using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using System;
using System.Collections.Generic;

namespace TestAutomationHomework
{
    public class Tests
    {
        private IWebDriver Driver;

        [SetUp]
        public void Setup()
        {
            Driver = new ChromeDriver();
        }

        [Test]
        public void Test1()
        {
            Driver.Navigate().GoToUrl("http://automationpractice.com/index.php");
        }
    }
}