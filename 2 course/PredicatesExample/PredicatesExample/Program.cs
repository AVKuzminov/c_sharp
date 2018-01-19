using System;
using System.Collections.Generic;
using System.Linq;

namespace ConsoleApplication1
{
    public delegate int MyDelegate(int a, int b);
    class Program
    {
        public static Action<int, int> del;
        static void Main(string[] args)
        {
            var p1 = new Person { Name = "Vasya", Age = 51 };
            var p2 = new Person { Name = "Vasya1", Age = 40 };
            var p3 = new Person { Name = "Vasya2", Age = 67 };
            var p4 = new Person { Name = "Vasya3", Age = 20 };

            var list = new List<Person> { p1, p2, p3, p4 };

            var machine = new Machine();
            machine.OnFiltered += l => Console.WriteLine(l.Count);
            machine.Filter(list, p => p.Age > 50);
        }
    }

    public class Machine
    {
        public event Action<List<Person>> OnFiltered;
        public void Filter(List<Person> persons, Predicate<Person> predicate)
        {
            var filteredCollection = new List<Person>();
            foreach (var p in persons)
            {
                var result = predicate(p);
                if (result)
                {
                    filteredCollection.Add(p);
                }
            }

            if (OnFiltered != null)
            {
                OnFiltered(filteredCollection);
            }
        }
    }

    public class Person
    {
        public string Name { get; set; }

        public int Age { get; set; }
    }
}