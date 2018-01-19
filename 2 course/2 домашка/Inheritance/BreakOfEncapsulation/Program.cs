using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BreakOfEncapsulation
{
	class Program
	{
		static void Main(string[] args)
		{
			var repo = new FileRepository("data.txt");
		}
	}
}
