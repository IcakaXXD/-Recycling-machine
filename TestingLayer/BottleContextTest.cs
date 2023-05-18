using BusinessLayer;
using DataLayer;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TestingLayer
{
    [TestFixture]
    public class BottleContextTest
    {
        private BottleContext context = new BottleContext(SetupFixture.dbContext);
        private UserContext ucontext = new UserContext(SetupFixture.dbContext);
        private Bottle b1;
        private User u1;

        [SetUp]
        public void CreateBottle()
        {
            u1 = new User("Test");
            ucontext.Create(u1);
            b1 = new Bottle('p','s',5,0.20,u1.ID);
            
            b1.User = u1;

            context.Create(b1);
        }

        [TearDown]
        public void DropBottle()
        {
            foreach (Bottle item in SetupFixture.dbContext.Bottles)
            {
                SetupFixture.dbContext.Bottles.Remove(item);   
            }
            SetupFixture.dbContext.SaveChanges();
        }

        [Test] 
        public void Create()
        {
            Bottle newBottle = new Bottle('p', 's', 5, 0.20, u1.ID);
            newBottle.User = u1;

            int bottlesBefore = SetupFixture.dbContext.Bottles.Count();
            context.Create(newBottle);

            int bottlesAfter = SetupFixture.dbContext.Bottles.Count();
            Assert.IsTrue(bottlesBefore + 1 == bottlesAfter, "Create() does not work!");
        }

        [Test]
        public void Read()
        {
            Bottle readBottle = context.Read(b1.Id);

            Assert.AreEqual(b1, readBottle, "Read does not return the same object!");
        }

        [Test]
        public void ReadWithNavigationalProperties()
        {
            Bottle readBottle = context.Read(b1.Id, true);

            Assert.That(readBottle.User == u1, "u1 is not in the User list");

        }

        [Test]
        public void ReadAll()
        {
            List<Bottle> bottles = (List<Bottle>)context.ReadAll();

            Assert.That(bottles.Count != 0, "ReadAll() does not return brands!");
        }

        [Test]
        public void Delete()
        {
            int bottlesBefore = SetupFixture.dbContext.Bottles.Count();

            context.Delete(b1.Id);
            int bottlesAfter = SetupFixture.dbContext.Bottles.Count();

            Assert.IsTrue(bottlesBefore - 1 == bottlesAfter, "Delete() does not work! 👎🏻");
        }
        [Test]
        public void TestMethod()
        {
            var answer = 42;
            Assert.That(answer, Is.EqualTo(42), "Some useful error message");
        }
    }
}
