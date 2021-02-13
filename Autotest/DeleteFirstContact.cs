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
    public class DeleteFirstContact : BaseClass
    {
        [Test]
        public void DeleteFirstContactTest()
        {
            //app.Navigation.GoToURL();
            //app.Auth.Login(new AccountData("admin", "secret"));
            app.Contacts.DeleteFirstContact(1);
        }
    }
}
