using System;

namespace CreationalFactories
{
    public enum CoordinateSystem
    {
        Cartesian,
        Polar
    }
    public class Point
    {
        private double x, y;
        // public Point(double a, double b, CoordinateSystem system = CoordinateSystem.Cartesian)
        // {
        //     switch(system)
        //     {
        //         case CoordinateSystem.Cartesian:
        //             x = a;
        //             y = b;
        //             break;
        //         case CoordinateSystem.Polar :
        //             x = a * Math.Cos(b);
        //             y = a * Math.Sin(b);
        //             break;
        //         default:
        //             throw new ArgumentOutOfRangeException(nameof(system));
        //     }
        // }
        // public static Point NewCartesianPoint(double x, double y) => new Point(x, y);

        // public static Point NewPolarPoint(double rho, double theta) => new Point(rho*Math.Cos(theta), rho*Math.Sin(theta));
        public Point(double x, double y)
        {
            this.x = x;
            this.y = y;
        }
        public override string ToString()
        {
            return string.Format("x => {0}, y => {1}", x, y);
        }
        public static class Factory
        {
            public static Point NewCartesianPoint(double x, double y) => new Point(x, y);

            public static Point NewPolarPoint(double rho, double theta) => new Point(rho * Math.Cos(theta), rho * Math.Sin(theta));
        }
    }
}