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
    public interface IRelationshipBrowser
    {
        IEnumerable<Person> FindAllChindrenOf(string name);
    }


    //Low Level
    public class RelationShips : IRelationshipBrowser
    {
        private List<(Person, Relationship, Person)> relations = new List<(Person, Relationship, Person)>();
        public void AddParentAndChild(Person parent, Person child)
        {
            relations.Add((parent, Relationship.Parent, child));
            relations.Add((child, Relationship.Child, child));
        }

        public IEnumerable<Person> FindAllChindrenOf(string name)
        {
            foreach (var r in relations.Where(
                x => x.Item1.Name == name &&
                x.Item2 == Relationship.Parent
                ))
            {
                yield return r.Item3;
            }
        }

        //  public List<(Person, Relationship, Person)> Relations => relations;
    }
 
    public class DependencyInversionPrinciple
    {
    }
}
