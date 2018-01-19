using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MusicExample.Data;

namespace MusicExample.UI
{
    class Program
    {
        static void Main(string[] args)
        {
            using (var c = new Context())
            {
                //c.Database.Log += Console.WriteLine;
                var artists = c.Artists.ToList();
                foreach (var item in c.Songs)
                {
                    Console.WriteLine(string.Format("{0} {1} {2}", item.Id, item.Name, item.Duratioon));
                }
                Console.ReadKey();
            }
        }
    }
}
