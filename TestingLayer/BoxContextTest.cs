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
    public class BoxContextTest
    {
        private BoxContext context = new BoxContext(SetupFixture.dbContext);
        private UserContext ucontext = new UserContext(SetupFixture.dbContext);
        private Box b1;
        private User u1;

        [SetUp]
        public void CreateBox()
        {
            u1 = new User("Test");
            ucontext.Create(u1);
            b1 = new Box('p', 's', 5, 0.20, u1.ID);
            b1.User = u1;
            context.Create(b1);
        }

        [TearDown]
        public void DropBox()
        {
            foreach (Box item in SetupFixture.dbContext.Boxes)
            {
                SetupFixture.dbContext.Boxes.Remove(item);
            }
            SetupFixture.dbContext.SaveChanges();
        }

        [Test]
        public void Create()
        {
            Box newBox = new Box('p', 's', 5, 0.20, u1.ID);
            newBox.User = u1;

            int boxesBefore = SetupFixture.dbContext.Boxes.Count();
            context.Create(newBox);

            int boxesAfter = SetupFixture.dbContext.Boxes.Count();
            Assert.IsTrue(boxesBefore + 1 == boxesAfter, "Create() does not work!");
        }

        [Test]
        public void Read()
        {
            Box readBox = context.Read(b1.Id);

            Assert.AreEqual(b1, readBox, "Read does not return the same object!");
        }

        [Test]
        public void ReadWithNavigationalProperties()
        {
            Box readBox = context.Read(b1.Id, true);

            Assert.That(readBox.User == u1, "u1 is not in the User list");

        }

        [Test]
        public void ReadAll()
        {
            List<Box> boxes = (List<Box>)context.ReadAll();

            Assert.That(boxes.Count != 0, "ReadAll() does not return boxes!");
        }

        [Test]
        public void Delete()
        {
            int boxesBefore = SetupFixture.dbContext.Boxes.Count();

            context.Delete(b1.Id);
            int boxesAfter = SetupFixture.dbContext.Boxes.Count();

            Assert.IsTrue(boxesBefore - 1 == boxesAfter, "Delete() does not work! 👎🏻");
        }
        [Test]
        public void TestMethod()
        {
            var answer = 42;
            Assert.That(answer, Is.EqualTo(42), "Some useful error message");
        }
    }
}

