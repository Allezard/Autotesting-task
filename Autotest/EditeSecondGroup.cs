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
    public class EditSecondGroup : BaseClass
    {
        [Test]
        public void EditSecondGroupTest()
        {
            SetupChromeDriver();
            NavigationHelper.GoToURL();
            LoginHelper.Login(new AccountData("admin", "secret"));
            TestingGroupHelper.EditSecondGroup(new GroupData("editname", "editheader", "editfooter"), 2);
            TearDownHelper.TestQuit();
        }
    }
}
