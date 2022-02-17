using System;

namespace SingletonDesignPattern
{
    sealed class Singleton
    {
        private static int counter = 0;
        private static Singleton instance = null;
        public static Singleton GetInstance
        {
            get 
            { 
                if (instance == null)
                    instance = new Singleton();
                return instance; 
            }
        }
        private Singleton()
        {
            counter++;
            Console.WriteLine($@"{ counter.ToString()} ");
        }
        public void PrintDetails(string message)
        {
            Console.WriteLine(message);
        }
    }
}
