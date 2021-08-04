using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;

namespace _05_Classes
{
    [TestClass]
    public class VehicleTests
    {
        [TestMethod]
        public void PropertiesTest()
        {
            Vehicle firstVehicle = new Vehicle();

            firstVehicle.Make = "Tesla";
            Console.WriteLine(firstVehicle.Make);
            firstVehicle.Milage = 420;
            firstVehicle.Model = "Model S";
            firstVehicle.TypeOfVehicle = VehicleType.Car;

            Console.WriteLine($"My car is a {firstVehicle.Make} {firstVehicle.Model} with {firstVehicle.Milage} miles on it.");
        }
    }
}
