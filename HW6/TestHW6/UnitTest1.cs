using Microsoft.VisualStudio.TestTools.UnitTesting;
using HW6;

namespace TestHW6
{
    [TestClass]
    public class UnitTest1
    {

        Graph myGraph = new Graph(9);

        public UnitTest1()
        {
            myGraph.Data[0] = "םמכü";
            myGraph.Data[1] = "מהטם";
            myGraph.Data[2] = "הגא";
            myGraph.Data[3] = "ענט";
            myGraph.Data[4] = "קועûנו";
            myGraph.Data[5] = "ןÿעü";
            myGraph.Data[6] = "רוסעü";
            myGraph.Data[7] = "סולü";
            myGraph.Data[8] = "גמסולü";

            myGraph.AdjacencyMatrix[0, 1]++;
            myGraph.AdjacencyMatrix[0, 2]++;
            myGraph.AdjacencyMatrix[1, 0]++;
            myGraph.AdjacencyMatrix[1, 3]++;
            myGraph.AdjacencyMatrix[1, 4]++;
            myGraph.AdjacencyMatrix[2, 0]++;
            myGraph.AdjacencyMatrix[2, 3]++;
            myGraph.AdjacencyMatrix[2, 5]++;
            myGraph.AdjacencyMatrix[3, 1]++;
            myGraph.AdjacencyMatrix[3, 2]++;
            myGraph.AdjacencyMatrix[4, 1]++;
            myGraph.AdjacencyMatrix[4, 5]++;
            myGraph.AdjacencyMatrix[4, 6]++;
            myGraph.AdjacencyMatrix[5, 2]++;
            myGraph.AdjacencyMatrix[5, 4]++;
            myGraph.AdjacencyMatrix[5, 7]++;
            myGraph.AdjacencyMatrix[6, 4]++;
            myGraph.AdjacencyMatrix[6, 8]++;
            myGraph.AdjacencyMatrix[7, 5]++;
            myGraph.AdjacencyMatrix[7, 8]++;
            myGraph.AdjacencyMatrix[8, 6]++;
            myGraph.AdjacencyMatrix[8, 7]++;

        }
           

        [TestMethod]
        public void TestBFSerch1()
        {
            int expected = 0;
            int received = myGraph.BFSearch("םמכü");
            Assert.AreEqual(expected, received);
        }

        [TestMethod]
        public void TestBFSerch2()
        {
            int expected = 8;
            int received = myGraph.BFSearch("גמסולü");
            Assert.AreEqual(expected, received);
        }


        [TestMethod]
        public void TestBFSerch3()
        {
            int expected = 5;
            int received = myGraph.BFSearch("ןÿעü");
            Assert.AreEqual(expected, received);
        }


        [TestMethod]
        public void TestBFSerch4()
        {
            int expected = -1;
            int received = myGraph.BFSearch("אבגדה");
            Assert.AreEqual(expected, received);
        }

        [TestMethod]
        public void TestDFSerch1()
        {
            int expected = 0;
            int received = myGraph.DFSearch("םמכü");
            Assert.AreEqual(expected, received);
        }

        [TestMethod]
        public void TestDFSerch2()
        {
            int expected = 1;
            int received = myGraph.DFSearch("מהטם");
            Assert.AreEqual(expected, received);
        }


        [TestMethod]
        public void TestDFSerch3()
        {
            int expected = 5;
            int received = myGraph.DFSearch("ןÿעü");
            Assert.AreEqual(expected, received);
        }


        [TestMethod]
        public void TestDFSerch4()
        {
            int expected = -1;
            int received = myGraph.DFSearch("אבגדה");
            Assert.AreEqual(expected, received);
        }




    }
}
