using NUnit.Framework;
using System;
using System.Collections.Generic;

namespace mantis_tests
{
    [TestFixture]
    public class ProjectRemovalTests : AuthTestBase
    {
        [Test]
        public void RemoveProjectTest()
        {
            AccountData account = new AccountData()
            {
                Name = "administrator",
                Password = "secret"
            };
            if (app.api.GetProjectsList(account).Count == 0)
            {
                ProjectData project = new ProjectData()
                {
                    Name = GenerateRandomString(15),
                    Description = GenerateRandomString(100),
                };
                app.api.Create(account, project);
            }
            List<ProjectData> oldList = app.api.GetProjectsList(account);

            app.projectManagementHelper.Remove(0);

            List<ProjectData> newList = app.api.GetProjectsList(account);
            ProjectData toBeRemoved = oldList[0];
            oldList.RemoveAt(0);
            oldList.Sort();
            newList.Sort();

            foreach (ProjectData project in newList)
            {
                Assert.AreNotEqual(project.Id, toBeRemoved.Id);
            }

            Assert.AreEqual(oldList.Count, newList.Count);
            Assert.AreEqual(oldList, newList);
        }
    }
}