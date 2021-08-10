using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;

namespace _01_TypesAndVariables
{
    [TestClass]
    public class quiz
    {
        [TestMethod]
        public void Name(string name)
        {
            Console.WriteLine($"Hello {name}");
        }

        [TestMethod]
        public void MyTestMethod()
        {
            Name("Jack");
            Console.WriteLine(Bigger(4.20, 6.00));
            Console.WriteLine(Bigger(4.20, 3.00));

            
        }

        [TestMethod]
        public void Birthday(long date)
        {
            DateTime today = DateTime.UtcNow;
            DateTime someDay = new DateTime(date);
            TimeSpan timeSpan = today - someDay;
            
        }

        [TestMethod]
        public double divider(int first, int second)
        {
            int quotiant = first / second;
            double ans = Convert.ToDouble(quotiant);
            return ans;
        }
        [TestMethod]
        public double Bigger(double first, double second)
        {
            if(first > second)
            {
                return first;
            }
            return second;
        }
    }
}
