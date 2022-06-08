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
        public NavigationHelper GoToManageOverviewPage()
        {
            driver.FindElement(By.XPath("//a[@href='/mantisbt-2.25.4/manage_overview_page.php']")).Click();

            return this;
        }
        public NavigationHelper GoToProjectControlPage()
        {
            driver.FindElement(By.XPath("//a[@href='/mantisbt-2.25.4/manage_proj_page.php']")).Click();

            return this;
        }
    }
}