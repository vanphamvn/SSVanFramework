using SSVan.Config;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml;

namespace SSVan.General_Functions
{
    public static class StartupHelper
    {
        public static string GetUserVariables()
        {
            return Environment.GetEnvironmentVariable("AutomationVars",EnvironmentVariableTarget.User);
        }

        public static void GenerateTestInformation() {
            #region Get Init infomation
            XmlDocument xml = new XmlDocument();
            xml.Load(GetUserVariables()+"/Variables.xml");
            TestBasics.Browser= xml.SelectSingleNode("//Browser").InnerText.ToUpper();
            TestBasics.ApplicationURL= xml.SelectSingleNode("//ApplicationName/URL").InnerText.ToUpper();
            TestBasics.ApplicationURL = xml.SelectSingleNode("//ApplicationName/UserName").InnerText.ToUpper();
            TestBasics.ApplicationURL = xml.SelectSingleNode("//ApplicationName/Password").InnerText.ToUpper();
            string KeepLogin= xml.SelectSingleNode("//ApplicationName/KeepLogin").InnerText.ToUpper();
            TestBasics.KeepLogin = bool.Parse(KeepLogin);
            #endregion
        }
    }
}
