using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SolidPrinciples
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
    }

    //Low Level
    public class RelationShips
    {
        private List<(Person, Relationship, Person)> relations = new List<(Person, Relationship, Person)>();
        public void AddParentAndChild(Person parent, Person child)
        {
            relations.Add((parent, Relationship.Parent, child));
            relations.Add((child, Relationship.Child, child));
        }
        public List<(Person, Relationship, Person)> Relations => relations;
    }
    public class DependencyInversionPrinciple
    {
    }
}
