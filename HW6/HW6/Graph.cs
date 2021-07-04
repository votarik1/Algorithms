using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HW6
{
   public class Graph
    {
        public int[,] AdjacencyMatrix { get; set; } //матрица смежности
        public string[] Data { get; set; } // матрица значений графа

        public Graph(int elements)
        {
            AdjacencyMatrix = new int[elements, elements];
            Data = new string[elements];
        }


        public int BFSearch(string searchString)
        {
            var wasViewed = new bool[AdjacencyMatrix.GetLength(0)]; // матрица просмотренных значений
            var MyQueue = new Queue<int>();
            MyQueue.Enqueue(0);
            wasViewed[0] = true;
            while (MyQueue.Count!=0)
            {
                
                int currentNode = MyQueue.Dequeue();
                Console.WriteLine($"Пройден {currentNode} элемент со значением {Data[currentNode]}");
                if (Data[currentNode] == searchString)
                {
                    Console.WriteLine($"Найдено значение {searchString} в позиции {currentNode}");
                    return currentNode;
                }
                for (int i = 0; i < AdjacencyMatrix.GetLength(1); i++)
                {
                    if (AdjacencyMatrix[currentNode,i]!=0 && !wasViewed[i])
                    {
                        MyQueue.Enqueue(i);
                        wasViewed[i] = true;
                    }
                }
            }
            Console.WriteLine("Искомое значение не найдено");
            return -1;
        }


        public int DFSearch(string searchString)
        {
            var wasViewed = new bool[AdjacencyMatrix.GetLength(0)]; // матрица просмотренных значений
            var MyStack = new Stack<int>();
            MyStack.Push(0);
            wasViewed[0] = true;
            while (MyStack.Count != 0)
            {

                int currentNode = MyStack.Pop();
                Console.WriteLine($"Пройден {currentNode} элемент со значением {Data[currentNode]}");
                if (Data[currentNode] == searchString)
                {
                    Console.WriteLine($"Найдено значение {searchString} в позиции {currentNode}");
                    return currentNode;
                }
                for (int i = 0; i < AdjacencyMatrix.GetLength(1); i++)
                {
                    if (AdjacencyMatrix[currentNode, i] != 0 && !wasViewed[i])
                    {
                        MyStack.Push(i);
                        wasViewed[i] = true;
                    }
                }
            }
            Console.WriteLine("Искомое значение не найдено");
            return -1;
        }

    }
}
