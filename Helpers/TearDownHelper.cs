using System;
using System.Collections.Generic;
using System.Text;
using NUnit.Framework;
using OpenQA.Selenium;
using ProjectAddressbook.Helpers;
using ProjectAddressbook.Model;

namespace ProjectAddressbook.Helpers
{
    public class TearDownHelper : BaseHelper
    {
        protected StringBuilder verificationErrors;

        public TearDownHelper(IWebDriver webDriver, StringBuilder verificationErrors)
            : base(webDriver)
        {
            this.verificationErrors = verificationErrors;
        }

        public void TestQuit()
        {
            try
            {
                webDriver.Quit();
            }
            catch (Exception)
            {
                // Ignore errors if unable to close the browser
            }
            Assert.AreEqual("", verificationErrors.ToString());
        }
    }
}
