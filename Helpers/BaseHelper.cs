using System;
using System.Collections.Generic;
using System.Text;
using NUnit.Framework;
using OpenQA.Selenium;
using ProjectAddressbook.Model;

namespace ProjectAddressbook.Helpers
{
    public class BaseHelper
    {
        protected IWebDriver webDriver;

        public BaseHelper(IWebDriver webDriver)
        {
            this.webDriver = webDriver;
        }

    }
}
