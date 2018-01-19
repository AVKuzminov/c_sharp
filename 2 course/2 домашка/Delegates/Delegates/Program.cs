using System;
using System.IO;

namespace Delegates
{
    public delegate void LogMessageCallback(string Message);

    public class DataProcessor
    {
        public event LogMessageCallback LogMessage;

        public void NoDelegate()
        {
            Console.WriteLine("Starting calculation");
            // ... Calculations go here ...
            Console.WriteLine("Calculation done");
        }

        public void WithDelegate()
        {
            LogMessage("Starting calculation");
            // ... Calculations go here ...
            LogMessage("Calculation done");
        }
    }

    class Program
    {
        static StreamWriter sw = new StreamWriter("output.txt", true);

        static void WriteToConsole(string Message)
        {
            Console.WriteLine(Message);
        }

        static void WriteToFile(string Message)
        {
            sw.WriteLine(Message); 
            sw.Flush();
        }

        static void Main(string[] args)
        {
            DataProcessor dp = new DataProcessor();
            dp.LogMessage += new LogMessageCallback(WriteToConsole);
			dp.LogMessage += WriteToFile;

            dp.WithDelegate();			

            Console.ReadKey();
        }
    }
}