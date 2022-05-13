using System;
using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Support.UI;

namespace TestAutomationHomework
{
    public class Tests
    {
        private IWebDriver Driver;
        private string URL = "http://automationpractice.com/index.php";

        //login data
        string username = "mantedga@gmail.com";
        string password = "Basketball1";

        //register data

        string firstname = "Petras";
        string lastname = "Paulius";
        string adress = "Kaimas Liudo g. 5";
        string postcode = "68200";
        string phone_number = "869268200";
        string city = "Kaimas";

        string search_item = "Blouse";


        [SetUp]
        public void Setup()
        {
            Driver = new ChromeDriver();
            Driver.Navigate().GoToUrl(URL);
        }


        [Test]

        public void CreateAccTest()
        {
            CreateAcc();
            System.Threading.Thread.Sleep(10000);
            IWebElement logOff_btn = Driver.FindElement(By.CssSelector("#header > div.nav > div > div > nav > div:nth-child(2) > a"));
            Assert.AreEqual(logOff_btn.Text, "Sign out", "Error message: Account is not created");
        }

        [Test]

        public void LoginTest()
        {
            Login();
            System.Threading.Thread.Sleep(10000);
            IWebElement order_btn = Driver.FindElement(By.CssSelector("#center_column > div > div:nth-child(1) > ul > li:nth-child(1) > a"));
            Assert.AreEqual(order_btn.Text, "ORDER HISTORY AND DETAILS", "Error message: this field is not available on");
        }


        [Test]

        public void SearchTest()
        {
            Login();
            Search();
            IWebElement Blouse_txt = Driver.FindElement(By.CssSelector("#center_column > ul > li > div > div.right-block > h5 > a"));
            Assert.AreEqual(Blouse_txt.Text, "Blouse", "Error message: item title is not 'Blouse'");
        }


        [Test]

        public void BuyItemTest()
        {
            Login();
            Search();
            BuyItem();
            System.Threading.Thread.Sleep(10000);
            IWebElement order_completed = Driver.FindElement(By.CssSelector("#center_column > div > p > strong"));
            Assert.AreEqual(order_completed.Text, "Your order on My Store is complete.", "Error message: order is not completed");
        }


        [TearDown]

        public void TearDown()
        {
            if (Driver != null)
                Driver.Quit();
        }

        //Classes_________________


        public void Login()
        {
            IWebElement loginButton = Driver.FindElement(By.CssSelector("#header > div.nav > div > div > nav > div.header_user_info > a"));
            loginButton.Click();
            IWebElement email_txt_reg = Driver.FindElement(By.CssSelector("#email"));
            email_txt_reg.SendKeys(username);
            IWebElement password_txt_reg = Driver.FindElement(By.CssSelector("#passwd"));
            password_txt_reg.SendKeys(password);
            IWebElement signin_accountButton = Driver.FindElement(By.CssSelector("#SubmitLogin"));
            signin_accountButton.Click();
        }


        public void Search()
        {
            IWebElement search_txt = Driver.FindElement(By.CssSelector("#search_query_top"));
            search_txt.SendKeys(search_item);
            IWebElement search_btn = Driver.FindElement(By.CssSelector("#searchbox > button"));
            search_btn.Click();
        }

        public void BuyItem()
        {
            IWebElement add_btn = Driver.FindElement(By.CssSelector("#center_column > ul > li > div > div.right-block > div.button-container > a.button.ajax_add_to_cart_button.btn.btn-default"));
            add_btn.Click();
            System.Threading.Thread.Sleep(10000);
            IWebElement proceed_btn_1 = Driver.FindElement(By.CssSelector("#layer_cart > div.clearfix > div.layer_cart_cart.col-xs-12.col-md-6 > div.button-container > a"));
            proceed_btn_1.Click();
            System.Threading.Thread.Sleep(10000);
            IWebElement proceed_btn_2 = Driver.FindElement(By.CssSelector("#center_column > p.cart_navigation.clearfix > a.button.btn.btn-default.standard-checkout.button-medium"));
            proceed_btn_2.Click();
            System.Threading.Thread.Sleep(10000);
            IWebElement proceed_btn_3 = Driver.FindElement(By.CssSelector("#center_column > form > p > button"));
            proceed_btn_3.Click();
            System.Threading.Thread.Sleep(10000);
            IWebElement check_btn = Driver.FindElement(By.CssSelector("#uniform-cgv"));
            check_btn.Click();
            IWebElement proceed_btn_4 = Driver.FindElement(By.CssSelector("#form > p > button"));
            proceed_btn_4.Click();
            System.Threading.Thread.Sleep(10000);
            IWebElement pay_btn = Driver.FindElement(By.CssSelector("#HOOK_PAYMENT > div:nth-child(1) > div > p"));
            pay_btn.Click();
            System.Threading.Thread.Sleep(10000);
            IWebElement comfirm_btn = Driver.FindElement(By.CssSelector("#cart_navigation > button"));
            comfirm_btn.Click();
        }

        public void CreateAcc()
        {
            IWebElement loginButton = Driver.FindElement(By.CssSelector("#header > div.nav > div > div > nav > div.header_user_info > a"));
            loginButton.Click();
            IWebElement email_txt = Driver.FindElement(By.CssSelector("#email_create"));
            email_txt.SendKeys(username);
            IWebElement create_accountButton = Driver.FindElement(By.CssSelector("#SubmitCreate"));
            create_accountButton.Click();
            System.Threading.Thread.Sleep(10000);
            IWebElement name_txt = Driver.FindElement(By.CssSelector("#customer_firstname"));
            name_txt.SendKeys(firstname);
            IWebElement pavarde_txt = Driver.FindElement(By.CssSelector("#customer_lastname"));
            pavarde_txt.SendKeys(lastname);
            IWebElement password_txt = Driver.FindElement(By.CssSelector("#passwd"));
            password_txt.SendKeys(password);
            IWebElement adress_txt = Driver.FindElement(By.CssSelector("#address1"));
            adress_txt.SendKeys(adress);
            IWebElement zip_txt = Driver.FindElement(By.CssSelector("#postcode"));
            zip_txt.SendKeys(postcode);
            IWebElement phone_txt = Driver.FindElement(By.CssSelector("#phone_mobile"));
            phone_txt.SendKeys(phone_number);
            IWebElement city_txt = Driver.FindElement(By.CssSelector("#city"));
            city_txt.SendKeys(city);
            IWebElement Dropdown_list = Driver.FindElement(By.CssSelector("#id_state"));
            SelectElement SelectAnState = new SelectElement(Dropdown_list);
            SelectAnState.SelectByIndex(2);
            IWebElement reg_accountButton = Driver.FindElement(By.CssSelector("#submitAccount"));
            reg_accountButton.Click();
        }
    }
}