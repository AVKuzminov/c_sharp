using System;
using System.Collections.Generic;

namespace LinkedListNS
{
	// This is how an element of a linked list looks like
	class ListNode<T>
    {
        public T Data { get; set; }
        public ListNode<T> Next { get; set; }
        public ListNode<T> Prev { get; set; }
    }
    
    class Program
    {
        static void Main(string[] args)
        {
            var linkedList = new LinkedList<int>();
            linkedList.AddLast(20);
            linkedList.AddLast(30);
            linkedList.AddFirst(10);
            
            //int second = linkedList[1]; такого здсь нет

            var first = linkedList.First;

            //LinkedList<int> linkedList = new LinkedList<int>();


            ListNode<int> n1, n2, n3;

            n1 = new ListNode<int> { Data = 10 };
            n2 = new ListNode<int> { Data = 20 };
            n3 = new ListNode<int> { Data = 30 };

            // Connect elements together
            n1.Next = n2;
            n2.Next = n3;
            n2.Prev = n1;
            n3.Prev = n2;
            //In a real linked list only two references are stored: to the first and last elements

            //Now we can iterate over the list in the following way:
            ListNode<int> temp = n1;
            while (temp != null)
            {
                Console.WriteLine(temp.Data);
                temp = temp.Next;
            }

            Console.ReadKey();
        }
    }
}
