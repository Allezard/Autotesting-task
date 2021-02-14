using System;
using System.Collections.Generic;
using System.Text;
using NUnit.Framework;
using OpenQA.Selenium;
using ProjectAddressbook.Model;

namespace ProjectAddressbook.Helpers
{
    public class BaseHelper
    {
        protected IWebDriver webDriver;
        protected static string urlLogin = "http://localhost/addressbook/";

        public BaseHelper(IWebDriver webDriver)
        {
            this.webDriver = webDriver;
        }

        public void EditGropMethod(By locator, string text)
        {
            if (text != null)
            {
                webDriver.FindElement(locator).Clear();
                webDriver.FindElement(locator).SendKeys(text);
            }
        }

        public bool IsElementPresent(By by)
        {
            try
            {
                webDriver.FindElement(by);
                return true;
            }
            catch (NoSuchElementException)
            {
                return false;
            }
        }

        public bool IsloggedInText(AccountData data)
        {
            return IsloggedIn()
                && webDriver.FindElement(By.Name("Logout")).FindElement(By.TagName("b")).Text
                    == "(" + data.Username + ")";
        }

        public bool IsloggedIn()
        {
            return IsElementPresent(By.Name("Logout"));
        }
    }
}
