using System;
using System.Threading.Tasks;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using TaskRobo.Models;
using TaskRobo.Repository;

namespace TaskRoboTest
{
    [TestClass]
    public class UnitTest1
    {
        CategoryRepository catrp;
        TaskRepository taskrp;
        UserRepository userrp;
        readonly TaskDbContext context;
        public UnitTest1()
        {
            catrp = new CategoryRepository();
            taskrp = new TaskRepository();
            userrp = new UserRepository();
            context = new TaskDbContext();
        }
        [TestMethod]
        public void TestCreateUser()
        {
            AppUser appUser = new AppUser();
            appUser.Email = "Testtry123@gmail.com";
            appUser.Password = "test123";
            int res = userrp.CreateUser(appUser);
            Assert.AreEqual(1, res);
        }
        [TestMethod]
        public void TestAuthenticatedUser()
        {
            AppUser appUser = new AppUser();
            //appUser.Email = "Test123@gmail.com";
            appUser.Email = "mk@test.com";
            appUser.Password = "123";
            bool res = userrp.IsAuthenticated(appUser);
            Assert.AreEqual(true, res);
        }
        [TestMethod]
        public void TestSaveCategory()
        {
            Category cat = new Category();
            cat.CategoryTitle = "Test New Cat";
            cat.UserID = userrp.GetUserIdByEmail("Test123@gmail.com");
            var res = catrp.SaveCategory(cat);
            Assert.AreNotEqual(0, res);
        }
        [TestMethod]
        public void TestCatData()
        {
            Category cat = new Category();
            cat.CategoryTitle = "test";
            cat.UserID = "227eaaab-7173-48a0-8c64-32344ac6122f";
            cat.CategoryID = 2;
            Category res = catrp.GetCategoryById(2);
            Assert.AreEqual(cat, res);
        }
        [TestMethod]
        public void TestSaveTask()
        {
            UserTask task = new UserTask();
            task.TaskTitle = "Test New task";
            task.TaskContent = "testcontentfortask";
            task.TaskStatus = "in process";
            task.CategoryID = 1;
            var res = taskrp.SaveTask(task);
            Assert.AreNotEqual(0, res);
        }
        [TestMethod]
        public void TestTaskData()
        {
            UserTask task = new UserTask();
            task.TaskTitle = "test";
            task.TaskContent = "check";
            task.TaskStatus = "testme";
            task.CategoryID = 1;
            UserTask res = taskrp.GetTaskById("mk@test.com",2);
            Assert.AreEqual(task, res);
        }
        [TestMethod]
        public void TestDeleteTask()
        {
            taskrp.DeleteTask("mk@test.com",1);
        }

    }
}
