using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using SSVan.General_Functions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SSVan.Config
{
    public static class TestBasics
    {
        public static string Browser;
        public static IWebDriver driver;
        public static WebDriverWait Wait;

        #region
        public static string ApplicationURL;
        public static string UserNameFacebook;
        public static string PasswordFacebook;
        public static bool KeepLogin;
        #endregion
    }
}
