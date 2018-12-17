using ExMath.Coordinate;
using ExMath.Geometry;
using System;

namespace ExMath
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hello World!");
            Line3 line3 = new Line3(Vector3.zero, new Vector3(1, 1, 0));

            Console.WriteLine(line3);
            var pos = Line3.ClosestPoint(line3, new Vector3(-1, 1));
            Console.WriteLine(pos);
        }
    }
}
