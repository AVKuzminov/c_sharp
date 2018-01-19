using System;

namespace Repository
{
	class Logger
	{
		public void Log(string message)
		{
			Console.WriteLine("{0}: {1}", DateTime.Now, message);
		}
	}
}
