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
    public class TestingPackageForContacts : BaseClass
    {
        [Test]
        public void AddNewContactTest()
        {
            app.Navigation.GoToBaseUrl();
            app.Auth.Login(new AccountData("admin", "secret"));
            app.Contacts.AddNewContact();
        }

        [Test]
        public void DeleteFirstContactTest()
        {
            app.Navigation.GoToBaseUrl();
            app.Auth.Login(new AccountData("admin", "secret"));
            app.Contacts.DeleteFirstContact(0);
        }

        [Test]
        public void CheckContactInfoTest()
        {
            app.Navigation.GoToBaseUrl();
            app.Auth.Login(new AccountData("admin", "secret"));
            app.Contacts.CheckContactInfo(0);

            ContactData fromForm = app.Contacts.GetContactInfoFromEditForm();
            ContactData fromTabble = app.Contacts.GetContactInfoFromTable(0);
            Console.Out.WriteLine("Table: " + fromTabble + "\n" + "Form: " + fromForm);

            Assert.AreEqual(fromTabble.Address, fromForm.Address);
            Console.Out.WriteLine("\n" + "Table: \n" + fromTabble.Address + "\n\n" + "Form: \n" + fromForm.Address);
            Assert.AreEqual(fromTabble.AllPhones, fromForm.AllPhones);
            Console.Out.WriteLine("\n" + "Table: \n" + fromTabble.AllPhones + "\n\n" + "Form: \n" + fromForm.AllPhones);
        }
    }
}
