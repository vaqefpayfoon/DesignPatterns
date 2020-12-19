using System;

namespace open_close_principle
{
    class Program
    {
        static void Main(string[] args)
        {
            var apple = new Product("apple", Color.Green, Size.Small);
            var tree = new Product("Tree", Color.Green, Size.Large);
            var house = new Product("House", Color.Blue, Size.Large);

            Product[] products = {apple, tree, house};
            ProductFilter pf = new ProductFilter();
            foreach (var item in pf.FilterByColor(products, Color.Green))
            {
                Console.WriteLine($"{item.Name} - is green");
            }


            BetterFilter better = new BetterFilter();
            foreach (var item in better.Filter(products, new ColorSpecifiction(Color.Green)))
            {
                Console.WriteLine($"{item.Name} - is green");
            }

            foreach (var item in better.Filter(products, new AndSpecifiction<Product>(new ColorSpecifiction(Color.Blue), new SizeSpecifiction(Size.Large))))
            {
                Console.WriteLine($"{item.Name} - is blue and large size");
            }

        }
    }
}
