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
    public class TestingGroupHelper : BaseHelper
    {
        public TestingGroupHelper(IWebDriver webDriver)
            : base(webDriver)
        {
        }

        public void CreateNewGroup(GroupData group)
        {
            webDriver.FindElement(By.ClassName("admin")).Click();
            // Переходим во вкладку "groups".
            webDriver.FindElement(By.Name("new")).Click();
            // Кликаем на кнопку "New group".
            webDriver.FindElement(By.Name("group_name")).SendKeys(group.GroupName);
            webDriver.FindElement(By.Name("group_header")).SendKeys(group.GroupHeader);
            webDriver.FindElement(By.Name("group_footer")).SendKeys(group.GroupFooter);
            // Заполняем поля: "Group name", (Logo), (Comment). 
            webDriver.FindElement(By.Name("submit")).Click();
            // Нажимаем на кнопку "Enter information".
            webDriver.FindElement(By.LinkText("group page")).Click();
            // Возвращаемся на вкладку /addressbook/group по текстовой ссылке "group page".
        }

        public void RemoveFirstGroup(int index)
        {
            webDriver.FindElement(By.ClassName("admin")).Click();
            // Переходим во вкладку "groups".
            webDriver.FindElement(By.XPath("(//input[@name='selected[]'])[" + index + "]")).Click();
            webDriver.FindElement(By.Name("delete")).Click();
            // Выбираем и удаляем первую группу
            webDriver.FindElement(By.LinkText("group page")).Click();
            // Возвращаемся на вкладку /addressbook/group по текстовой ссылке "group page".
        }

        public void EditSecondGroup(GroupData group, int index)
        {
            By locatorFooter = By.Name("group_footer");
            string textFooter = group.GroupFooter;

            webDriver.FindElement(By.ClassName("admin")).Click();
            // Переходим во вкладку "groups".
            webDriver.FindElement(By.XPath("(//input[@name='selected[]'])[" + index + "]")).Click();
            webDriver.FindElement(By.Name("edit")).Click();
            // Выбираем и редактируем вторую группу
            EditGropMethod(By.Name("group_name"), group.GroupName);
            EditGropMethod(By.Name("group_header"), group.GroupHeader);
            webDriver.FindElement(locatorFooter).Clear();
            webDriver.FindElement(locatorFooter).SendKeys(textFooter);
            // Очищаем и заполняем поля: "Group name", (Logo), (Comment). 
            webDriver.FindElement(By.Name("update")).Click();
            // Нажимаем на кнопку "Update".
            webDriver.FindElement(By.LinkText("group page")).Click();
            // Возвращаемся на вкладку /addressbook/group по текстовой ссылке "group page".
        }

        public void EditTheThirdGroup(int index)
        {
            webDriver.FindElement(By.ClassName("admin")).Click();
            // Переходим во вкладку "groups".
            webDriver.FindElement(By.XPath("(//input[@name='selected[]'])[" + index + "]")).Click();
            webDriver.FindElement(By.Name("edit")).Click();
            webDriver.FindElement(By.Name("group_parent_id")).Click();
            new SelectElement(webDriver.FindElement(By.Name("group_parent_id"))).SelectByText("test");
            // Добавляем группу родителя "Parent group". 
            webDriver.FindElement(By.Name("update")).Click();
            // Нажимаем на кнопку "Update".
            webDriver.FindElement(By.LinkText("group page")).Click();
            // Возвращаемся на вкладку /addressbook/group по текстовой ссылке "group page".
        }
    }
}
