using System;

namespace FacetedBuilder
{
    class Program
    {
        static void Main(string[] args)
        {
            var pb = new PersonBuilder();
            Person person = pb.Lives.At("hafte tir kheradmand").In("Tehran").WithPostCode("124")
            .works.At("behsa").AsA("dev").Earning(10000);
            Console.WriteLine(person);
        }
    }
}
