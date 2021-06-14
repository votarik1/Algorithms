using System;
using System.Collections.Generic;
using System.Text;



namespace HW2
{
    public class Node:ILinkedList
    { 
        public int value { get; set; }
        public Node NextNode { get; set; }
        public Node PrevNode { get; set; }

       public void AddNode(int value)
        {
            Node ActiveNode = this;
            while (ActiveNode.NextNode != null)
            {
                ActiveNode = ActiveNode.NextNode;
            }
            Node NewNode = new Node();
            NewNode.value = value;
            NewNode.PrevNode = ActiveNode;
            ActiveNode.NextNode = NewNode;
        } //O(n)

        public void AddNodeAfter(Node node, int value)
        {
            
            Node NewNode = new Node();
            NewNode.value = value;
            NewNode.PrevNode = node;
            NewNode.NextNode = node.NextNode;
            node.NextNode = NewNode;

        }//O(1)

        public Node FindNode(int searchValue)
        {
            Node ActiveNode = this;
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

        public int GetCount()
        {
            int amount = 1;
            Node ActiveNode = this;
            while (ActiveNode.NextNode != null)
            {
                ActiveNode = ActiveNode.NextNode;
                amount++;
            }
            return amount;
        }
        //O(n)

        public void RemoveNode(int index)
        {
            Node ActiveNode = this;
            if (index < 0)
            {
                throw new Exception("Указан отрицательный номер элемента списка");
            }

            if (index == 0)
            {
                ActiveNode = null;
                return;
            }           
            for (int i = 1; i < index-1; i++)
            {
                if (ActiveNode.NextNode==null)
                {
                    throw new Exception("Указанный индекс больше размера списка");
                }
                ActiveNode = ActiveNode.NextNode;
            }
            ActiveNode.NextNode = ActiveNode.NextNode.NextNode;
            if (ActiveNode.NextNode!=null)
            {
                ActiveNode.NextNode.PrevNode = ActiveNode;
            }
            
        }
        //O(n)
        public void RemoveNode(Node node)
        {
            if (node.NextNode != null)
            {
                node.NextNode.PrevNode = node.PrevNode;
            }
            if (node.PrevNode!= null)
            {
                node.PrevNode.NextNode = node.NextNode;
            }

        }
        //O(1)
    }
}
