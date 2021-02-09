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
    public class RemoveFirstGroup : BaseClass
    {
        [Test]
        public void RemoveFirstGroupTest()
        {
            SetupChromeDriver();
            NavigationHelper.GoToURL();
            LoginHelper.Login(new AccountData("admin", "secret"));
            TestingGroupHelper.RemoveFirstGroup(1);
            TearDownHelper.TestQuit();
        }
    }
}
