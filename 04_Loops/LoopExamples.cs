using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;

namespace _04_Loops
{
    [TestClass]
    public class LoopExamples
    {
        [TestMethod]
        public void WhileLoops()
        {
            int total = 0;
            while (total != 50) // Expression that is either true or false
            {
                Console.WriteLine(total);
                total += 10;
                //total = total + 3;
            }

            while (true)
            {
                if (total == 10)
                {
                    Console.WriteLine("Goal reached!");
                    // Break ot of this loop
                    // intellisense tells us which loop it will break by highlighting it
                    break;
                }
                total++;
            }

            Random rand = new Random();
            int someNumber;
            bool keepLooping = true;

            while (keepLooping)
            {
                // Random number between 0-19
                someNumber = rand.Next(0, 20);

                if(someNumber == 0 || someNumber == 13)
                {
                    // skip to the next loop
                    continue;
                }

                Console.WriteLine(someNumber);

                if(someNumber == 15)
                {
                    keepLooping = false;
                }
            }
        }

        [TestMethod]
        public void ForLoops()
        {
            int studentCount = 26;

            // 1 - starting point, do this once at the very beginning
            // 2 - Loop condition, keep looping if this == true
            // 3 - Do this after each loop
            // 4 - The code executed every loop
            //      1           2               3
            for (int i = 0; i <= studentCount; i++)
            {
                //4 
                Console.WriteLine(i);
            }

            string[] students = { "jack", "doug", "mitch", "jordan", "emily" };

            for (int i = 0; i < students.Length; i++)
            {
                Console.WriteLine($"Welcome to class, {students[i]}");
            }

            // 1 - declare the type
            // 2 - name the item
            // 3 - "in" keyword
            // 4 - the list
            //         1      2     3    4
            foreach(string student in students)
            {
                Console.WriteLine(student);
            }

            string myName = "Jack Morgan McNeil";
            foreach (char letter in myName)
            {
                if (letter != 'M')
                {
                    // Console.Write(letter + "\n"):
                    Console.WriteLine(letter);
                }  
            }
        }

        [TestMethod]
        public void DoWhileLoops()
        {
            int iterator = 0;
            do
            {
                Console.WriteLine("Hello!");
                iterator++;
            } while (iterator < 5);
        }
    }
}
