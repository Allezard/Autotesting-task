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
    public class CreateNewGroup : BaseClass
    {
        [Test]
        public void CreateNewGroupTest()
        {
            SetupChromeDriver();
            NavigationHelper.GoToURL();
            LoginHelper.Login(new AccountData("admin", "secret"));
            TestingGroupHelper.CreateNewGroup(new GroupData("groupname", "groupheader", "gropfooter"));
            TearDownHelper.TestQuit();
        }
    }
}
