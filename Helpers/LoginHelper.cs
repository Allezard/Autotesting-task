using System;
using System.Collections.Generic;
using System.Text;
using NUnit.Framework;
using OpenQA.Selenium;
using ProjectAddressbook.Model;

namespace ProjectAddressbook.Helpers
{
    public class LoginHelper : BaseHelper
    {
        public LoginHelper(IWebDriver webDriver)
            : base(webDriver)
        {
        }

        public void Login(AccountData data)
        {
            webDriver.FindElement(By.Name("user")).SendKeys(data.Username);
            // Ищем поле "User", вводим в него логин.
            webDriver.FindElement(By.Name("pass")).SendKeys(data.Userpassword);
            // Ищем поле "Password", вводим в него пароль.
            webDriver.FindElement(By.XPath("//input[@value='Login']")).Click();
            // Нажимаем на кнопку "Login".
        }
    }
}
