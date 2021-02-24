﻿using System;
using System.Text;
using System.Linq;
using System.Threading;
using System.Collections.Generic;
using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Support.UI;
using ProjectAddressbook.Helpers;
using ProjectAddressbook.Model;

namespace ProjectAddressbook
{
    public class TestingPackageForGroups : BaseClass
    {
        public static IEnumerable<GroupData> RandomGroupData()
        {
            List<GroupData> groups = new List<GroupData>();
            for (int i = 0; i < 5; i++)
            {
                groups.Add(new GroupData()
                {
                    GroupName = GenerateRandomString(30),
                    GroupHeader = GenerateRandomString(100),
                    GroupFooter = GenerateRandomString(100)
                });
            }
            return groups;
        }

        [Test]
        public void CreateNewGroupTest()
        {
            app.Navigation.GoToBaseUrl();
            app.Auth.Login(new AccountData("admin", "secret"));

            List<GroupData> oldGroups = app.Groups.GetGroupList();
            Console.Out.WriteLine("Начальное кол-во групп:  " + app.Groups.GetGroupCount() + "\n");

            GroupData groups = new GroupData
            {
                //GroupName = "Agroupname",
                //GroupHeader = "groupheader",
                //GroupFooter = "groupfooter"

                GroupName = GenerateRandomString(30),
                GroupHeader = GenerateRandomString(100),
                GroupFooter = GenerateRandomString(100)
            };
            app.Groups.CreateNewGroup(groups);
            Console.Out.WriteLine(groups);

            Assert.AreEqual(oldGroups.Count + 1, app.Groups.GetGroupCount());

            List<GroupData> newGroups = app.Groups.GetGroupList();
            Console.Out.WriteLine("Конечное кол-во групп:  " + app.Groups.GetGroupCount() + "\n");

            oldGroups.Add(groups);
            oldGroups.Sort();
            newGroups.Sort();
            Assert.AreEqual(oldGroups, newGroups);
        }

        [Test]
        public void EditSecondGroupTest()
        {
            app.Navigation.GoToBaseUrl();
            app.Auth.Login(new AccountData("admin", "secret"));

            GroupData newData = new GroupData
            {
                GroupName = "editname",
                GroupHeader = "editheader",
                GroupFooter = "editfooter"
            };

            List<GroupData> oldGroups = app.Groups.GetGroupList();
            Console.Out.WriteLine("Кол-во групп: " + app.Groups.GetGroupCount() + "\n");
            GroupData oldData = oldGroups[1];
            Console.Out.WriteLine("Было: " + oldData + " (ID: " + oldData.Id + ")" + "\n");

            app.Groups.EditSecondGroup(newData, 1);

            Assert.AreEqual(oldGroups.Count, app.Groups.GetGroupCount());
            Console.Out.WriteLine("Стало: " + newData + " (ID: " + oldData.Id + ")" + "\n");

            List<GroupData> newGroups = app.Groups.GetGroupList();
            oldGroups[1].GroupName = newData.GroupName;
            oldGroups.Sort();
            newGroups.Sort();
            Assert.AreEqual(oldGroups, newGroups);

            foreach (GroupData group in newGroups)
            {
                if (group.Id == oldData.Id)
                {
                    Assert.AreEqual(newData.GroupName, group.GroupName);
                }
            }
        }

        [Test]
        public void EditParent3GroupTest()
        {
            app.Navigation.GoToBaseUrl();
            app.Auth.Login(new AccountData("admin", "secret"));
            app.Groups.EditParent3Group(2);
        }

        [Test]
        public void RemoveFirstGroupTest()
        {
            app.Navigation.GoToBaseUrl();
            app.Auth.Login(new AccountData("admin", "secret"));

            List<GroupData> oldGroups = app.Groups.GetGroupList();
            Console.Out.WriteLine("Изначальное кол-во групп: " + app.Groups.GetGroupCount() + "\n");
            GroupData oldValue = oldGroups[0];

            app.Groups.RemoveFirstGroup(0);

            Assert.AreEqual(oldGroups.Count - 1, app.Groups.GetGroupCount());
            List<GroupData> newGroups = app.Groups.GetGroupList();
            Console.Out.WriteLine("Кол-во групп после удаления: " + app.Groups.GetGroupCount() + " (ID удаленной группы: " + oldValue.Id + ")" + "\n" + "\n");

            oldGroups.RemoveAt(0);
            Assert.AreEqual(oldGroups, newGroups);
            Console.Out.WriteLine("Список групп: " + "\n");

            foreach (GroupData group in newGroups)
            {
                Assert.AreNotEqual(group.Id, oldValue.Id);
                Console.Out.WriteLine("ID Группы: " + group.Id);
            }
        }
    }
}
