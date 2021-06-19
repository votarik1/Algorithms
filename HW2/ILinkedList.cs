using System;
using System.Collections.Generic;
using System.Text;

namespace HW2
{
    interface ILinkedList
    {
        public Node AddNode(int value);
        public Node AddNodeAfter(Node node, int value);
        public bool RemoveNode(int index);
        public bool RemoveNode(Node node);
        public Node FindNode(int searchValue); 

    }
}
