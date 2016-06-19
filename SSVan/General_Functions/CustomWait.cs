using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using SSVan.Config;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace SSVan.General_Functions
{
    public static class CustomWait
    {
        public static void WaitForPageLoad(int Timeout) {
            DateTime now = DateTime.Now;
            string readyState = "";
            do
            {
                IJavaScriptExecutor jsExecutor = (IJavaScriptExecutor)(TestBasics.driver);
                readyState = jsExecutor.ExecuteScript("if (document.readyState) return document.readyState;").ToString();
                Thread.Sleep(500);
                if ((DateTime.Now - now).Seconds > Timeout)
                    break;
            } while (readyState.ToLower() != "complete");
        }

        public static void WaitForTextDisplayed(By Control) {

        }

        public static void WaitForControlEnable(By Control) {
            TestBasics.Wait.Until(ExpectedConditions.ElementToBeClickable(Control));
        }

        public static void WaitForControlClickable(By Control)
        {
            TestBasics.Wait.Until(ExpectedConditions.ElementToBeClickable(Control));
        }
    }
}
