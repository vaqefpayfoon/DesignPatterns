using System;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;
using System.Xml.Serialization;

namespace Prototype
{
    class Car : ICloneable
    {
        int width;

        public Car(int width)
        {
            this.width = width;
        }

        public object Clone()
        {
            return new Car(this.width);
        }

        public override string ToString()
        {
            return string.Format("Width of car = {0}", this.width);
        }
    }
    public static class ExtensionMethods
    {
        public static T DeepCopy<T>(this T self)
        {
            var stream = new MemoryStream();
            var formatter = new BinaryFormatter();
            formatter.Serialize(stream, self);
            stream.Seek(0, SeekOrigin.Begin);
            object copy = formatter.Deserialize(stream);
            stream.Close();
            return (T)copy;
        }
        public static T DeepCopyXml<T>(this T self)
        {
            using(var ms = new MemoryStream())
            {
                var s = new XmlSerializer(typeof(T));
                s.Serialize(ms, self);
                ms.Position = 0;
                return (T) s.Deserialize(ms);
            }
        }
    }
    public interface IProtoType<T>
    {
        T DeepCopy();
    }
    public class Person //: IProtoType<Person>
    {
        public Person()
        {
            
        }
        public string[] Names;
        public Address Address;
        public Person(string[] names, Address address)
        {
            if(names == null)
                throw new ArgumentNullException(paramName: nameof(names));
            if(address == null)
                throw new ArgumentNullException(paramName: nameof(address));
            Names = names;
            Address = address;
        }
        public Person(Person other)
        {
            Names = other.Names;
            Address = other.Address;
        }
        public override string ToString()
        {
            return $"names: {string.Join(" ", Names)}, address: {Address}";
        }

        // public Person DeepCopy()
        // {
        //     return new Person(Names, Address.DeepCopy());
        // }
    }
    public class Address //: IProtoType<Address>
    {
        public string StreetName;
        public int HouseNumber;
        public Address()
        {
            
        }
        public Address(string streetName, int houseNumber)
        {
            StreetName = streetName;
            HouseNumber = houseNumber;
        }
        public Address(Address other)
        {
            StreetName = other.StreetName;
            HouseNumber = other.HouseNumber;
        }
        public override string ToString()
        {
            return $"StreetName: {string.Join(" ", StreetName)}, HouseNumber: {HouseNumber}";
        }
        // public Address DeepCopy()
        // {
        //     return new Address(StreetName, HouseNumber);
        // }
    }
    class Program
    {
        static void Main(string[] args)
        {
            Car carOne = new Car(1695);
            Car carTwo = carOne.Clone() as Car;

            //Console.WriteLine("{0}mm", carOne);
            //Console.WriteLine("{0}mm", carTwo);

            var john = new Person(new string[] {"john", "smith"}, new Address("London Road", 123));

            var jane = john.DeepCopyXml();
            jane.Address.HouseNumber = 321;
            jane.Names = new string[] {"jane", "adam"};

            Console.WriteLine(john);
            Console.WriteLine(jane);

        }
    }
}
