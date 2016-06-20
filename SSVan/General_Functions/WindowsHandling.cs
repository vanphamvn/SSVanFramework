using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using SSVan.Config;
using SSVan.General_Functions.BasicInput;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace SSVan.General_Functions
{
    public static class WindowsHandling
    {

        public static void SwitchToWindowsByHandles(IList<string> handles)
        {
            string popupHandle = FindNewWindowHandle(TestBasics.driver, handles, 30);
            if (!string.IsNullOrEmpty(popupHandle))
            {
                try
                {
                    TestBasics.driver.SwitchTo().Window(popupHandle);
                }
                catch { }

            }
            TestBasics.driver.Manage().Window.Maximize();
            CustomWait.WaitForPageLoad(30);
            HandleCertificateError();

        }

        private static string FindNewWindowHandle(IWebDriver driver, IList<string> existingHandles, int timeout)
        {
            string foundHandle = string.Empty;
            DateTime endTime = DateTime.Now.Add(TimeSpan.FromSeconds(timeout));
            while (string.IsNullOrEmpty(foundHandle) && DateTime.Now < endTime)
            {
                IList<string> currentHandles = driver.WindowHandles;
                if (currentHandles.Count != existingHandles.Count)
                {
                    foreach (string currentHandle in currentHandles)
                    {
                        if (!existingHandles.Contains(currentHandle))
                        {
                            foundHandle = currentHandle;
                            break;
                        }
                    }
                }

                if (string.IsNullOrEmpty(foundHandle))
                {
                    Thread.Sleep(250);
                }
            }

            // Note: could optionally check for handle found here and throw
            // an exception if no window was found.
            return foundHandle;
        }

        public static void HandleCertificateError()
        {

            if (TestBasics.Browser.ToUpper() == "IE")
            {
                try
                {
                    TestBasics.Wait.Until(ExpectedConditions.TitleContains("Certificate"));
                }
                catch { }
                int click = 100;
                while (TestBasics.driver.Title.Contains("Certificate"))
                {
                    CustomWait.WaitForPageLoad(30);
                    try
                    {
                        TestBasics.driver.Navigate().GoToUrl("javascript:document.getElementById('overridelink').click()");
                    }
                    catch { }
                    Thread.Sleep(1000);
                    click--;
                    if (click < 0)
                    {
                        break;
                    }
                }
            }
        }

        public static void ClickAndSwitchToNewWindow(By Control)
        {
            int current = TestBasics.driver.WindowHandles.Count;
            TestBasics.driver.Manage().Timeouts().ImplicitlyWait(TimeSpan.FromSeconds(TestBasics.TimeOut));
            TestBasics.driver.Manage().Timeouts().SetPageLoadTimeout(TimeSpan.FromSeconds(TestBasics.TimeOut));
            TestBasics.Wait.Timeout = TimeSpan.FromSeconds(TestBasics.TimeOut);
            try
            {
                TestBasics.Wait.Until(ExpectedConditions.ElementToBeClickable(Control));
            }
            catch
            {
            }
            IList<string> handles = TestBasics.driver.WindowHandles;
            // do whatever you have to do to invoke the popup
            MouseLibs.Click(Control);
            int loop = 30;
            while (TestBasics.driver.WindowHandles.Count <= current)
            {
                if (loop < 0)
                    break;
                loop--;
                Thread.Sleep(2000);
            }
            SwitchToWindowsByHandles(handles);
            TestBasics.driver.Manage().Timeouts().ImplicitlyWait(TimeSpan.FromSeconds(Convert.ToDouble(TestBasics.TimeOut)));
            TestBasics.driver.Manage().Timeouts().SetPageLoadTimeout(TimeSpan.FromSeconds(Convert.ToDouble(TestBasics.TimeOut)));
            TestBasics.Wait.Timeout = TimeSpan.FromSeconds(TestBasics.TimeOut);
        }
    }
}
