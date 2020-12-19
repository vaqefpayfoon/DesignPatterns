using System;

namespace LiskovSubstitution
{
    class Program
    {
        static public int Area(Rectangle r) => r.Width * r.Height;
        static void Main(string[] args)
        {

            Rectangle rc = new Rectangle(2,3);
            Console.WriteLine($"{rc} has area {Area(rc)}");

            Square sq = new Square();
            sq.Width = 4;
            Console.WriteLine($"{sq} has area {Area(sq)}");

            Rectangle sq_Inherite = new Square();
            sq_Inherite.Width = 4;
            Console.WriteLine($"{sq_Inherite} has area {Area(sq_Inherite)}");
        }
    }
}
