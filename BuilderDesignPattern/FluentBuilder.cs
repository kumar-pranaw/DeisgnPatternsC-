using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BuilderDesignPattern
{
    public class Person
    {
        public string Name;
        public string Position;
        public string DateOFBirth;

        public class Builder : PersonDetailsBuilder<Builder>
        {

        }
        public static Builder New => new Builder();

        public override string ToString()
        {
            return $"{nameof(Name)}: {Name}, {nameof(Position)}: {Position},{nameof(DateOFBirth)}:{DateOFBirth}";
        }
    }

    public abstract class PersonBuilder<SELF>
       where SELF : PersonBuilder<SELF>
    {
        protected Person person = new Person();

        public Person Build()
        {
            return person;
        }
    }
  
   public class PersonInfoBuilder<SELF> : PersonBuilder<PersonInfoBuilder<SELF>>
   where SELF : PersonInfoBuilder<SELF>
    {
        public SELF Called(string name)
        {
            person.Name = name;
            return (SELF)this;
        }
    }
    public class PersonJobBuilder<SELF> : PersonInfoBuilder<PersonJobBuilder<SELF>>
    where SELF : PersonJobBuilder<SELF>
    {
        public SELF WorksAsA(string position)
        {
            person.Position = position;
            return (SELF)this;
        }
    }
    public class PersonDetailsBuilder<SELF> : PersonJobBuilder<PersonDetailsBuilder<SELF>>
      where SELF : PersonDetailsBuilder<SELF>
    {
        public SELF BornAt(string dob)
        {
            person.DateOFBirth = dob;
            return (SELF)this;
        }
    }
    public class FluentBuilder
    {
        public static void FluentBuilderDemo()
        {
            var builder = new Person.Builder();
            var person = builder.Called("Pranav").WorksAsA("Accountant").BornAt("11-02-1995").Build();
            Console.WriteLine(person);
        }
    }
}
