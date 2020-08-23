using System;
using System.Collections.Generic;
using System.Security.Cryptography;
using System.Text;
using System.Text.RegularExpressions;

namespace CTCI
{
    public class CTCILinkedList
    {
        public void AllLinkedList()
        {
            //1 - Remove Duplicate
            //RemoveDuplicate();

            //2 Return Kth to Last
           // KthtoLast();

            //3 Delete Given Node
            //copy content from next node and set the pointer to next to next ///simple enough
        }

        public class Node
        {
            public Node next = null;
            public  int data; 

            public Node(int d)
            {
                data = d;
            }
        }

        //1 Remove duplicate node from linked list
        // 1 -> 5 -> 8 -> 10 -> 5          
        // 2 -> 5 -> 8 -> 10 -> 1 -> 8 -> 12

        //Questions
        /*
         * 1. Can we assume there is only one duplicate node
         * 2. linked list may or many not be empty
        */
        //Space complextity O(n) ime O(n)
        public void RemoveDuplicate(Node n)
        {
            HashSet<int> set = new HashSet<int>();
            Node previousNode = null;
            while (n != null)
            {
                if(set.Contains(n.data))
                {
                    previousNode.next = n.next;
                }
                else
                {
                    set.Add(n.data);
                    previousNode = n;
                }
                n = n.next;
            }

        }
        // 1 -> 5 -> 8 -> 10 -> 5   
        // current : 1 
        //           5 
        // runner :  1  5  8  10 5
        //           5 8 10 null 
                    
        //Space complextity O(1) ime O(n2)
        public void RemoveDuplicateNoBuffer(Node head)
        {
            Node current = head;
            while (current != null)
            {
                Node runner = current;
                while (runner.next != null)
                {
                    if(current.data == runner.next.data)
                    {
                        runner.next = runner.next.next;
                    }
                    runner = runner.next;
                }
                current = current.next;
            }
        }

        //2 Return Kth to Last element 
        /* check if the K is with in the range 
         * if head is null then return null 
         * use two pointers one at the bigining and second at the no of k node from starting 
         * 
         * Time Complexity : O(n)
         * Space complexity : o(1)
         */

        public LinkedListNode<int> KthtoLast(LinkedListNode<int> head, int k )
        {
            if (head == null) return null;
            LinkedListNode<int> p1 = head;
            LinkedListNode<int> p2 = head;

            for (int i=0; i<k;i++)
            {
                if (p1 == null) return null; //Index out of bound
                else p1 = p1.Next;
            }

            while (p1! == null)
            {
                p1 = p1.Next;
                p2 = p2.Next;
            }

            return p2;

        }
    }


}
