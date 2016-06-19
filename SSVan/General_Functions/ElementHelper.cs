using OpenQA.Selenium;
using SSVan.Config;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SSVan.General_Functions
{
    public static class ElementHelper
    {
        public static IWebElement FindElement(By Control) {
            return TestBasics.driver.FindElement(Control);
        }
    }
}
