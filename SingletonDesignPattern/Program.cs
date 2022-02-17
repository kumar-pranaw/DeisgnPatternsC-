using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SingletonDesignPattern
{
    class Program
    {
        static void Main(string[] args)
        {
            Singleton singleton = Singleton.GetInstance;
            singleton.PrintDetails("From Employee");

            Singleton singleton1 = Singleton.GetInstance;
            singleton1.PrintDetails("From Student");
        }
    }
}
