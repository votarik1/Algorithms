using System;
using System.Collections.Generic;
using System.Text;

namespace HW4
{
    public class TreeNode
    {
        public int Data { get; set; }
        public TreeNode Parent { get; set; }
        public TreeNode Left { get; set; }
        public TreeNode Right { get; set; }

        public TreeNode()
        {

        }

        public TreeNode(int value)
        {
            Data = value;
        }

    }
}
