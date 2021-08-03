using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;

namespace _03_Conditionals
{
    [TestClass]
    public class Ternary
    {
        [TestMethod]
        public void Ternaries()
        {
            int age = 31;

            // Variable = (Condition/Boolean) ? trueResult : falseResult;
            bool isAdult = (age > 17) ? true : false;

            int numOne = 10;

            int numTwo = (numOne == 10) ? 30 : 20;
            Console.WriteLine(numTwo);
            int numThree = (numOne == 2) ? 14 : 17;
            Console.WriteLine((numOne == 10) ? "True" : "False");
        }
    }
}
