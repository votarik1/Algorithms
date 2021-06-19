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
            Node begin = new Node() {value = 0 };
            LinkedList myList = new LinkedList() { StartNode = begin };
            Node end = begin;
            for (int i = 0; i < 10; i++)
            {
                myList.AddNodeAfter(end, i + 1);
                
                end = end.NextNode;
            }
            int expected = 10;
            int actual = end.value;
            Assert.AreEqual(expected, actual, 0, "Метод AddNodeAfter работает не верно");            
            expected = 11;
            actual = myList.GetCount();
            Assert.AreEqual(expected, actual, 0, "Метод GetCount работает не верно");
        }

        [TestMethod]
        public void NodeTest2()
        {
            Node begin = new Node() { value = 0 };
            LinkedList myList = new LinkedList() { StartNode = begin };
            Node end = begin;
            for (int i = 0; i < 10; i++)
            {
                myList.AddNodeAfter(end, i + 1);
                end = end.NextNode;
            }
            myList.AddNode(100);
            int expected = 100;
            int actual = end.NextNode.value;
            Assert.AreEqual(expected, actual, 0, "Метод AddNode работает не верно");
            expected = 12;
            actual = myList.GetCount();
            Assert.AreEqual(expected, actual, 0, "Метод AddNode работает не верно");
        }

        [TestMethod]
        public void NodeTest3()
        {
            Node begin = new Node() { value = 0 };
            LinkedList myList = new LinkedList() { StartNode = begin };
            Node end = begin;
            for (int i = 0; i < 10; i++)
            {
                myList.AddNodeAfter(end, i + 1);
                end = end.NextNode;
            }
            int expected = 5;
            int actual = myList.FindNode(5).value;
            Assert.AreEqual(expected, actual, 0, "Метод FindNode работает не верно");
        }
        [TestMethod]
        public void NodeTest4()
        {
            Node begin = new Node() { value = 0 };
            LinkedList myList = new LinkedList() { StartNode = begin };
            Node end = begin;
            for (int i = 0; i < 10; i++)
            {
                myList.AddNodeAfter(end, i + 1);
                end = end.NextNode;
            }
            myList.RemoveNode(end);
            int expected = 10;
            int actual = myList.GetCount();
            Assert.AreEqual(expected, actual, 0, "Метод RemoveNode(Node) работает не верно");
            myList.RemoveNode(1);            
            object exp= null;
            object o = myList.FindNode(1);
            Assert.AreEqual(exp, o, "Метод RemoveNode(int) работает не верно");

        }
        [TestMethod]
        public void BinsearchTest1()
        {
            int[] arr = new int[] {1,4,67,89,121,144,245};
            int expected = 4;
            int actual = Serch.Binsearch(arr,121);
            Assert.AreEqual(expected, actual, "Метод Binsearch работает не верно");
        }

        [TestMethod]
        public void BinsearchTest2()
        {
            int[] arr = new int[] { 1, 4, 67, 89, 121, 144, 245 };
            int expected = -1;
            int actual = Serch.Binsearch(arr, 500);
            Assert.AreEqual(expected, actual, "Метод Binsearch работает не верно");
        }

    }
}
