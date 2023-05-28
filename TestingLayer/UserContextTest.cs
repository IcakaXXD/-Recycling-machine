using BusinessLayer;
using DataLayer;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Intrinsics.X86;
using System.Text;
using System.Threading.Tasks;

namespace TestingLayer
{
    public class UserContextTest
    {
        private UserContext context = new UserContext(SetupFixture.dbContext);
        private BottleContext bcontext = new BottleContext(SetupFixture.dbContext);
        private User u1;
        private Bottle b1;

        [SetUp]
        public void CreateUser()
        {
            u1 = new User("Test");
            context.Create(u1);
            b1 = new Bottle('p', 's', 5, 0.20, u1.ID);
            bcontext.Create(b1);
            u1.bottles.Add(b1);
        }

        [TearDown]
        public void DropUser()
        {
            foreach (User item in SetupFixture.dbContext.Users)
            {
                SetupFixture.dbContext.Users.Remove(item);
            }
            SetupFixture.dbContext.SaveChanges();
        }

        [Test]
        public void Create()
        {
            User newUser = new User("petar");

            int usersBefore = SetupFixture.dbContext.Users.Count();
            context.Create(newUser);

            int usersAfter = SetupFixture.dbContext.Users.Count();
            Assert.IsTrue(usersBefore + 1 == usersAfter, "Create() does not work!");
        }

        [Test]
        public void Read()
        {
            User readUser= context.Read(u1.ID);

            Assert.AreEqual(u1, readUser, "Read does not return the same object!");
        }

        [Test]
        public void ReadWithNavigationalProperties()
        {
            User readUser = context.Read(u1.ID, true);

            Assert.That(readUser.bottles.Contains(b1), "b1 is not in the bottles list!");

        }

        [Test]
        public void ReadAll()
        {
            List<User> users = (List<User>)context.ReadAll();

            Assert.That(users.Count != 0, "ReadAll() does not return users!");
        }

        [Test]
        public void Delete()
        {
            int usersBefore = SetupFixture.dbContext.Users.Count();

            context.Delete(u1.ID);
            int usersAfter = SetupFixture.dbContext.Users.Count();

            Assert.IsTrue(usersBefore - 1 == usersAfter, "Delete() does not work! 👎🏻");
        }
        [Test]
        public void TestMethod()
        {
            var answer = 42;
            Assert.That(answer, Is.EqualTo(42), "Some useful error message");
        }
    }
}
