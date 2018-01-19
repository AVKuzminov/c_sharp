using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ObjectMembers
{
    class Program
    {
        static void Main(string[] args)
        {
            int a = 1, b = 1;

            Console.WriteLine("*****Equals method*****");
            Console.WriteLine(ReferenceEquals(a, b));
            Console.WriteLine(a.Equals(b));

            object objA = a;
            Console.WriteLine(ReferenceEquals(objA, a));
            Console.WriteLine(objA.Equals(a));

            object objACopy = objA;
            Console.WriteLine(ReferenceEquals(objA, objACopy));
            Console.WriteLine(objA.Equals(objACopy));


            Console.WriteLine("*****Operator == *****");
            object objB = b;
            Console.WriteLine(a == b);
            Console.WriteLine(objA == objB);
        }
    }
}
