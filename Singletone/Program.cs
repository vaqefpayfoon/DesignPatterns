using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using NUnit.Framework;

namespace singletone
{
    public interface IDatabase
    {
        int Getlength(int arrayNum);
    }
    public class SingletoneDatabase : IDatabase
    {
        public SingletoneDatabase()
        {
            Console.WriteLine("initialize database");
            strs = File.ReadAllLines("capital.txt");
        }
        public int Getlength(int arrayNum)
        {
            string str = strs[arrayNum];
            return str.Length;
        }
        private string[] strs;
        private static Lazy<SingletoneDatabase> instance = new Lazy<SingletoneDatabase>(() => new SingletoneDatabase());
        public static SingletoneDatabase Instance => instance.Value;
        
    }
    public class SingletoneRecordFinder
    {
        public int GetTotalLength(IEnumerable<string> names)
        {
            int result = 0;
            result = names.Sum(woak => woak.Length);
            return result;
        }
    }
    public class ConfigurableRecordFinder
    {
        private IDatabase database;
        public ConfigurableRecordFinder(IDatabase database)
        {
            this.database = database;
        }
        public int GetTotalLength(IEnumerable<string> names)
        {
            int result = 0;
            result = names.Sum(woak => woak.Length);
            return result;
        }
    }
    public class DummyDatabase : IDatabase
    {
        public int Getlength(int arrayNum)
        {
            string[] strs = {"woak", "With Me", "to the end of life"};
            return strs[arrayNum].Length;
        }
    }
    [TestFixture]
    public class SingletoneTest
    {
        [Test]
        public void IsSingleToneTest()
        {
            var db = SingletoneDatabase.Instance;
            var db2 = SingletoneDatabase.Instance;
            Assert.That(db, Is.SameAs(db2));
            
        }
        [Test]
        public void SingletoneTotalPopulationTest()
        {
            var rf = new SingletoneRecordFinder();
            string[] strs = {"woak", "With Me", "to the end of life"};
            int result = rf.GetTotalLength(strs);
            Assert.True(result > 20);
        }
        [Test]
        public void ConfigurablePopulationTest()
        {
            var rf = new SingletoneRecordFinder();
            string[] strs = {"woak", "With Me", "to the end of life"};
            int result = rf.GetTotalLength(strs);
            Assert.True(result > 20);
        }
    }
    class Program
    {
        static void Main(string[] args)
        {
            var db = new SingletoneDatabase();
            Console.WriteLine(db.Getlength(2));
        }
    }
}
