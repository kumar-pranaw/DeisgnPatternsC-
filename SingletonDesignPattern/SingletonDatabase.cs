using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SingletonDesignPattern
{
    public class SingletonDatabase : IDatabase
    {
        private Dictionary<string, int> capitals;
        private SingletonDatabase()
        {
            Console.WriteLine("Initializing database");

            capitals = File.ReadAllLines(
              Path.Combine(
                new FileInfo(typeof(IDatabase).Assembly.Location).DirectoryName, "capitals.txt")
              )
              .Batch(2)
              .ToDictionary(
                list => list.ElementAt(0).Trim(),
                list => int.Parse(list.ElementAt(1)));
        }
        public int GetPopulation(string name)
        {
            throw new NotImplementedException();
        }
    }
}
