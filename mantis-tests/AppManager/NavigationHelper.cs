using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;

namespace mantis_tests
{
    public class NavigationHelper : HelperBase
    {
        private readonly string baseURL;

        public NavigationHelper(ApplicationManager manager, string baseURL) : base(manager)
        {
            this.baseURL = baseURL;
        }

        public NavigationHelper GoToHomePage()
        {
            if (driver.Url == baseURL)
            {
                return this;
            }
            driver.Navigate().GoToUrl(baseURL);
            return this;
        }
    }
}