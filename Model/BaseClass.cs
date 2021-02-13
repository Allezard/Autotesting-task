using System;
using System.Linq;
using System.Text;
using System.Threading;
using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Support.UI;
using ProjectAddressbook.Helpers;

namespace ProjectAddressbook.Model
{
    public class BaseClass
    {
        protected ApplicationManager app;

        [SetUp]
        public void SetupChromeDriver()
        {
            app = ApplicationManager.GetInstance();
        }
    }
}