using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using SSVan.Config;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SSVan.General_Functions.BasicInput
{
    public static class KeyboardLibs
    {

        public static void Enter(By Control, string Value)
        {
            TestBasics.Wait.Until(ExpectedConditions.ElementToBeClickable(Control));
            IWebElement element = TestBasics.driver.FindElement(Control);
            element.Clear();
            MouseLibs.ScrollIntoView(element);
            element.SendKeys(Value);
        }
    }
}
