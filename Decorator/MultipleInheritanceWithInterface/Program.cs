using System;

namespace MultipleInheritanceWithInterface
{
    public interface IBird
    {
        void Fly();
        int Weight { get; set; }
    }
    public class Bird : IBird
    {
        public int Weight { get; set; }
        public void Fly()
        {
            Console.WriteLine("flying in to sky");
        }
    }
    public interface ILizard
    {
        void Crawl();
        int Weight { get; set; }
    }
    public class Lizard : ILizard
    {
        public int Weight { get; set; }
        public void Crawl()
        {
            Console.WriteLine("Crawling in to dirt");
        }   
    }
    public class Dragon : IBird, ILizard
    {
        private Bird bird = new Bird();
        private Lizard lizard = new Lizard();
        public void Crawl()
        {
            bird.Fly();
        }

        public void Fly()
        {
            lizard.Crawl();
        }
        public int Weight { get; set; }
    }
    
    class Program
    {
        static void Main(string[] args)
        {
            var d = new Dragon();
            d.Fly();
            d.Crawl();
            d.Weight = 12;
        }
    }
}
