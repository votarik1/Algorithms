using System;
using System.Collections.Generic;
using System.Text;

namespace HW2
{
    interface ILinkedList
    {
        public int GetCount();
        public void AddNode(int value);
        public void AddNodeAfter(Node node, int value);
        public void RemoveNode(int index);
        public void RemoveNode(Node node);
        public Node FindNode(int searchValue); 

    }
}
