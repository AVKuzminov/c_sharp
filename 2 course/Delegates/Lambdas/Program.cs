using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lambdas
{
    class Program
    {
        static bool IsEven(int num)
        {
            return num % 2 == 0;
        }

        static void Main(string[] args)
        {
            var list = new List<int>() { 4, 7, 80, 105, 204 };
            // Without a lambda - specify a separate method
            var evenNumbers = list.FindAll(IsEven);
            // Using a lambda expression
            evenNumbers = list.FindAll(num => num % 2 == 0);
        }
    }
}
