using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;

namespace _06_Inheritance
{
    [TestClass]
    public class AnimalTests
    {
        [TestMethod]
        public void AnimalTestMethods()
        {
            Mammal Millie = new Mammal();
            Console.WriteLine(Millie.NumberOfLegs);
            Console.WriteLine(Millie.HasFur);

            Millie.MakeSounds();

            Horse horse = new Horse();
            horse.MakeSounds();
            horse.Roar();
            Console.WriteLine(horse.ToString());

            Mustang musty = new Mustang();
            musty.MakeSounds();
        }
    }
}
