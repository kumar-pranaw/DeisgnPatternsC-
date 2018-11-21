using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BuilderDesignPattern
{
    public class Persons
    {
        public string Name;

        public string Position;

        class Builder : PersonInfoBuilder<Builder> { /* degenerate */ }

        public override string ToString()
        {
            return $"{nameof(Name)}: {Name}, {nameof(Position)}: {Position}";
        }
    }

    abstract class PersonBuilders<SELF>
      where SELF : PersonBuilder<SELF>
    {
        protected Person person = new Person();

        public Person Build()
        {
            return person;
        }
    }

    class PersonInfoBuilders<SELF> : PersonBuilder<PersonInfoBuilder<SELF>>
      where SELF : PersonInfoBuilder<SELF>
    {
        public SELF Called(string name)
        {
            person.Name = name;
            return (SELF)this;
        }
    }

    class PersonJobBuilders<SELF> : PersonInfoBuilder<PersonJobBuilder<SELF>>
      where SELF : PersonJobBuilder<SELF>
    {
        public SELF WorksAsA(string position)
        {
            person.Position = position;
            return (SELF)this;
        }
    }
    class FluentBuilderWithRecursiveGenerics
    {
    }
}
