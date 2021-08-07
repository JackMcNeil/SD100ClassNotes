using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;

namespace _05_Classes
{
    [TestClass]
    public class RoomTest
    {
        [TestMethod]
        public void RoomTestMethods()
        {
            Room room1 = new Room();
            room1.Length = 25;
            room1.Width = 10;
            room1.Height = 12;

            Console.WriteLine(room1.CalculateSquareFootage());
            Console.WriteLine(room1.CalcualateLaterSA());
        }
    }
}
