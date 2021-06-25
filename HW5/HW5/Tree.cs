using System;
using System.Collections.Generic;
using System.Text;

namespace HW5
{
    public class Tree<T>
    {
        public TreeNode<T> Root { get; set; }
        public int Count { get; set; }

        public TreeNode<T> Add(T value)
        {

            if (Root == null)
            {
                Root = new TreeNode<T>(value);
                Count = 1;
                return Root;
            }

            int counter = Count + 1;
            var activeNode = Root;
            while (counter != 1)
            {
                if (counter == (counter / 2) * 2)
                {
                    if (activeNode.Left == null)
                    {
                        var newTreeNode = new TreeNode<T>(value);
                        activeNode.Left = newTreeNode;
                        newTreeNode.Parent = activeNode;
                        Count++;
                        return newTreeNode;
                    }

                    activeNode = activeNode.Left;

                }
                else
                {
                    if (activeNode.Right == null)
                    {
                        var newTreeNode = new TreeNode<T>(value);
                        activeNode.Right = newTreeNode;
                        newTreeNode.Parent = activeNode;
                        Count++;
                        return newTreeNode;
                    }
                    activeNode = activeNode.Right;

                }
                counter = counter / 2;
            }
            return null;





        }


        public TreeNode<T> BFSSearch(T value)
        {
            var myQueue = new Queue<TreeNode<T>>();
            var activeNode = new TreeNode<T>();
            myQueue.Enqueue(Root);
            
            while (myQueue.Count!=0)
            {
                 
                activeNode = myQueue.Dequeue();
                Console.WriteLine($"Удален элемент {activeNode.Data}");
                if (activeNode.Data.Equals(value))
                {
                    Console.WriteLine($"Найден элемент {activeNode.Data}");
                    return activeNode;
                }
                if (activeNode.Left!=null)
                {
                    myQueue.Enqueue(activeNode.Left);
                    Console.WriteLine($"Добавлен элемент {activeNode.Left.Data}");
                }
                if (activeNode.Right != null)
                {
                    myQueue.Enqueue(activeNode.Right);
                    Console.WriteLine($"Добавлен элемент {activeNode.Right.Data}");
                }
            }

            Console.WriteLine("Элемент со значением {T} не найден");
            return null;
        }

        public TreeNode<T> DFSSearch(T value)
        {
            var myStack = new Stack<TreeNode<T>>();
            var activeNode = new TreeNode<T>();
            myStack.Push(Root);

            while (myStack.Count != 0)
            {

                activeNode = myStack.Pop();
                Console.WriteLine($"Удален элемент {activeNode.Data}");
                if (activeNode.Data.Equals(value))
                {
                    Console.WriteLine($"Найден элемент {activeNode.Data}");
                    return activeNode;
                }
                if (activeNode.Left != null)
                {
                    myStack.Push(activeNode.Left);
                    Console.WriteLine($"Добавлен элемент {activeNode.Left.Data}");
                }
                if (activeNode.Right != null)
                {
                    myStack.Push(activeNode.Right);
                    Console.WriteLine($"Добавлен элемент {activeNode.Right.Data}");
                }
            }

            Console.WriteLine("Элемент со значением {T} не найден");
            return null;
        }



        public void PrintTop4() // метод для визуализации структуры дерева
        {


            Console.SetCursorPosition(0, 2);
            Console.WriteLine("                                   ( )");
            Console.WriteLine("                                  /   \\");
            Console.WriteLine("                ------------------     ------------------");
            Console.WriteLine("                |                                       |");
            Console.WriteLine("                |                                       |");
            Console.WriteLine("                |                                       |");
            Console.WriteLine("                |                                       |");
            Console.WriteLine("                |                                       |");
            Console.WriteLine("               ( )                                     ( )");
            Console.WriteLine("              /   \\                                   /   \\");
            Console.WriteLine("             /     \\                                 /     \\");
            Console.WriteLine("            /       \\                               /       \\");
            Console.WriteLine("           /         \\                             /         \\");
            Console.WriteLine("         ( )         ( )                         ( )         ( )");
            Console.WriteLine("        /   \\       /   \\                       /   \\       /   \\");
            Console.WriteLine("      ( )   (  )  ( )   (  )                  ( )   (  )  (  )  (  )");

            if (Root != null)
            {
                Console.SetCursorPosition(36, 2);
                Console.Write(Root.Data);
                if (Root.Left != null)
                {
                    Console.SetCursorPosition(16, 10);
                    Console.WriteLine(Root.Left.Data);
                    if (Root.Left.Left != null)
                    {
                        Console.SetCursorPosition(10, 15);
                        Console.WriteLine(Root.Left.Left.Data);
                        if (Root.Left.Left.Left != null)
                        {
                            Console.SetCursorPosition(7, 17);
                            Console.WriteLine(Root.Left.Left.Left.Data);
                        }
                        if (Root.Left.Left.Right != null)
                        {
                            Console.SetCursorPosition(13, 17);
                            Console.WriteLine(Root.Left.Left.Right.Data);
                        }

                    }
                    if (Root.Left.Right != null)
                    {
                        Console.SetCursorPosition(22, 15);
                        Console.WriteLine(Root.Left.Right.Data);
                        if (Root.Left.Right.Left != null)
                        {
                            Console.SetCursorPosition(19, 17);
                            Console.WriteLine(Root.Left.Right.Left.Data);
                        }
                        if (Root.Left.Right.Right != null)
                        {
                            Console.SetCursorPosition(25, 17);
                            Console.WriteLine(Root.Left.Right.Right.Data);
                        }

                    }

                }
                if (Root.Right != null)
                {

                    Console.SetCursorPosition(56, 10);
                    Console.WriteLine(Root.Right.Data);
                    if (Root.Right.Left != null)
                    {
                        Console.SetCursorPosition(50, 15);
                        Console.WriteLine(Root.Right.Left.Data);
                        if (Root.Right.Left.Left != null)
                        {
                            Console.SetCursorPosition(47, 17);
                            Console.WriteLine(Root.Right.Left.Left.Data);
                        }
                        if (Root.Right.Left.Right != null)
                        {
                            Console.SetCursorPosition(53, 17);
                            Console.WriteLine(Root.Right.Left.Right.Data);
                        }

                    }
                    if (Root.Right.Right != null)
                    {
                        Console.SetCursorPosition(62, 15);
                        Console.WriteLine(Root.Right.Right.Data);
                        if (Root.Right.Right.Left != null)
                        {
                            Console.SetCursorPosition(59, 17);
                            Console.WriteLine(Root.Right.Right.Left.Data);
                        }
                        if (Root.Right.Right.Right != null)
                        {
                            Console.SetCursorPosition(65, 17);
                            Console.WriteLine(Root.Right.Right.Right.Data);
                        }

                    }




                }

            }




        } 

    }
}
