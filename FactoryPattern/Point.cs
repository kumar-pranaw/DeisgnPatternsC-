using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FactoryPattern
{
    public enum CoordinateSystem
    {
        Cartesian,
        Polar
    }
    class Point
    {
        private double x, y;
        /// <summary>
        /// Initializes a point from Either cartesian or polar
        /// </summary>
        /// <param name="a"> x if Cartesian rho if polar</param>
        /// <param name="b"></param>
        /// <param name="system"></param>
        public Point(double a, double b, CoordinateSystem system = CoordinateSystem.Cartesian)
        {
            switch (system)
            {
                case CoordinateSystem.Cartesian:
                    x = a;
                    y = b;
                    break;
                case CoordinateSystem.Polar:
                    x = a * Math.Cos(b);
                    y = b * Math.Sin(b);
                    break;
                default:
                    break;
            }
        }
 
        static void Main(string[] args)
        {
        }
    }
}
