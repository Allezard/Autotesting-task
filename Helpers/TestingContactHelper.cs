using System;
using System.Collections.Generic;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading;
using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using ProjectAddressbook.Model;

namespace ProjectAddressbook.Helpers
{
    public class TestingContactHelper : BaseHelper
    {
        private List<ContactData> contactCache = null;

        public TestingContactHelper(IWebDriver webDriver)
            : base(webDriver)
        {
        }

        public List<ContactData> GetContactList()
        {
            if (contactCache == null)
            {
                contactCache = new List<ContactData>();
                NavigationHelper navigation = new NavigationHelper(webDriver);
                navigation.GoToUrContacts();
                ICollection<IWebElement> elements = webDriver.FindElements(By.TagName("tr.entry"));
                foreach (IWebElement element in elements)
                {
                    contactCache.Add(new ContactData()
                    {
                        Id = element.FindElement(By.TagName("input")).GetAttribute("value")
                    });
                }

                string allContacntNames = webDriver.FindElement(By.CssSelector("div#content form")).Text;
                string[] parts = allContacntNames.Split("\n");
                int shift = contactCache.Count - parts.Length;
                for (int i = 0; i < contactCache.Count; i++)
                {
                    if (i < shift)
                    {
                        contactCache[i].FirstName = "";
                    }
                    else
                    {
                        contactCache[i].FirstName = parts[i - shift].Trim();
                    }
                }
            }
            return new List<ContactData>(contactCache);
        }

        public int GetContactCount()
        {
            return webDriver.FindElements(By.TagName("tr.entry")).Count;
        }

        public ContactData GetContactInfoFromEditForm()
        {
            string firstName = webDriver.FindElement(By.Name("firstname")).GetAttribute("value");
            string lastName = webDriver.FindElement(By.Name("lastname")).GetAttribute("value");
            string address = webDriver.FindElement(By.Name("address")).GetAttribute("value");
            string homePhone = webDriver.FindElement(By.Name("home")).GetAttribute("value");
            string mobilePhone = webDriver.FindElement(By.Name("mobile")).GetAttribute("value");
            string workPhone = webDriver.FindElement(By.Name("work")).GetAttribute("value");
            string email = webDriver.FindElement(By.Name("email")).GetAttribute("value");
            string email2 = webDriver.FindElement(By.Name("email2")).GetAttribute("value");
            string email3 = webDriver.FindElement(By.Name("email3")).GetAttribute("value");

            return new ContactData()
            {
                FirstName = firstName,
                LastName = lastName,
                Address = address,
                HomePhone = homePhone,
                MobilePhone = mobilePhone,
                WorkPhone = workPhone,
                Email = email,
                Email2 = email2,
                Email3 = email3
            };
        }

        public ContactData GetContactInfoFromTable(int index)
        {
            NavigationHelper navigation = new NavigationHelper(webDriver);
            navigation.GoToUrContacts();

            IList<IWebElement> cells = webDriver.FindElements(By.Name("entry"))[index]
                .FindElements(By.TagName("td"));

            string lastName = cells[1].Text;
            string firstName = cells[2].Text;
            string address = cells[3].Text;
            string allEmails = cells[4].Text;
            string allPhones = cells[5].Text;


            return new ContactData()
            {
                LastName = lastName,
                FirstName = firstName,
                Address = address,
                AllPhones = allPhones,
                AllEmails = allEmails
            };
        }

        public int GetNumberOfSearchResults()
        {
            webDriver.FindElement(By.LinkText("home")).Click();
            // Переходим на главную страницу со списком контактов.
            string numberOfResult = webDriver.FindElement(By.TagName("label")).Text;
            Match number = new Regex(@"\d+").Match(numberOfResult);
            return Int32.Parse(number.Value);
        }

        public TestingContactHelper AddNewContact()
        {
            webDriver.FindElement(By.LinkText("add new")).Click();
            webDriver.FindElement(By.Name("firstname")).SendKeys("first");
            webDriver.FindElement(By.Name("middlename")).SendKeys("middle");
            webDriver.FindElement(By.Name("lastname")).SendKeys("last");
            webDriver.FindElement(By.Name("nickname")).SendKeys("nick");
            webDriver.FindElement(By.Name("company")).SendKeys("company");
            webDriver.FindElement(By.Name("title")).SendKeys("title");
            webDriver.FindElement(By.Name("address")).SendKeys("address");
            webDriver.FindElement(By.Name("home")).SendKeys("home");
            webDriver.FindElement(By.Name("mobile")).SendKeys("mobile");
            webDriver.FindElement(By.Name("work")).SendKeys("work");
            webDriver.FindElement(By.Name("fax")).SendKeys("fax");
            webDriver.FindElement(By.Name("email")).SendKeys("email1");
            webDriver.FindElement(By.Name("email2")).SendKeys("email2");
            webDriver.FindElement(By.Name("email3")).SendKeys("email3");
            webDriver.FindElement(By.Name("homepage")).SendKeys("homepage");
            // Заполняем личные данные.
            webDriver.FindElement(By.Name("bday")).Click();
            new SelectElement(webDriver.FindElement(By.Name("bday"))).SelectByText("16");
            webDriver.FindElement(By.Name("bmonth")).Click();
            new SelectElement(webDriver.FindElement(By.Name("bmonth"))).SelectByText("April");
            webDriver.FindElement(By.Name("byear")).SendKeys("1994");
            // Указываем день, месяц, год рождения.
            webDriver.FindElement(By.Name("aday")).Click();
            new SelectElement(webDriver.FindElement(By.Name("aday"))).SelectByText("20");
            webDriver.FindElement(By.Name("amonth")).Click();
            new SelectElement(webDriver.FindElement(By.Name("amonth"))).SelectByText("March");
            webDriver.FindElement(By.Name("ayear")).SendKeys("2020");
            // Указываем день, месяц, год годовщины.
            webDriver.FindElement(By.Name("new_group")).Click();
            new SelectElement(webDriver.FindElement(By.Name("new_group"))).SelectByText("test");
            // Выбираем ранее созданную группу.
            webDriver.FindElement(By.Name("address2")).SendKeys("address2");
            webDriver.FindElement(By.Name("phone2")).SendKeys("");
            webDriver.FindElement(By.Name("notes")).SendKeys("notes");
            webDriver.FindElement(By.Name("submit")).Submit();
            // Добавляем вторичные личные данные.
            webDriver.FindElement(By.LinkText("home")).Click();
            // Возвращаемся на главную страницу (контакты) не дожидаясь редиректа.

            contactCache = null;
            return this;
        }

        public TestingContactHelper EditFirstContact(ContactData contact, int index)
        {
            webDriver.FindElement(By.LinkText("home")).Click();
            // Переходим на главную страницу со списком контактов.
            webDriver.FindElements(By.Name("entry"))[index]
                .FindElements(By.TagName("td"))[7]
                .FindElement(By.TagName("a")).Click();
            // Переходим в редактирование выбранного контакта.
            webDriver.FindElement(By.Name("firstname")).Clear();
            webDriver.FindElement(By.Name("firstname")).SendKeys(contact.FirstName);
            webDriver.FindElement(By.Name("middlename")).Clear();
            webDriver.FindElement(By.Name("middlename")).SendKeys(contact.MiddleName);
            webDriver.FindElement(By.Name("lastname")).Clear();
            webDriver.FindElement(By.Name("lastname")).SendKeys(contact.LastName);
            webDriver.FindElement(By.Name("nickname")).Clear();
            webDriver.FindElement(By.Name("nickname")).SendKeys(contact.NickName);
            webDriver.FindElement(By.Name("company")).Clear();
            webDriver.FindElement(By.Name("company")).SendKeys(contact.Company);
            webDriver.FindElement(By.Name("title")).Clear();
            webDriver.FindElement(By.Name("title")).SendKeys(contact.Title);
            webDriver.FindElement(By.Name("address")).Clear();
            webDriver.FindElement(By.Name("address")).SendKeys(contact.Address);
            webDriver.FindElement(By.Name("home")).Clear();
            webDriver.FindElement(By.Name("home")).SendKeys(contact.HomePhone);
            webDriver.FindElement(By.Name("mobile")).Clear();
            webDriver.FindElement(By.Name("mobile")).SendKeys(contact.MobilePhone);
            webDriver.FindElement(By.Name("work")).Clear();
            webDriver.FindElement(By.Name("work")).SendKeys(contact.WorkPhone);
            webDriver.FindElement(By.Name("fax")).Clear();
            webDriver.FindElement(By.Name("fax")).SendKeys(contact.Fax);
            webDriver.FindElement(By.Name("email")).Clear();
            webDriver.FindElement(By.Name("email")).SendKeys(contact.Email);
            webDriver.FindElement(By.Name("email2")).Clear();
            webDriver.FindElement(By.Name("email2")).SendKeys(contact.Email2);
            webDriver.FindElement(By.Name("email3")).Clear();
            webDriver.FindElement(By.Name("email3")).SendKeys(contact.Email3);
            webDriver.FindElement(By.Name("homepage")).Clear();
            webDriver.FindElement(By.Name("homepage")).SendKeys(contact.Homepage);
            // Редактируем данные.
            webDriver.FindElement(By.Name("bday")).Click();
            new SelectElement(webDriver.FindElement(By.Name("bday"))).SelectByText("16");
            webDriver.FindElement(By.Name("bmonth")).Click();
            new SelectElement(webDriver.FindElement(By.Name("bmonth"))).SelectByText("April");
            webDriver.FindElement(By.Name("byear")).SendKeys("2000");
            // Указываем день, месяц, год рождения.
            webDriver.FindElement(By.Name("aday")).Click();
            new SelectElement(webDriver.FindElement(By.Name("aday"))).SelectByText("20");
            webDriver.FindElement(By.Name("amonth")).Click();
            new SelectElement(webDriver.FindElement(By.Name("amonth"))).SelectByText("March");
            webDriver.FindElement(By.Name("ayear")).SendKeys("1000");
            // Указываем день, месяц, год годовщины.
            webDriver.FindElement(By.Name("address2")).Clear();
            webDriver.FindElement(By.Name("address2")).SendKeys(contact.SecondaryAddress);
            webDriver.FindElement(By.Name("phone2")).Clear();
            webDriver.FindElement(By.Name("phone2")).SendKeys(contact.HomeAddress);
            webDriver.FindElement(By.Name("notes")).Clear();
            webDriver.FindElement(By.Name("notes")).SendKeys(contact.Notes);
            webDriver.FindElement(By.Name("update")).Click();
            // Добавляем вторичные личные данные.
            webDriver.FindElement(By.LinkText("home")).Click();
            // Возвращаемся на главную страницу (контакты) не дожидаясь редиректа.

            contactCache = null;
            return this;
        }

        public TestingContactHelper DeleteFirstContact(int index)
        {
            webDriver.FindElement(By.LinkText("home")).Click();
            // Переходим на главную страницу со списком контактов.
            webDriver.FindElement(By.XPath("(//input[@name='selected[]'])[" + (index + 1) + "]")).Click();
            // Ищем первый контакт и проставляем в нем чек-бокс.
            webDriver.FindElement(By.XPath("(//input[@value='Delete'])")).Click();
            // Ищем кнопку "Delete", нажимаем на нее.
            webDriver.SwitchTo().Alert().Accept();
            // Подтверждаем удаление в всплывающем окне.
            webDriver.FindElement(By.LinkText("home")).Click();
            // Возвращаемся на главную страницу (контакты) не дожидаясь редиректа.

            contactCache = null;
            return this;
        }

        public TestingContactHelper CheckContactInfo(int index)
        {
            webDriver.FindElement(By.LinkText("home")).Click();
            // Переходим на главную страницу со списком контактов.
            webDriver.FindElements(By.Name("entry"))[index]
                .FindElements(By.TagName("td"))[7]
                .FindElement(By.TagName("a")).Click();
            // Переходим в редактирование выбранного контакта.

            contactCache = null;
            return this;
        }
    }
}
