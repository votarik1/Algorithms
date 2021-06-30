using System;

namespace HW4
{
   public class Tree
    {
        public TreeNode Root { get; private set; }
        public int Count { get; private set; }
        public TreeNode Search(int value)
        {
            var activeNode = Root;
            while (activeNode.Data != value)
            {
                if (value < activeNode.Data)
                {
                    if (activeNode.Left != null)
                    {
                        activeNode = activeNode.Left;
                        continue;
                    }
                    return null;
                }
                if (value > activeNode.Data)
                {
                    if (activeNode.Right != null)
                    {
                        activeNode = activeNode.Right;
                        continue;
                    }
                    return null;
                }
            }
            return activeNode;
        }
        public TreeNode Add(int value)
        {
            if (Root == null)
            {
                Root = new TreeNode(value);
                Count = 1;
                return Root;

            }
            TreeNode activeNode = Root;
            while (true)
            {
                if (value == activeNode.Data)
                {
                    throw new Exception("Элемент уже существует");
                }

                if (value < activeNode.Data)
                {
                    if (activeNode.Left != null)
                    {
                        activeNode = activeNode.Left;
                        continue;
                    }
                    return IncertElementUnder(activeNode, value, true);
                }
                if (value > activeNode.Data)
                {
                    if (activeNode.Right != null)
                    {
                        activeNode = activeNode.Right;
                        continue;
                    }
                    return IncertElementUnder(activeNode, value, false);
                }


            }
        }
        public bool Remove(int value)
        {
            var activeNode = Search(value);
            return Remove(activeNode);
        }
        public bool Remove(TreeNode removeNode)
        {
            if (removeNode.Left == null && removeNode.Right == null)
            {
                RemoveLeaf(removeNode);
                return true;
            }
            if (removeNode.Left == null ^ removeNode.Right == null)
            {
                RemoveElementWithOneBranch(removeNode);
                return true;
            }
            if (removeNode.Left != null && removeNode.Right != null)
            {
                var activeNode = removeNode.Right;
                while (activeNode.Left != null)
                {
                    activeNode = activeNode.Left;
                }
                if (activeNode.Right == null)
                {
                    RemoveLeaf(activeNode);
                }
                else
                {
                    RemoveElementWithOneBranch(activeNode);
                }

                activeNode.Left = removeNode.Left;
                activeNode.Right = removeNode.Right;
                if (activeNode.Left!=null)
                {
                    activeNode.Left.Parent = activeNode;
                }
                if (activeNode.Right!= null)
                {
                    activeNode.Right.Parent = activeNode;
                }                
                if (removeNode != Root)
                {
                    activeNode.Parent = removeNode.Parent;
                    if (removeNode.Parent.Left == removeNode)
                    {
                        removeNode.Parent.Left = activeNode;
                    }
                    else
                    {
                        removeNode.Parent.Right = activeNode;
                    }
                }
                else
                {
                    Root = activeNode;
                    activeNode.Parent = null;
                }

                return true;
            }

            return false;

        }

        public void Print()
        {
            int depth = FindDepth(Root, 0);
            int startXpos = 2+depth;
            for (int i = 1; i <= depth; i++)
            {
                startXpos += 1 + (int)Math.Pow(2, i);
            }
            RecPrint(Root, depth, 0, startXpos, 2);
        }
        public int Depth()
        {
           return FindDepth(Root, 0);
        }

        private int FindDepth(TreeNode activeNode, int depth)
        {

            if (activeNode.Left != null && activeNode.Right != null)
            {
                int left = FindDepth(activeNode.Left, depth + 1);
                int right = FindDepth(activeNode.Right, depth + 1);
                if (left > right)
                {
                    return left;
                }
                else
                {
                    return right;
                }
            }
            else if (activeNode.Left == null && activeNode.Right == null)
            {
                return depth;
            }
            else
            {
                if (activeNode.Left != null)
                {
                    return FindDepth(activeNode.Left, depth + 1);
                }
                else
                {
                    return FindDepth(activeNode.Right, depth + 1);
                }
            }

        }

        private void RecPrint(TreeNode activeNode, int TotalDepth, int CurentDepth, int Xpos, int Ypos)
        {
            if (activeNode.Left == null && activeNode.Right == null)
            {
                Console.SetCursorPosition(Xpos, Ypos);
                Console.Write(activeNode.Data);
            }
            else
            {
                Console.SetCursorPosition(Xpos, Ypos);
                Console.Write(activeNode.Data);
                int Xcurrent;
                int Ycurrent;
                int lenthOfBranch = (int)Math.Pow(2,(TotalDepth - CurentDepth))-1;
                
                if (activeNode.Left != null)
                {

                    Xcurrent = Xpos;
                    Ycurrent = Ypos;
                    for (int i = 1; i <= lenthOfBranch; i++)
                    {
                        Xcurrent--;
                        Ycurrent++;
                        Console.SetCursorPosition(Xcurrent, Ycurrent);
                        Console.Write("*");
                    }
                    Xcurrent--;
                    Ycurrent++;
                    RecPrint(activeNode.Left, TotalDepth, CurentDepth + 1, Xcurrent, Ycurrent);
                }

                if (activeNode.Right != null)
                {

                    Xcurrent = Xpos;
                    Ycurrent = Ypos;
                    for (int i = 1; i <= lenthOfBranch; i++)
                    {
                        Xcurrent++;
                        Ycurrent++;
                        Console.SetCursorPosition(Xcurrent, Ycurrent);
                        Console.Write("*");
                    }
                    Xcurrent++;
                    Ycurrent++;
                    RecPrint(activeNode.Right, TotalDepth, CurentDepth + 1, Xcurrent, Ycurrent);


                }

            }

        }
        private TreeNode IncertElementUnder(TreeNode parent, int value, bool left)
        {
            var newNode = new TreeNode(value);
            newNode.Parent = parent;
            if (left)
            {
                parent.Left = newNode;
            }
            else
            {
                parent.Right = newNode;
            }
            Count++;
            return newNode;

        }

        private void RemoveLeaf(TreeNode leaf)
        {
            if (leaf == Root)
            {
                Root = null;
            }
            else
            {
                if (leaf.Parent.Left == leaf)
                {
                    leaf.Parent.Left = null;
                }
                if (leaf.Parent.Right == leaf)
                {
                    leaf.Parent.Right = null;
                }
            }

            Count--;
        }

        private void RemoveElementWithOneBranch(TreeNode element)
        {
            TreeNode child = new TreeNode();
            if (element.Left != null)
            {
                child = element.Left;
            }
            else
            {
                child = element.Right;
            }

            if (element != Root)
            {
                if (element.Parent.Left == element)
                {
                    element.Parent.Left = child;
                }
                else
                {
                    element.Parent.Right = child;
                }
                child.Parent = element.Parent;
            }
            else
            {
                Root = child;
                child.Parent = null;
            }
            Count--;

        }
    }
}
