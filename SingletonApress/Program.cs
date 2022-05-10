using System;

namespace SingletoneApress
{
    internal class Program
    {
        static void Main(string[] args)
        {
            // Console.WriteLine("***Singleton Pattern Demonstration.***\n");
            // /* The following line is used to discuss
            // the drawback of the approach. */
            // //Console.WriteLine($"The value of MyInt is :{Singleton.MyInt}");
            // // Private Constructor.So, you cannot use the 'new' keyword.
            // //Singleton s = new Singleton(); // error
            // Console.WriteLine("Trying to get a Singleton instance, called firstInstance.");

            // Singleton firstInstance = Singleton.GetInstance;
            // Console.WriteLine("Trying to get another Singleton instance, called secondInstance.");

            // Singleton secondInstance = Singleton.GetInstance;
            // if (firstInstance.Equals(secondInstance))
            // {
            //     Console.WriteLine("The firstInstance and secondInstance are the same.");
            // }
            // else
            // {
            //     Console.WriteLine("Different instances exist.");
            // }


            SingletonLazy firstLazyInstance = SingletonLazy.GetInstance;
            Console.WriteLine("Trying to get another Singleton instance, called secondInstance.");

            SingletonLazy secondLazyInstance = SingletonLazy.GetInstance;
            if (firstLazyInstance.Equals(secondLazyInstance))
            {
                Console.WriteLine("The firstInstance and secondInstance are the same.");
            }
            else
            {
                Console.WriteLine("Different instances exist.");
            }

            Console.Read();
        }
    }

    // A singleton allows access to a single created instance - that instance (or rather, a reference to that instance) can be passed as a parameter to other methods, and treated as a normal object.

    // A static class allows only static methods.
    public sealed class Singleton
    {
        private static Singleton instance;
        private Singleton() { }
        static Singleton()
        {
            instance = new Singleton();
        }
        public static Singleton GetInstance
        {
            get
            {
                if (instance == null)
                {
                    instance = new Singleton();
                }
                return instance;
            }
        }
    }
    // Lazy initialization is a technique that defers the creation of an object until the first time it is needed. In other words, initialization of the object happens only on demand Test test = lazy.value;
    public sealed class SingletonLazy
    {
        delegate SingletonLazy SingletonDelegateWithNoParameter();
        static SingletonDelegateWithNoParameter myDel = MakeSingletonInstance;
        static Func<SingletonLazy> myFuncDelegate = MakeSingletonInstance;
        private static readonly Lazy<SingletonLazy> Instance = new Lazy<SingletonLazy>(
            myDel()
            // myFuncDelegate()
        );
        private static SingletonLazy MakeSingletonInstance()
        {
            return new SingletonLazy();
        }
        private SingletonLazy() { }
        public static SingletonLazy GetInstance
        {
            get
            {
                return Instance.Value;
            }
        }
    }
}