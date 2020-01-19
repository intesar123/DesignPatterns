using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FluentBuilderInheritanceWithRecursiveGenerics
{
    // now now we'll have to replace return type of both Call() and WorkAs() method with something more sophisticated
    //or more Advance. Now the question is how can we propagate info from derive class to its own base class and how can we do infinitely or recursively?
    // the answer is recursive generics,here I'm going to build a abstract class which contains the common info. 
    public class PersonNew
    {
        public string Name;
        public string Position;
        public class Builder : PersonJobBuilder<Builder>
        {

        }
        // how can you expose above builder
        public static Builder New => new Builder();
        public override string ToString()
        {
            return $"{nameof(Name)}: {Name}, {nameof(Position)}: {Position}";
        }
    }
    public abstract class PersonBluilder
    {
        protected PersonNew person=new PersonNew();
        public PersonNew Build()
        {
            return person;
        }
    }
   
    //SELF- class Foo: Bar<Foo>
    public class PersonInfoBuilderNew<SELF>:PersonBluilder
        where SELF: PersonInfoBuilderNew<SELF>
    {
        //protected Person person = new Person();

        public SELF Call(string Name)
        {
            person.Name = Name;
            return (SELF)this;
        }
    }
    //Suppose that we got some requirement after some time that we've to add job info so by
    //following open-closed loop principle we can't modify above class so here we have to create another builder here
    public class PersonJobBuilder<SELF> : PersonInfoBuilderNew<PersonJobBuilder<SELF>>
        where SELF: PersonJobBuilder<SELF>
    {
        public SELF WorkAs(string Position)
        {
            person.Position = Position;
            return (SELF)this;
        }
    }
}
