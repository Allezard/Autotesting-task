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
        protected static string urlHomePage = "http://localhost/addressbook/";
        protected static string urlGruopList = "http://localhost/addressbook/group.php";

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

        public bool CheckElementPresent()
        {
            try
            {
                webDriver.FindElement(By.LinkText("Logout"));
                return true;
            }
            catch (NoSuchElementException)
            {
                return false;
            }
        }

        public bool IsloggedIn()
        {
            return CheckElementPresent();
        }

        public string GetLoggedUserName()
        {
            string text = webDriver.FindElement(By.Name("Logout")).FindElement(By.TagName("b")).Text;
            return text.Substring(1, text.Length - 2);
        }

        public bool IsLoggedInUser(AccountData data)
        {
            return IsloggedIn()
                && GetLoggedUserName() == data.Username;
        }


    }
}
