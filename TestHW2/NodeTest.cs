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
            Node end = begin;
            for (int i = 0; i < 10; i++)
            {
                begin.AddNodeAfter(end, i + 1);
                end = end.NextNode;
            }
            int expected = 10;
            int actual = end.value;
            Assert.AreEqual(expected, actual, 0, "����� AddNodeAfter �������� �� �����");            
            expected = 11;
            actual = begin.GetCount();
            Assert.AreEqual(expected, actual, 0, "����� GetCount �������� �� �����");
        }

        [TestMethod]
        public void NodeTest2()
        {
            Node begin = new Node() { value = 0 };
            Node end = begin;
            for (int i = 0; i < 10; i++)
            {
                begin.AddNodeAfter(end, i + 1);
                end = end.NextNode;
            }
            begin.AddNode(100);
            int expected = 100;
            int actual = end.NextNode.value;
            Assert.AreEqual(expected, actual, 0, "����� AddNode �������� �� �����");
            expected = 12;
            actual = begin.GetCount();
            Assert.AreEqual(expected, actual, 0, "����� AddNode �������� �� �����");
        }

        [TestMethod]
        public void NodeTest3()
        {
            Node begin = new Node() { value = 0 };
            Node end = begin;
            for (int i = 0; i < 10; i++)
            {
                begin.AddNodeAfter(end, i + 1);
                end = end.NextNode;
            }
            int expected = 5;
            int actual = begin.FindNode(5).value;
            Assert.AreEqual(expected, actual, 0, "����� FindNode �������� �� �����");
        }
        [TestMethod]
        public void NodeTest4()
        {
            Node begin = new Node() { value = 0 };
            Node end = begin;
            for (int i = 0; i < 10; i++)
            {
                begin.AddNodeAfter(end, i + 1);
                end = end.NextNode;
            }
            begin.RemoveNode(end);
            int expected = 10;
            int actual = begin.GetCount();
            Assert.AreEqual(expected, actual, 0, "����� RemoveNode(Node) �������� �� �����");
            begin.RemoveNode(1);            
            object exp= null;
            object o = begin.FindNode(1);
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
