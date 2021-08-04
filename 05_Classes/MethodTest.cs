using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Threading;

namespace _05_Classes
{
    [TestClass]
    public class MethodTest
    {
        [TestMethod]
        public void GreetingTests()
        {
            // Instantiating an object
            Greeter greeter = new Greeter();

            // Calling a method from our variable of that object
            greeter.SayHello("Jack");

            //Calling our overloaded method
            greeter.SayHello();

            greeter.RandomGreeting();
            //Thread sleep so we have some space between our random requests sing its based on time
            Thread.Sleep(5);
            greeter.RandomGreeting();
            Thread.Sleep(5);
            greeter.RandomGreeting();
        }

        [TestMethod]
        public void Calculations()
        {
            Calculator calculator = new Calculator();
            // Addition
            int sum = calculator.Add(8, 12);
            Assert.AreEqual(20, sum);
            double sumTwo = calculator.Add(9, 4.2);
            Assert.AreEqual(13.2, sumTwo);

            // Subtraction
            double diff = calculator.Sub(1, 5);
            Assert.AreEqual(diff, -4);

            //Multiplication
            Console.WriteLine(calculator.Multi(5,4));
            double product = calculator.Multi(5, 4);

            //Division
            Assert.AreEqual(3.5, calculator.Divide(21, 6));
            double quotiant = calculator.Divide(21, 6);

        }
        [TestMethod]
        public void AgeCalculator()
        {
            Calculator calculator = new Calculator();
            // Age
            int age = calculator.CalculateAge(new DateTime(1998, 12, 22));
            Console.WriteLine($"Jack is {age} years old!");
        }
    }
}
