using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SolidPrinciples
{
    public class Journal
    {
        private readonly List<string> entries = new List<string>();
        private static int count = 0;
        public int AddEntry(string text)
        {
            entries.Add($"{++count}:{text}");
            return count;// memento
        }
        public void RemoveEntry(int index)
        {
            entries.RemoveAt(index);
        }
        public override string ToString()
        {
            return string.Join(Environment.NewLine, entries);
        }
    }
    public class Persistence
    {
        public void SaveToFile(Journal j, string filename, bool overwrite = false)
        {
            if (overwrite || !File.Exists(filename))
            {
                File.WriteAllText(filename, j.ToString());
            }
        }
    }
    class SingleResponsibility
    {
        public SingleResponsibility(IRelationshipBrowser browser)
        {
            
            foreach(var r in browser.FindAllChindrenOf("John"))
            {
                Console.WriteLine($"John has a child called {r.Name}");
            }
        }
        static public int Area(Rectangle r) => r.Width * r.Height;
        static void Main(string[] args)
        {

            #region Using Code For Single Responsibility Principle
            //var j = new Journal();
            //j.AddEntry("I cried Today");
            //j.AddEntry("I ate a bug");
            //Console.WriteLine(j);

            //var p = new Persistence();
            //var filename = @"C:\Users\pranav.k.verma\Documents\journal.txt";
            //p.SaveToFile(j, filename);
            //Process.Start(filename);

            #endregion

            #region Using code For Open Closed Principle In Main Function

            //var apple = new Product("Apple", Color.Green, Size.Small);
            //var tree = new Product("Tree", Color.Green, Size.Large);
            //var house = new Product("House", Color.Blue, Size.Large);
            //Product[] products = { apple, tree, house };
            //var pf = new ProductFilter();
            //Console.WriteLine("Green Products (Old):");
            //foreach (var p in pf.FilterByColor(products, Color.Green))
            //{
            //    Console.WriteLine($" - {p.Name} is green");
            //}
            //var bf = new BetterFilter();
            //Console.WriteLine("Green Products (new):");
            //foreach(var p in bf.Filter(products, new ColorSpecification(Color.Blue))){
            //    Console.WriteLine($" - {p.Name} is green");
            //}

            //Console.WriteLine("Large Blue Item: ");
            //foreach(var p in bf.Filter(products,new AndSpecification<Product>(
            //                                     new ColorSpecification(Color.Blue),
            //                                     new SizeSpecification(Size.Large))
            //                                        ))
            //{
            //    Console.WriteLine($" - { p.Name} is big and blue");
            //}
            #endregion

            #region Using Code for Liskov Substitution Principle in Main method

            //Rectangle rc = new Rectangle(2,3);
            //Console.WriteLine($"{rc} has area {Area(rc)}");

            //Rectangle Sq = new Square();
            //Sq.Width = 4;
            //Console.WriteLine($"{Sq} has area {Area(Sq)}");
            #endregion

            #region Code for implementing Interface Segregation Principle

            #endregion

            #region Code for implementing Dependency Inversion Principle

            var parent = new Person { Name = "John" };
            var child1 = new Person { Name = "Chris" };
            var child2 = new Person { Name = "Mary" };

            var relationships = new RelationShips();
            relationships.AddParentAndChild(parent, child1);
            relationships.AddParentAndChild(parent, child2);
            new SingleResponsibility(relationships);
            #endregion
        }
    }
}
