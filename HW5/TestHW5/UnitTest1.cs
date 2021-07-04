using Microsoft.VisualStudio.TestTools.UnitTesting;
using HW5;
namespace TestHW5
{
    [TestClass]
    public class UnitTest1
    {
        [TestMethod]
        public void TestBFSSearch()
        {
            Tree<int> myTree = new Tree<int>();
            for (int i = 0; i < 15; i++)
            {
                myTree.Add(i);
            }
             int expected = 14;
            int actual = myTree.BFSSearch(14).Data;
            Assert.AreEqual(expected, actual, "����� TestBFSSearch() �������� �������");

            object  exp = null;
            var act = myTree.BFSSearch(15);
            Assert.AreEqual(exp, act, "����� TestBFSSearch() �������� �������");

        }


        [TestMethod]
        public void TestDFSSearch()
        {
            Tree<int> myTree = new Tree<int>();
            for (int i = 0; i < 15; i++)
            {
                myTree.Add(i);
            }
            int expected = 14;
            int actual = myTree.DFSSearch(14).Data;
            Assert.AreEqual(expected, actual, "����� TestDFSSearch() �������� �������");

            object exp = null;
            var act = myTree.DFSSearch(15);
            Assert.AreEqual(exp, act, "����� TestDFSSearch() �������� �������");

        }


    }
}
