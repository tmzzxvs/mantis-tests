using NUnit.Framework;
using System;

namespace mantis_tests
{
    [TestFixture]
    public class JamesTests : TestBase
    {
        [Test]
        public void JamesTest()
        {
            AccountData account = new AccountData()
            {
                Name = "xxx",
                Password = "yyy"
            };
            Assert.IsFalse(app.James.VerifyAccount(account));
            app.James.AddAccount(account);
            Assert.IsTrue(app.James.VerifyAccount(account));
            app.James.DeleteAccount(account);
            Assert.IsFalse(app.James.VerifyAccount(account));

        }
    }
}
