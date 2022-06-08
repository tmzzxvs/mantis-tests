using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NUnit.Framework;
using System.IO;

namespace mantis_tests

{
    [TestFixture]
    public class AccountCreationTests : TestBase
    {
        [TestFixtureSetUp]

        public void SetUpConfig()
        {
            app.Ftp.BackUpFile("/config_inc.php");
            using (Stream localFile = File.Open("config_inc.php", FileMode.Open))
            {
                app.Ftp.Upload("/config_inc.php", localFile);
            }
                
        }

        [Test]
        public void TestAccountRegistration()
        {
            string user = GenerateRandomString(10);
            AccountData account = new AccountData()
            {
                Name = user,
                Password = "password",
                Email = $"{user}@localhost.localdomain"
            };

            app.James.DeleteAccount(account);
            app.James.AddAccount(account);

            app.Registration.Register(account);

        }

        [TestFixtureTearDown]

        public void RestoreConfig()
        {
            app.Ftp.RestoreBackupFile("/config_inc.php");
        }
    }
}
