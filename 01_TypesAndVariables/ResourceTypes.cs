using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;

namespace _01_TypesAndVariables
{
    [TestClass]
    public class ResourceTypes
    {
        [TestMethod]
        public void String()
        {
            string declared;

            declared = "This is initiliazed";

            string declaredAndInitiliazed = "This is both declared and initiliazed";

            string firstName = "Jack";
            string lastName = "McNeil";

            // Concatenation
            string concatenatedFullName = firstName + " " + lastName;

            // Composit Format
            string compositeFormatting = string.Format("{0} {1}", firstName, lastName);

            //Interpolation
            string interpolatedFormatting = $"{firstName} {lastName}";

            Console.WriteLine(firstName);
            Console.WriteLine(concatenatedFullName);
            Console.WriteLine(compositeFormatting);
            Console.WriteLine(interpolatedFormatting);
        }

        [TestMethod]
        public void Collections()
        {
            string greeting = "greetings";
            
            string[] stringArray = { "Hello", "Hi", "Goodbye", greeting };

            // Index starts at 0
            string thirdItem = stringArray[2];
            Console.WriteLine(thirdItem);
            Console.WriteLine(stringArray[2]);

            stringArray[2] = "Good Morning";
            Console.WriteLine(stringArray[2]);

            //List
            List<string> listOfStrings = new List<string>();
            List<int> listOfInts = new List<int>();

            listOfStrings.Add("Here's a string");
            listOfStrings.Add("2939239");

            listOfInts.Add(420);

            // Queue
            // Queue use FIFO
            Queue<string> firstInFirstOut = new Queue<string>();
            firstInFirstOut.Enqueue("I'm first");
            firstInFirstOut.Enqueue("I'm next");

            Console.WriteLine(firstInFirstOut.Peek());

            // Stacks
            // Stacks use LIFO
            Stack<string> firstInLastOut = new Stack<string>();

            firstInLastOut.Push("I'm a bun");
            firstInLastOut.Push("I'm a meat");
            firstInLastOut.Push("I'm a top bun");

            Console.WriteLine(firstInLastOut.Peek());

            // Dictionaries
            // Key value pair
            //Key Value
            Dictionary<int, string> keyAndValue = new Dictionary<int, string>();

            keyAndValue.Add(7, "Agent");

            string atSeven = keyAndValue[7];

            Dictionary<string, string> dictionaryDefinition = new Dictionary<string, string>();

            dictionaryDefinition.Add("Duck", "It quacks");

            string defintionOfDuck = dictionaryDefinition["Duck"];

            Console.WriteLine(defintionOfDuck);
        }

        [TestMethod]
        public void Classes()
        {
            Random rng = new Random();

            int randomNumber = rng.Next();

            Console.WriteLine(randomNumber);
        }

    }
}
