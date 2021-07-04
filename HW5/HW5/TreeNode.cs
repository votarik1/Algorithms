using System;
using System.Collections.Generic;
using System.Text;

namespace HW5
{
   public class TreeNode<T>
    {
        public T Data { get; set; }
        public TreeNode<T> Parent { get; set; }
        public TreeNode<T> Left { get; set; }
        public TreeNode<T> Right { get; set; }
        public TreeNode()
        {

        }

        public TreeNode(T value)
        {
            Data = value;
        }
    }
}
