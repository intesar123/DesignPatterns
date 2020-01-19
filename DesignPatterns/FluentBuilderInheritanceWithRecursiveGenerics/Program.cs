using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FluentBuilderInheritanceWithRecursiveGenerics
{
    public class Person
    {
        public string Name;
        public string Position;

        public override string ToString()
        {
            return $"{nameof(Name)}: {Name}, {nameof(Position)}: {Position}";
        }
    }
    public class PersonInfoBuilder
    {
        protected Person person = new Person();

        public PersonInfoBuilder Call(string Name)
        {
            person.Name = Name;
            return this;
        }
    }
    //Suppose that we got some requirement after some time that we've to add job info so by
    //following open-closed loop principle we can't modify above class so here we have to create another builder here
    public class PersonJobBuilder: PersonInfoBuilder
    {
        public PersonJobBuilder WorkAs(string Position)
        {
            person.Position = Position;
            return this;
        }
    }
    class Program
    {
        static void Main(string[] args)
        {
            var builder = new PersonJobBuilder();
            /****here by calling Call() we are just degrading PersonJobBuilder to PersonInfoBuilder 
             so unable to chain WorkAs() method, the problem is return type of both the methods **/
            //builder.Call("Intesar").WorkAs

            //-- builder.WorkAs("Developer").Call("Intesar"); // didn't got its

            var me = PersonNew.New.Call("Intesar Alam").WorkAs("Developer").Build();
            Console.WriteLine(me);
            Console.ReadKey();
        }
    }
}
