using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QueueAndStack
{
    class Program
    {
        static void Main(string[] args)
        {
            Queue<int> queue = new Queue<int>();
            queue.Enqueue(10);
            queue.Enqueue(20);
            queue.Enqueue(30);
            Console.WriteLine("Queue:");
            while (queue.Count > 0)
                Console.WriteLine(queue.Dequeue());
            Console.WriteLine();


            var stack = new Stack<int>();
            stack.Push(10);
            stack.Push(20);
            stack.Push(30);
            Console.WriteLine("Stack:");
            while (stack.Count > 0)
                Console.WriteLine(stack.Pop());

            Console.ReadKey();
        }
    }
}
