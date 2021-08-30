using _10_Interfaces.Fruits;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;

namespace _10_Interfaces
{
    [TestClass]
    public class FruitTest
    {
        [TestMethod]
        public void CallingInterfaceMethods()
        {
            IFruit banana = new Banana();
            string output = banana.Peel();
            Console.WriteLine(output);

            Assert.IsTrue(banana.IsPeeled);
        }

        [TestMethod]
        public void InterfacesInCollections()
        {
            Orange orange = new Orange();

            var fruitSalad = new List<IFruit>
            {
                new Banana(),
                new Grape(),
                orange
            };

            foreach(var fruit in fruitSalad)
            {
                Console.WriteLine(fruit.Name);
                Console.WriteLine(fruit.Peel());

                Assert.IsInstanceOfType(fruit, typeof(IFruit));

                //Doesn't work because treated as IFruit in collection
                //Fruit.Squeeze();
            }

            Console.WriteLine(orange.Squeeze());
        }

        private string GetFruitName(IFruit fruit)
        {
            return $"This fruit is called {fruit.Name}";
        }

        [TestMethod]
        public void InterfacesInMethods()
        {
            var grape = new Grape();

            var output = GetFruitName(grape);
            Console.WriteLine(output);

            Assert.IsTrue(output.Contains("This fruit is called Grape"));
        }

        [TestMethod]
        public void TypeOfInstance()
        {
            var fruitSalad = new List<IFruit>
            {
                new Orange(true),
                new Orange(),
                new Grape(),
                new Orange(),
                new Banana(true),
                new Grape(),
            };

            foreach (var fruit in fruitSalad)
            {
                if (fruit is Orange orange) // This is pattern matching, not IFruit
                {
                    if (orange.IsPeeled)
                    {
                        Console.WriteLine("Is a peeled orange");
                        Console.WriteLine(orange.Squeeze());
                    }
                    else
                        Console.WriteLine("Is an orange");
                }
                // using typeof check, still considered IFruit
                else if (fruit.GetType() == typeof(Grape))
                {
                    Console.WriteLine("It's a grape");
                    
                    //Without pattern matching, we need to cast
                    var grape = (Grape)fruit;
                    Console.WriteLine(grape.Peel());
                }
                else if (fruit.IsPeeled)
                    Console.WriteLine("Is a peeled banana.");
                else
                    Console.WriteLine("It's a banana");
            }
        }
    }
}
