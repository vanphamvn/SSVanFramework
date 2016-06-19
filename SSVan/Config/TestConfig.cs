using Microsoft.VisualStudio.TestTools.UnitTesting;
using OpenQA.Selenium;
using OpenQA.Selenium.Firefox;
using OpenQA.Selenium.IE;
using OpenQA.Selenium.Chrome;
using System;
using SSVan.General_Functions;
using OpenQA.Selenium.Support.UI;

namespace SSVan.Config
{
    public class TestConfig
    {
        [TestInitialize]
        public void TestStartup() {

            IWebDriver driver=null;
            StartupHelper.GenerateTestInformation();

            if (TestBasics.Browser.ToUpper() == "IE")
            {
                InternetExplorerOptions opt = new InternetExplorerOptions();
                opt.EnableNativeEvents = false;
                opt.RequireWindowFocus = false;
                driver = new InternetExplorerDriver(StartupHelper.GetUserVariables(), opt);
            }
            else if (TestBasics.Browser.ToUpper() == "FF")
            {
                FirefoxProfile pro = new FirefoxProfile(); 
                driver = new FirefoxDriver(pro);
            }
            else if (TestBasics.Browser.ToUpper() == "CR")
            {
                ChromeOptions opt = new ChromeOptions();
                driver= new ChromeDriver(StartupHelper.GetUserVariables(), opt);
            }
            TestBasics.driver = driver;
            driver.Manage().Window.Maximize();
            driver.Manage().Timeouts().ImplicitlyWait(TimeSpan.FromSeconds(Convert.ToDouble(TestBasics.TimeOut)));
            driver.Manage().Timeouts().SetPageLoadTimeout(TimeSpan.FromSeconds(Convert.ToDouble(TestBasics.TimeOut)));
            TestBasics.Wait = new WebDriverWait(driver, TimeSpan.FromSeconds(Convert.ToDouble(TestBasics.TimeOut)));

        }
        [TestCleanup]
        public void TestCleanup()
        {
            TestBasics.driver.Quit();
        }
    }
}
