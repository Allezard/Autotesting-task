using System;
using System.Linq;
using System.Text;
using System.Threading;
using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Support.UI;
using ProjectAddressbook.Helpers;
using System.Collections.Generic;

namespace ProjectAddressbook.Model
{
    public class BaseClass
    {
        protected ApplicationManager app;

        [SetUp]
        public void SetupApp()
        {
            app = ApplicationManager.GetInstance();
        }

        public static string GenerateRandomString(int size, bool lowerCase = true)
        {
            Random rnd = new Random();
            StringBuilder builder = new StringBuilder();

            char l;

            for (int i = 0; i < size; i++)
            {
                l = Convert.ToChar(Convert.ToInt32(Math.Floor(26 * rnd.NextDouble() + 65)));
                builder.Append(l);
            }

            if (lowerCase)
                return builder.ToString().ToLower();

            return builder.ToString();
        }
    }
}