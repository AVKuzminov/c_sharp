using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace List
{
    class Program
    {
        const int Max = 129;

        static void Main(string[] args)

        {
            List<int> l = new List<int> { 10, 20 }; // минимально резервирует 4 элемента

            l.Add(30); 
            l.Add(40);
            l.Add(50); // вот здесь добавил 4 ячейки и дописал в 5ю "50"

            l.Insert(1, 80); // добавил во 2ю (так как с 0 начинается) и справа которые сдвинулись
            l.RemoveAt(2); // удалил 3й и все что справа сдвинулись влево
			List<int> list = new List<int>(/*Here we can set the initial capacity*/);

            for (int i = 0; i < Max; i++)
            {
                list.Add(i);
                Console.WriteLine("Count = {0}, Capacity = {1}", list.Count, list.Capacity);
            }

			Console.WriteLine("Removing elements:");

			while (list.Count > 0)
			{
				list.RemoveAt(list.Count - 1);
				Console.WriteLine("Count = {0}, Capacity = {1}", list.Count, list.Capacity);
			}

            Console.ReadKey();
        }
    }
}
