using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;

namespace _04_Loops
{
    [TestClass]
    public class LoopsChallenge
    {
        [TestMethod]
        public void Challanges()
        {
            string super = "Supercalifragilisticexpialidocious";
            Console.WriteLine("Number 1");
            int count = 0;
            foreach(char letter in super)
            {
                Console.WriteLine(letter);
                count++;
            }
            Console.WriteLine(count);
            Console.WriteLine("Number 2");
            foreach(char letter in super)
            {
                if (letter != 'i' && letter != 'l')
                {
                    Console.WriteLine("Not an I");
                }
                else
                {
                    Console.WriteLine(letter);
                }
            }
        }
    }
}
