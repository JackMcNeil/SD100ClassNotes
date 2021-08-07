using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;

namespace _05_Classes
{
    [TestClass]
    public class PersonTest
    {
        [TestMethod]
        public void PersonPropertyTests()
        {
            Person firstPerson = new Person("Jack", "McNeil", new DateTime(1998,12,22), "420-69-4201", 800);

            //firstPerson.FirstName = "Jack";
            //firstPerson.LastName = "McNeil";
            //firstPerson.DateOfBirth = new DateTime(1998, 12, 22);
            //firstPerson.SocialSecurity = "420-69-4201";
            //firstPerson.CreditScore = 800;

            Console.WriteLine($"{firstPerson.FullName} was born on {firstPerson.DateOfBirth.ToShortDateString()}");

            Console.WriteLine($"{firstPerson.LastName} {firstPerson.SocialSecurity}");

            firstPerson.Transport = new Vehicle("Tesla", "Model S", 42024, VehicleType.Car);

            Console.WriteLine($"{firstPerson.FirstName} drives a {firstPerson.Transport.Make} {firstPerson.Transport.Model}");

            Assert.AreEqual("Jack M", firstPerson.FullName);
            firstPerson.Transport.TurnOn();
            Assert.IsTrue(firstPerson.Transport.IsRunning);
           
        }
    }
}
