using System;

namespace FluentBuilderInheritanceWithRecursiveGeneric
{
    internal class Program
    {
        class SomeBuilder : PersonBirthDateBuilder<SomeBuilder>
        {

        }

        public static void Main(string[] args)
        {
            var me = Person.New
              .Called("Dmitri")
              .WorksAsA("Quant")
              .Born(DateTime.UtcNow)
              .Build();
            Console.WriteLine(me);
        }
    }
}
