using System;

namespace HW5
{
    class Program
    {
        static void Main(string[] args)
        {

            Tree<int> myTree = new Tree<int>();
            for (int i = 0; i < 15; i++)
            {
                myTree.Add(i);
            }

            myTree.PrintTop4();





            myTree.BFSSearch(14);

            Console.WriteLine();

            myTree.DFSSearch(14);
            Console.ReadKey();




        }
    }
}
