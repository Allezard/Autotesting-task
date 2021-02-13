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
    public class RemoveFirstGroup : BaseClass
    {
        [Test]
        public void RemoveFirstGroupTest()
        {
            app.Navigation.GoToURL();
            app.Auth.Login(new AccountData("admin", "secret"));
            app.Groups.RemoveFirstGroup(1);
        }
    }
}
