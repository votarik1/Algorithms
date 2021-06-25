using Microsoft.VisualStudio.TestTools.UnitTesting;
using HW2;

namespace TestHW2
{
    [TestClass]
    public class NodeTest
    {
        [TestMethod]
        public void NodeTest1()
        {
            LinkedList myList = new LinkedList();
            myList.AddNode(0);
            for (int i = 0; i < 10; i++)
            {
                myList.AddNodeAfter(myList.LastNode, i+1);
            }
            int expected = 10;
            int actual = myList.LastNode.value;
            Assert.AreEqual(expected, actual, 0, "����� AddNodeAfter �������� �� �����");            
            expected = 11;
            actual = myList.Count;
            Assert.AreEqual(expected, actual, 0, "�������� Count �������� �� �����");
        }

        [TestMethod]
        public void NodeTest2()
        {
            LinkedList myList = new LinkedList();
            for (int i = 0; i < 11; i++)
            {
                myList.AddNode(i);
            }
            int expected = 10;
            int actual = myList.LastNode.value;
            Assert.AreEqual(expected, actual, 0, "����� AddNode �������� �� �����");
        }

        [TestMethod]
        public void NodeTest3()
        {
            LinkedList myList = new LinkedList();
            for (int i = 0; i < 11; i++)
            {
                myList.AddNode(i);
            }
            int expected = 5;
            int actual = myList.FindNode(5).value;
            Assert.AreEqual(expected, actual, 0, "����� FindNode �������� �� �����");
        }
        [TestMethod]
        public void NodeTest4()
        {
            LinkedList myList = new LinkedList();
            for (int i = 0; i < 11; i++)
            {
                myList.AddNode(i);
            }
            myList.RemoveNode(myList.LastNode);
            int expected = 10;
            int actual = myList.Count;
            Assert.AreEqual(expected, actual, 0, "����� RemoveNode(Node) �������� �� �����");
            myList.RemoveNode(1);
            object exp= null;
            object o = myList.FindNode(1);
            Assert.AreEqual(exp, o, "����� RemoveNode(int) �������� �� �����");

        }
        [TestMethod]
        public void BinsearchTest1()
        {
            int[] arr = new int[] {1,4,67,89,121,144,245};
            int expected = 4;
            int actual = Serch.Binsearch(arr,121);
            Assert.AreEqual(expected, actual, "����� Binsearch �������� �� �����");
        }

        [TestMethod]
        public void BinsearchTest2()
        {
            int[] arr = new int[] { 1, 4, 67, 89, 121, 144, 245 };
            int expected = -1;
            int actual = Serch.Binsearch(arr, 500);
            Assert.AreEqual(expected, actual, "����� Binsearch �������� �� �����");
        }

    }
}
