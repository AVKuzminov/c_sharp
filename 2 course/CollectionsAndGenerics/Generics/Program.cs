using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Generics
{
	class Program
	{
		static int Sum(int[] array)
		{
			int sum = 0;
			foreach (var item in array)
				sum += item;
			return sum;
		}

		static T Sum<T>(T[] array)
		{
			T sum = default(T);
			foreach(var item in array)
			{
				// The following line is impossible for generic types
				// because we can't give any guarantee that T is an arithmetic type
				// sum += item;
			}
			return sum;
		}

		static void Main(string[] args)
		{
			var numbers = new int[] { 10, 40, 50 };
			var doubleNumbers = new double[] { 10.2, 50.6, 70.2 };
			
			Console.WriteLine("Sum = {0}", Sum(numbers));
			// Console.WriteLine("Sum = {0}", Sum(doubleNumbers));
		}
	}
}
