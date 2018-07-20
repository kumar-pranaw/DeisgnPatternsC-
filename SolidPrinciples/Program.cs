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
    class Program
    {
        static void Main(string[] args)
        {

            #region Code for First Approach
            //var j = new Journal();
            //j.AddEntry("I cried Today");
            //j.AddEntry("I ate a bug");
            //Console.WriteLine(j);

            //var p = new Persistence();
            //var filename = @"C:\Users\pranav.k.verma\Documents\journal.txt";
            //p.SaveToFile(j, filename);
            //Process.Start(filename);

            #endregion

            var apple = new Product("Apple", Color.Green, Size.Small);
            var tree = new Product("Tree", Color.Green, Size.Large);
            var house = new Product("House", Color.Blue, Size.Large);
            Product[] products = { apple, tree, house };
            var pf = new ProductFilter();
            Console.WriteLine("Green Products (Old):");
            foreach (var p in pf.FilterByColor(products, Color.Green))
            {
                Console.WriteLine($" - {p.Name} is green");
            }
            var bf = new BetterFilter();
            Console.WriteLine("Green Products (new):");
            foreach(var p in bf.Filter(products, new ColorSpecification(Color.Blue))){
                Console.WriteLine($" - {p.Name} is green");
            }

            Console.WriteLine("Large Blue Item: ");
            foreach(var p in bf.Filter(products,new AndSpecification<Product>(
                                                 new ColorSpecification(Color.Blue),
                                                 new SizeSpecification(Size.Large))
                                                    ))
            {
                Console.WriteLine($" - { p.Name} is big and blue");
            }
        }
    }
}
