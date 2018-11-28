using System;
using System.Collections.Generic;
using Console = System.Console;

namespace FactoryPattern
{
    public class AbstractFactory
    {
        public interface IHotDrink
        {
            void Consume();
        }

        internal class Tea : IHotDrink
        {
            public void Consume()
            {
              Console.WriteLine("This tea is nice but i'd prefer it with milk.");
            }
        }

        internal class Coffee : IHotDrink
        {
            public void Consume()
            {
                Console.WriteLine(("This coffee is sensational !!"));
            }
        }

        public interface IHotDrinkFactory
        {
            IHotDrink Prepare(int amount);
        }

        internal class TeaFactory : IHotDrinkFactory
        {
            public IHotDrink Prepare(int amount)
            {
                Console.WriteLine($"Put in a tea bag, boil water, pour {amount} ml, add lemon, enjoy!");
                return new Tea();
            }
        }

        internal class CoffeFactory : IHotDrinkFactory
        {
            public IHotDrink Prepare(int amount)
            {
                Console.WriteLine($"Grind some beans, boil water, pour {amount} ml, add cream and sugar, enjoy");
                return new Coffee();
            }
        }

        public class HotDrinkMAchine
        {
            public enum AvailableDrink // Violates Open-Closed Principle
            {
                Coffee, Tea
            }
            private Dictionary<AvailableDrink, IHotDrinkFactory> factories =
                new Dictionary<AvailableDrink, IHotDrinkFactory>();
            public HotDrinkMAchine()
            {
                foreach (AvailableDrink drink in Enum.GetValues(typeof(AvailableDrink)))
                {
                    var factory = (IHotDrinkFactory)Activator.CreateInstance(
                      Type.GetType("FactoryPattern." + Enum.GetName(typeof(AvailableDrink), drink) + "Factory"));
                    factories.Add(drink, factory);
                }
            }

            public IHotDrink MakeDrink(AvailableDrink drink, int amount)
            {
                return factories[drink].Prepare(amount);
            }
        }
       
    }
}
