using System;
using System.Collections.Generic;

namespace DelegateTasks
{
	class Program
    {
        static void Main(string[] args)
        {
            List<int> l = new List<int>() {10, -11, 20, 33, 62};

            // Example of using lambda expression in a standard List method
            int res = l.Find(i => i > 10);

            // Task 1. Call FindAll to return all even elements.
            // Implement two versions. One with a full method, one with a lambda expression
            // Look through the list declaration. What other functions accept delegate instances?
            
            // ***** Your code for task 1 goes here *****



            // Assigning lambda expression to a variable of anonymous delegate type
            Func<int, int, int> operation = (x, y) => x + y;

            res = operation(10, 20);

            // Task 2. Declare an array of 4 lambda expressions, each representing a mathematical
            // operation: +, -, *, /
            // Do a foreach loop and call these 4 operations on any two integer numbers


            // ***** Your code for task 2 goes here *****


            // Task 3. Define a function named "PrintNumbers" that accepts two parameters
            // 1 - List of ints
            // 2 - Predicate (function that accepts an int and returns either true or false)
            // The function should loop through the list and output only the values that satisfy the predicate
            
            // Make a call to this function, passing l as the first parameter and any filter as the second parameter (in
            // the form of a lambda expression

            // ***** Your code for task 3 goes here *****

            Console.ReadKey();
        }
    }
}
