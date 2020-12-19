using System;
using System.Collections.Generic;
using System.Linq;

namespace DependencyInversion
{
    public enum Relationship
    {
        Parent,
        Child,
        Sibling
    }

    public class Person
    {
        public string Name;
        // public DateTime DateOfBirth;
    }

    public interface IRelationshipBrowser
    {
        IEnumerable<Person> FindAllChildrenOf(string name);
    }

    public class Relationships : IRelationshipBrowser // low-level
    {
        private List<(Person, Relationship, Person)> relations
          = new List<(Person, Relationship, Person)>();

        public void AddParentAndChild(Person parent, Person child)
        {
            relations.Add((parent, Relationship.Parent, child));
            relations.Add((child, Relationship.Child, parent));
        }

        public List<(Person, Relationship, Person)> Relations => relations;

        public IEnumerable<Person> FindAllChildrenOf(string name)
        {
            return relations
              .Where(x => x.Item1.Name == name
                          && x.Item2 == Relationship.Parent).Select(r => r.Item3);
        }
    }

    public class Research
    {
        public Research(){}
        public Research(Relationships relationships)
        {
            // high-level: find all of john's children
            //var relations = relationships.Relations;
            //foreach (var r in relations
            //  .Where(x => x.Item1.Name == "John"
            //              && x.Item2 == Relationship.Parent))
            //{
            //  WriteLine($"John has a child called {r.Item3.Name}");
            //}
        }
        public string FindWithNames(IRelationshipBrowser browser)
        {
            string str = string.Empty;
            foreach (var p in browser.FindAllChildrenOf("John"))
            {
                str += $"John has a child called {p.Name} \n";
            }
            return str;

        }
    }
}