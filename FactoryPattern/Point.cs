using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FactoryPattern
{
    
    public class Point
    {
        private double x, y;
        // Constructor
        public Point(double x, double y)
        {
            this.x = x;
            this.y = y;
        }
        public override string ToString()
        {
            return $"{nameof(x)}: {x}, {nameof(y)}: {y}";
        }
        public class Factory
        {
            public static Point NewCartesianPoint(double x, double y)
            {
                return new Point(x, y);
            }

            public static Point NewPolarPoint(double rho, double theta)
            {
                return new Point(rho * Math.Cos(theta), rho * Math.Sin(theta));
            }
        }
    }

    public class Demo
    {
        static void Main(string[] args)
        {
            var pointCartesian = Point.Factory.NewCartesianPoint(2.0, 3.0);
            var pointPolar = Point.Factory.NewPolarPoint(1.0, Math.PI / 2);
            Console.WriteLine(pointPolar);
        }
    }

}
