using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using SSVan.Config;
using SSVan.Business_Functions;

namespace SSVan
{
    [TestClass]
    public class TestTemp : TestConfig
    {
        [TestMethod]
        public void TestCaseTemp()
        {
            AccessAUT.StartApplication();
            AccessAUT.Login(TestBasics.UserNameFacebook,TestBasics.PasswordFacebook,TestBasics.KeepLogin);
            System.Windows.Forms.MessageBox.Show(TestBasics.driver.Title);
            
        }
    }
}
