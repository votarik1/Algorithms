using System;

namespace HW6
{
    class Program
    {
        static void Main(string[] args)
        {
            var myGraph = new Graph(9); // граф из методички стр 7.
            
            myGraph.Data[0] = "ноль";
            myGraph.Data[1] = "один";
            myGraph.Data[2] = "два";
            myGraph.Data[3] = "три";
            myGraph.Data[4] = "четыре";
            myGraph.Data[5] = "пять";
            myGraph.Data[6] = "шесть";
            myGraph.Data[7] = "семь";
            myGraph.Data[8] = "восемь";

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

            myGraph.BFSearch("восемь");

            myGraph.DFSearch("один");



        }
    }
}
