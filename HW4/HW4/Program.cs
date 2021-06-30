using System;
using System.Collections.Generic;
using BenchmarkDotNet.Attributes;
using BenchmarkDotNet.Running;


namespace HW4
{
    class Program
    {
        static void Main(string[] args)
        {
            //BenchmarkSwitcher.FromAssembly(typeof(Program).Assembly).Run(args);
            var myTree = new Tree();
            myTree.Add(6);
            myTree.Add(3);
            myTree.Add(7);
            myTree.Add(1);
            myTree.Remove(6);
            myTree.Add(9);
            myTree.Print();
            Console.ReadKey();            
        }       
    }
}
