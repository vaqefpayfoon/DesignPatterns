using System;
using System.Diagnostics;

namespace solid
{
    class Program
    {
        static void Main(string[] args)
        {
            var journal = new Journal();
            
            int result = journal.AddEntry("i cried today");
            result = journal.AddEntry("i ate a bug");

            Console.WriteLine(journal);
            Console.WriteLine(result);

            var persistence = new Persistence();
            var filename = @"C:\CSharp\Dependency.Injection\solid\journal.txt";            
            persistence.SaveToFile(journal, filename, true);
            Process.Start(filename);

        }
    }
}
