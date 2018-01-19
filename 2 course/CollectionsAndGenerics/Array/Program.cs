using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ArrayNS
{
    class Program
    {
        static void Main(string[] args)
        {
			Console.WriteLine("The Array program does not print anything to console. Use debug mode");
			int[] numbers = { 40, 6, 7 };

            // When creating an array like follows, its elements are automatically initialized
            // to default value of the stored type (for int = 0)
            int[] copy = new int[5];

            Array.Sort(numbers);

            Array.Resize(ref numbers, 10);

            Array.Copy(numbers, 2, copy, 1, 4);
            // The following causes an exception
            try
            {
                Array.Copy(numbers, 2, copy, 1, 5);
            }
            catch { }

            Array.Reverse(copy);

            Console.ReadKey();
        }
    }
}
