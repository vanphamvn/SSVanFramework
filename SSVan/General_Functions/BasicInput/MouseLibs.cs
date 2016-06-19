using OpenQA.Selenium;
using OpenQA.Selenium.Interactions;
using OpenQA.Selenium.Support.UI;
using SSVan.Config;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace SSVan.General_Functions.BasicInput
{
    public static class MouseLibs
    {
        public static void Click(By Control) {
            CustomWait.WaitForControlClickable(Control);
            ClickBy(Control);
        }

        private static void ClickBy(By Control)
        {
            Actions action = new Actions(TestBasics.driver);
            IWebElement element = ElementHelper.FindElement(Control);
            action.Click(element).Perform();
        }

        public static void ContextItemClick(By Control)
        {
            CustomWait.WaitForControlClickable(Control);
            ContextItemClickBy(Control);
        }

        private static void ContextItemClickBy(By Control)
        {
            IWebElement element = ElementHelper.FindElement(Control);
            Actions action = new Actions(TestBasics.driver);
            action.ContextClick(element).Perform();
        }

        public static void ScrollIntoView(IWebElement element)
        {
            ((IJavaScriptExecutor)TestBasics.driver).ExecuteScript("arguments[0].scrollIntoView(true);", element);
            Thread.Sleep(500);
        }

        public static void MouseOver(By Control)
        {
            IWebElement element = ElementHelper.FindElement(Control);
            Actions action = new Actions(TestBasics.driver);
            action.MoveToElement(element).Perform();
            Thread.Sleep(500);
        }
    }
}
