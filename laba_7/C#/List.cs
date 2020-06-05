using System;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.Diagnostics.Tracing;
using System.Text;
using System.Transactions;

namespace laba7
{
    class List
    {
        public Node head;
        public class Node
        {
            public char data;
            public Node next;
            public Node(char data)
            {
                this.data = data;
                next = null;
            }
        }
        public void CreateNode(char value)
        {
            head = new Node(value);
        }

        public void AddLast(char value)
        {
            if (head == null)
            {
                CreateNode(value);
                return;
            }

            var current = head;

            while (current.next != null)
            {
                current = current.next;
            }

            current.next = new Node(value);
        }
        public void Print()
        {
            var current = head;
            while (current!=null)
            {
                Console.WriteLine(current.data);
                current = current.next;
            }
        }
        public int CountAsterisk()
        {
            int counter = 0;
            if(head != null)
            {
                var current = head.next;
                while (current != null)
                {
                    if (current.data == '*') ++counter;
                    if (current.next == null) break;
                    current = current.next;
                }
            }
            return counter;
        }
        public void Remove()
        {
            var current = head;
            while(current!=null)
            {
                if(current.data == '#')
                {
                    current.next = null;
                    break;
                }
                current = current.next;
            }
            Console.WriteLine("Cleaning succesfully done!");
        }
    }
}
