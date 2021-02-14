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
    public class CreateNewGroup : BaseLogin
    {
        [Test]
        public void CreateNewGroupTest()
        {
            app.Navigation.GoToURL();
            app.Auth.Login(new AccountData("admin", "secret"));
            app.Groups.CreateNewGroup(new GroupData("groupname", "groupheader", "gropfooter"));
        }
    }
}
