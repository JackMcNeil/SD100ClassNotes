using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _05_Classes
{
    public class Calculator
    {
        // Addition
        public int Add(int numOne, int numTwo)
        {
            int sum = numOne + numTwo;
            return sum;
        }

        public double Add(double numOne, double numTwo)
        {
            return numOne + numTwo;
        }

        //Subtraction
        public double Sub(double numOne, double numTwo)
        {
            return numOne - numTwo;
        }

        // Multiplication
        public double Multi(double numOne, double numTwo)
        {
            return numOne * numTwo;
        }

        //Division
        public double Divide(double numOne, double numTwo)
        {
            return numOne / numTwo;
        }

        //Remainder
        public int Remainder(int x, int y)
        {
            return x % y;
        }

        // Age calculation
        public int CalculateAge(DateTime birthDate)
        {
            TimeSpan ageSpan = DateTime.Now - birthDate;
            double totalAgeInYears = ageSpan.TotalDays / 365.25;
            double ageRounded = Math.Floor(totalAgeInYears);
            int years = Convert.ToInt32(ageRounded);
            return years;
        }
    }
}
