using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SSVan.Interfaces.Facebook
{
    public static class ILogin
    {
        public static By txt_Email_Phone = By.Id("email");
        public static By txt_Password = By.Id("pass");
        public static By btn_Login = By.Id("u_0_m");
    }
}
