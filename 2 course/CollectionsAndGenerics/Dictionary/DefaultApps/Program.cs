using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace DefaultApps
{
    class Program
    {
        static void Main(string[] args)
        {
            Dictionary<string, string> defaultApps = new Dictionary<string, string>();
            // Adding a new key-value pair
            defaultApps["txt"] = "Notepad";
            defaultApps["cs"] = "Visual Studio 2013";
            defaultApps["cs"] = "Visual Studio 2015";

            // Another way to add item
            defaultApps.Add("docx", "Word 2016");

            Console.WriteLine("Registered apps");
            // Iterating over a dictionary
            foreach (var item in defaultApps)
                Console.WriteLine("{0}: {1}", item.Key, item.Value);

            Console.WriteLine("Enter file extension (without .)");

            string ext = Console.ReadLine();
            string app;
            if (defaultApps.TryGetValue(ext, out app))
                Console.WriteLine("Default app for *.{0} is {1}", ext, app);
            else
                Console.WriteLine("No default app found");
            Console.ReadKey();
        }
    }
}