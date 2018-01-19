using System;

namespace Polygons
{
	interface IRegularPolygon
    {
        int NumberOfSides { get; }
        double SideLength { get; set; }

        double Perimeter();
        double Area();
    }
    
    abstract class RegularPolygon : IRegularPolygon
    {
        public int NumberOfSides { get; private set; }
        public double SideLength { get; set; }

        public double Perimeter()
        {
            return NumberOfSides * SideLength;
        }

        public virtual double Area()
        {
            throw new NotImplementedException();
        }

        public RegularPolygon(int numberOfSides, double sideLength)
        {
            NumberOfSides = numberOfSides;
            SideLength = sideLength;
        }
    }

    class Triangle : RegularPolygon
    {
        public Triangle(double sideLength)
            : base(3, sideLength)
        {

        }

        public override double Area()
        {
            return Math.Sqrt(3) / 4 * SideLength * SideLength;
        }
    }

    class Square : RegularPolygon
    {
        public Square(double sideLength)
            : base(4, sideLength)
        {

        }

        public override double Area()
        {
            return SideLength * SideLength;
        }
    }

}
