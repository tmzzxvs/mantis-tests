using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Firefox;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Support.UI;

namespace mantis_tests
{
    public class ApplicationManager
    {
        protected IWebDriver driver;
        protected string baseURL;
        protected string mantis_ver;

        public RegistrationHelper Registration { get; set; }
        public FtpHelper Ftp { get; set; }
        public JamesHelper James { get; set; }
        public MailHepler Mail { get; set; }
        public NavigationHelper Navigation { get; set; }
        public AuthHelper authHelper { get; set; }
        public ProjectManagementHelper projectManagementHelper { get; set; }
        public APImantisHelper api { get; set; }


        private static readonly ThreadLocal<ApplicationManager> app = new ThreadLocal<ApplicationManager>();

        private ApplicationManager()
        {
     //     driver = new FirefoxDriver();
            driver = new ChromeDriver();
            baseURL = "http://localhost/mantisbt-2.25.4/login_page.php";
            mantis_ver = "2.25.4";
            Registration = new RegistrationHelper(this);
            Ftp = new FtpHelper(this);
            James = new JamesHelper(this);
            Mail = new MailHepler(this);
            Navigation = new NavigationHelper(this, baseURL, mantis_ver);
            authHelper = new AuthHelper(this);
            projectManagementHelper = new ProjectManagementHelper(this);
            api = new APImantisHelper(this);
        }
        ~ApplicationManager()
        {
            try
            {
                driver.Quit();
            }
            catch (Exception)
            {
                // Ignore errors if unable to close the browser
            }
        }
        public static ApplicationManager GetInstance()
        {
            if (! app.IsValueCreated)
            {
                ApplicationManager newInstance = new ApplicationManager();
                newInstance.Navigation.GoToHomePage();
                app.Value = newInstance;

            }
            return app.Value;
        }
        public IWebDriver Driver 
        {
                get { return driver; } 
        }
    }
       
}
