namespace StupidList.Tests
{
    using Microsoft.VisualStudio.TestTools.UnitTesting;

    [TestClass]
    public class StupidListTests
    {
        private StupidList<int> list;

        [TestInitialize]
        public void TestInitialize()
        {
            this.list = new StupidList<int>();
        }

        [TestMethod]
        public void AddSingleElementTest()
        {
            this.list.Add(1);

            Assert.AreEqual(1, this.list.Lenght);
        }

        [TestMethod]
        public void AddMultipleElementsTest()
        {
            const int LoopCount = 1000;

            for (var i = 0; i < LoopCount; i++)
            {
                this.list.Add(i);
            }

            Assert.AreEqual(LoopCount, this.list.Lenght);
        }

        [TestMethod]
        public void GetListLenghtTest()
        {
            this.list.Add(1);
            Assert.AreEqual(1, this.list.Lenght);

            this.list.Add(1);
            Assert.AreEqual(2, this.list.Lenght);

            this.list.Remove(0);
            Assert.AreEqual(1, this.list.Lenght);
        }

        [TestMethod]
        public void EmptyListTest()
        {
            Assert.AreEqual(0, this.list.Lenght);
        }

        [TestMethod]
        public void GetFirstElementTest()
        {
            this.list.Add(3);
            this.list.Add(1);
            this.list.Add(2);

            Assert.AreEqual(3, this.list.First);
        }

        [TestMethod]
        public void GetLastElementTest()
        {
            this.list.Add(3);
            this.list.Add(1);
            this.list.Add(2);

            Assert.AreEqual(2, this.list.Last);
        }

        [TestMethod]
        public void RemoveSingleElementTest()
        {
            this.list.Add(1);
            this.list.Remove(0);

            Assert.AreEqual(0, this.list.Lenght);
        }

        [TestMethod]
        public void RemoveMultipleElementsTest()
        {
            const int LoopCount = 1000;
            const int ElementsToRemove = 10;

            for (var i = 0; i < LoopCount; i++)
            {
                this.list.Add(i);
            }

            for (var i = 0; i < ElementsToRemove; i++)
            {
                this.list.Remove(i);
            }

            Assert.AreEqual(LoopCount - ElementsToRemove, this.list.Lenght);
            Assert.AreEqual(1, this.list.First);
        }

        [TestMethod]
        public void RemoveFirstElementTest()
        {
            this.list.Add(10);
            this.list.Add(20);
            this.list.Add(30);

            this.list.RemoveFirst();

            Assert.AreEqual(2, this.list.Lenght);
            Assert.AreEqual(20, this.list.First);
        }

        [TestMethod]
        public void RemoveLastElementTest()
        {
            this.list.Add(3);
            this.list.Add(2);
            this.list.Add(1);

            this.list.RemoveLast();

            Assert.AreEqual(2, this.list.Lenght);
            Assert.AreEqual(2, this.list.Last);
        }
    }
}