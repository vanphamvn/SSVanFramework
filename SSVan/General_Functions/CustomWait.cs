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

        public static void WaitForTextDisplayed(By Control, string Text, int TimeOut=10) {
            DateTime now = DateTime.Now;
            string Actual="~!@#$#@!~";
            do
            {
                Actual = ElementHelper.FindElement(Control).Text;
                Thread.Sleep(200);
                if ((DateTime.Now-now).Seconds>TimeOut)
                {
                    break;
                }
            } while (Actual.ToLower()!=Text.ToLower());
        }

        public static void WaitForControlEnable(By Control) {
            TestBasics.Wait.Until(ExpectedConditions.ElementToBeClickable(Control));
        }

        public static void WaitForControlClickable(By Control)
        {
            TestBasics.Wait.Until(ExpectedConditions.ElementToBeClickable(Control));
        }

        public static void WaitForControlDisappear(By by, int TimeOut = 10)
        {
            DateTime now = DateTime.Now;
            do
            {
                Thread.Sleep(200);
                if ((DateTime.Now - now).Seconds > TimeOut)
                {
                    break;
                }
            } while (TestBasics.driver.FindElement(by).Displayed);

        }

        public static void WaitForControlTextPopulated(By by, int timeout = 10)
        {
            TestBasics.Wait.Until(d => d.FindElement(by).Displayed == true);
            while (ElementHelper.FindElement(by).Text.Equals(""))
            {
                Thread.Sleep(1000);
                timeout--;
                if (timeout < 0)
                {
                    break;
                }
            }
        }
    }
}
