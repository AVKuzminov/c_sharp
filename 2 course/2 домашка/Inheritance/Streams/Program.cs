using System.IO;

namespace Streams
{
	class Program
    {   
        static void Print(Stream stream)
        {
            StreamWriter sw = new StreamWriter(stream);
            sw.Write("Hello world!");
            sw.Flush();
        }

        static void Main(string[] args)
        {
            using (FileStream fs = new FileStream("example.txt", FileMode.Create))
            {
                Print(fs);
            }
            
            var ms = new MemoryStream();
            Print(ms);
        }
    }
}
