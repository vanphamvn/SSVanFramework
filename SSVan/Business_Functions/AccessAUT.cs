using OpenQA.Selenium.Support.UI;
using SSVan.Config;
using SSVan.General_Functions;
using SSVan.General_Functions.BasicInput;
using SSVan.Interfaces.Facebook;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SSVan.Business_Functions
{
    public static class AccessAUT
    {
        public static void StartApplication() {
            TestBasics.driver.Navigate().GoToUrl(TestBasics.ApplicationURL);
            TestBasics.driver.Manage().Window.Maximize();
        }
        public static void ExitApplication()
        {
            
        }
        public static void Login(string UserName, string Password, bool IsRememberMe=false)
        {
            CustomWait.WaitForControlClickable(ILogin.txt_Email_Phone);
            KeyboardLibs.Enter(ILogin.txt_Email_Phone,UserName);
            CustomWait.WaitForControlClickable(ILogin.txt_Password);
            KeyboardLibs.Enter(ILogin.txt_Password , Password);
            CustomWait.WaitForControlClickable(ILogin.btn_Login);
            MouseLibs.Click(ILogin.btn_Login);
            CustomWait.WaitForPageLoad(60);

        }
        public static void Logout()
        {

        }
    }
}
