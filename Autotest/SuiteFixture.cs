using System;
using System.Text;
using System.Linq;
using System.Threading;
using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Support.UI;
using ProjectAddressbook.Helpers;
using ProjectAddressbook.Model;

namespace ProjectAddressbook
{
    [SetUpFixture]
    public class SuiteFixture
    {
        public static ApplicationManager app;

        [OneTimeSetUp]
        public void InitApplicationManager()
        {
            app = new ApplicationManager();
            app.Navigation.GoToURL();
            app.Auth.Login(new AccountData("admin", "secret"));

        }

        [OneTimeTearDown]
        public void StopApplicationManager()
        {
            app.Stop();

        }
    }
}
