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

        [TestMethod]
        public void MethodsTests()
        {
            Vehicle transport = new Vehicle();
            Indicator indicator = new Indicator();

            transport.TurnOn();
            Assert.IsTrue(transport.IsRunning);
            transport.TurnOff();

            indicator.TurnOn();
            Assert.IsTrue(indicator.IsFlashing);
            indicator.TurnOff();
        }

        [TestMethod]
        public void TurnSignalTest()
        {
            Vehicle myCar = new Vehicle();
            myCar.TurnOn();
            myCar.LeftIndicator = new Indicator();
            myCar.RightIndicator = new Indicator();

            myCar.TurnRight();
            CheckIndicators(myCar);
            Console.WriteLine("Turning right");


            myCar.TurnLeft();
            CheckIndicators(myCar);
            Console.WriteLine("Turning left");
        }

        public void CheckIndicators(Vehicle myCar)
        {
            Console.WriteLine($"Right Indicator: {myCar.RightIndicator.IsFlashing}");
            Console.WriteLine($"Left Indicator: {myCar.LeftIndicator.IsFlashing}");
        }

        [TestMethod]
        public void Constructors()
        {
            // old way, ew
            Vehicle car = new Vehicle();
            car.Make = "Toyota";
            car.Model = "Corolla";
            car.Milage = 120000;

            // New way with constructor
            Vehicle rocket = new Vehicle("SpaceX", "Falcon Heavy", 300000, VehicleType.Spaceship);
            Console.WriteLine(rocket.Make);
            Console.WriteLine(rocket.Model);
        }
    }
}
