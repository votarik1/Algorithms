using System;
using System.Collections.Generic;
using System.Text;

namespace HW2
{
    public class LinkedList:ILinkedList
    {

        public Node StartNode { get; set; }
        public Node LastNode { get; set; }
        public int Count { get; set; } //O(1)
        public Node AddNode(int value)
        {      
            Node NewNode = new Node();
            NewNode.value = value;
            LastNode.NextNode = NewNode;
            NewNode.PrevNode = LastNode;
            LastNode = NewNode;
            Count++;
            return LastNode;
        } //O(1)

        public Node AddNodeAfter(Node node, int value)
        {

            Node NewNode = new Node();
            NewNode.value = value;
            NewNode.PrevNode = node;
            NewNode.NextNode = node.NextNode;
            node.NextNode = NewNode;
            if (NewNode.NextNode==null)
            {
                LastNode = NewNode;
            }
            else
            {
                NewNode.NextNode.PrevNode = NewNode;
            }           
            Count++;
            return NewNode;
        }//O(1)

        public Node FindNode(int searchValue)
        {
            Node ActiveNode = StartNode;
            while (ActiveNode.value != searchValue)
            {
                if (ActiveNode.NextNode == null)
                {
                    return null;
                }
                ActiveNode = ActiveNode.NextNode;
            }
            return ActiveNode;
        }//O(n)

        public bool RemoveNode(int index)
        {
            Node ActiveNode = StartNode;
            if (index < 0)
            {
                return false;
            }

           
            for (int i = 0; i < index; i++)
            {
                if (ActiveNode.NextNode == null)
                {
                    return false;
                }
                ActiveNode = ActiveNode.NextNode;
            }
            RemoveNode(ActiveNode);
            Count--;
            return true;
        }
        //O(n)
        public bool RemoveNode(Node node)
        {
            if (node.PrevNode == null)
            {
                StartNode = node.NextNode;
            }
            else
            {
                node.PrevNode.NextNode = node.NextNode;
            }
            if (node.NextNode == null)
            {
                LastNode = node.PrevNode;
            }
            else
            {
                node.NextNode.PrevNode = node.PrevNode;
            }
            Count--;
            return true;
        }
        //O(1)


    }
}
