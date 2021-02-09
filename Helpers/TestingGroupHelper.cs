using System;
using System.Collections.Generic;
using System.Text;
using NUnit.Framework;
using OpenQA.Selenium;
using ProjectAddressbook.Helpers;
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
            webDriver.FindElement(By.ClassName("admin")).Click();
            // Переходим во вкладку "groups".
            webDriver.FindElement(By.XPath("(//input[@name='selected[]'])[" + index + "]")).Click();
            webDriver.FindElement(By.Name("edit")).Click();
            // Выбираем и редактируем вторую группу
            webDriver.FindElement(By.Name("group_name")).Clear();
            webDriver.FindElement(By.Name("group_name")).SendKeys(group.GroupName);
            webDriver.FindElement(By.Name("group_header")).Clear();
            webDriver.FindElement(By.Name("group_header")).SendKeys(group.GroupHeader);
            webDriver.FindElement(By.Name("group_footer")).Clear();
            webDriver.FindElement(By.Name("group_footer")).SendKeys(group.GroupFooter);
            // Очищаем и заполняем поля: "Group name", (Logo), (Comment). 
            webDriver.FindElement(By.Name("update")).Click();
            // Нажимаем на кнопку "Update".
            webDriver.FindElement(By.LinkText("group page")).Click();
            // Возвращаемся на вкладку /addressbook/group по текстовой ссылке "group page".
        }
    }
}
