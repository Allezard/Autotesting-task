using System;
using System.Text;
using System.Linq;
using System.Threading;
using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Firefox;
using OpenQA.Selenium.Support.UI;
using ProjectAddressbook.Helpers;
using ProjectAddressbook.Model;

namespace ProjectAddressbook
{
    public class Login : BaseClass
    {
        [Test]
        public void LoginWithValidCredentialsTest()
        {
            app.Navigation.GoToURL();
            app.Auth.Logout();

            AccountData account = new AccountData("admin", "secret");
            app.Auth.Login(account);

            Assert.IsTrue(app.Auth.IsloggedIn());
        }

        [Test]
        public void LoginWithInvalidCredentialsTest()
        {
            app.Navigation.GoToURL();
            app.Auth.Logout();

            AccountData account = new AccountData("admin", "test");
            app.Auth.Login(account);

            Assert.IsFalse(app.Auth.IsloggedIn());
        }
    }
}
