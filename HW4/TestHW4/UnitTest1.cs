using HW4;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace TestHW4
{
    [TestClass]
    public class UnitTest1
    {
        [TestMethod]
        public void TestTreeAdd()
        {
            var myTree = new Tree();
            myTree.Add(6);
            myTree.Add(3);
            myTree.Add(7);
            myTree.Add(1);
            int expected = 1;
            int current = myTree.Search(1).Data;
            Assert.AreEqual(expected, current);
        }

        [TestMethod]
        public void TestTreeSearch()
        {
            var myTree = new Tree();
            myTree.Add(6);
            myTree.Add(7);
            myTree.Add(8);
            myTree.Add(9);
            int expected = 9;
            int current = myTree.Search(9).Data;
            Assert.AreEqual(expected, current);
        }

        [TestMethod]
        public void TestTreeRemove()
        {
            var myTree = new Tree();
            myTree.Add(6);
            myTree.Add(3);
            myTree.Add(7);
            myTree.Add(1);
            myTree.Remove(6);
            object expected = null;
            object current = myTree.Search(6);
            Assert.AreEqual(expected, current);
        }

     
        [TestMethod]
        public void TestTreeFingDepth()
        {
            var myTree = new Tree();
            myTree.Add(6);
            myTree.Add(3);
            myTree.Add(7);
            myTree.Add(1);
            myTree.Remove(6);
            myTree.Add(9);
            int expected = 2;
            int current = myTree.Depth();
            Assert.AreEqual(expected, current);
        }
    }
}
