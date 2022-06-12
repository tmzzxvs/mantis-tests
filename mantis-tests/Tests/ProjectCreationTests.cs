using NUnit.Framework;
using System.Collections.Generic;
using System;

namespace mantis_tests
{
    [TestFixture]
    public class ProjectCreationTests : ProjectManagementTestBase
    {
        [Test]
        public void ProjectCreationTest()
        {
            AccountData account = new AccountData()
            {
                Name = "administrator",
                Password = "secret"
            };
            ProjectData project = new ProjectData()
            {
                Name = "project1",
                Description = GenerateRandomString(100)
            };

            List<ProjectData> oldList = app.api.GetProjectsList(account);

            app.projectManagementHelper.Create(project);

            List<ProjectData> newList = app.api.GetProjectsList(account);

            oldList.Add(project);
            oldList.Sort();
            newList.Sort();

            Assert.AreEqual(oldList.Count, newList.Count);
            Assert.AreEqual(oldList, newList);
        }
    }
}