using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DesignPatterns.SOLID.DependencyInversionPrinciple
{
    class DependencyInversionPrinciple
    {
        // High level part of the system should not depend on low level part.
        public enum Relationship
        {
            parent,
            child,
            sibling
        }
        public class Person
        {
            public string name;
        }
        public interface IRelationshipBrowser
        {
            IEnumerable<Person> findAllChildrenOf(string name);
        }
        public class Relaionships: IRelationshipBrowser
        {
            private List<(Person, Relationship, Person)> relations = new List<(Person, Relationship, Person)>();
            public void AddParentAndChild(Person parent, Person child)
            {
                // Here is duplication in the conde and depends on relationship
                relations.Add((parent, Relationship.parent, child));
                relations.Add((child, Relationship.child, parent));
            }

            public IEnumerable<Person> findAllChildrenOf(string name)
            {
                foreach (var r in relations.Where(x => x.Item1.name == name && x.Item2 == Relationship.parent))
                {
                    yield return r.Item3;
                }
            }

           // public List<(Person, Relationship, Person)> Relations => relations;
        }

        public class Research
        {
            //public Research(Relaionships relationShips)
            //{
            //    var relations = relationShips.Relations;
            //    foreach(var r in relations.Where(x=>x.Item1.name=="Soniya Gandhi" && x.Item2==Relationship.parent))
            //    {
            //        Console.WriteLine($"Soniya Gandhi has a child called {r.Item3.name}");
            //    }
            //}
            public Research(IRelationshipBrowser relationship)
            {
                foreach (var r in relationship.findAllChildrenOf("Soniya Gandhi"))
                {
                    Console.WriteLine($"Soniya Gandhi has a child called {r.name}");
                }
            }
            //static void Main(string[] args)
            //{
            //    #region 5 Dependency inversion principle
            //    /********************Dependency inversion principle********************/
            //    Console.WriteLine("********************Dependency inversion principle********************");


            //    var parent = new Person { name = "Soniya Gandhi" };
            //    var child1 = new Person { name = "Rahul Gandhi" };
            //    var child2 = new Person { name = "Priyanka Gandhi" };

            //    var relationships = new Relaionships();
            //    relationships.AddParentAndChild(parent, child1);
            //    relationships.AddParentAndChild(parent, child2);
            //    Console.ReadKey();
            //    #endregion
            //}

        }
    }
}
