using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SingletonDesignPattern
{
    public interface IDatabase
    {
        int GetPopulation(string name);
    }
}
