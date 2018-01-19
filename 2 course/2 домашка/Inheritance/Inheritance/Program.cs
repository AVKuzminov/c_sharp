using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Polygons
{
    class Program
    {
        static void Main(string[] args)
        {
            Triangle t = new Triangle(20);
            Console.WriteLine(t.Area());

            RegularPolygon p = t;
            Console.WriteLine(p.Area());

            Square s = new Square(20);
            Console.WriteLine(s.Area());

            p = s;
            Console.WriteLine(p.Area());
            
        }
    }
}
