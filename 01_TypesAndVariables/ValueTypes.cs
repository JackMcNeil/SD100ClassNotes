using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;

namespace _01_TypesAndVariables
{
    [TestClass]
    public class ValueTypes
    {
        [TestMethod]
        public void Booleans()
        {
            // Declared Bool
            bool declared;

            // Assigning Value
            declared = true;

            // Together
            bool declareAndIntialized = false;

            // Still reassign value after intial assignment
            declareAndIntialized = true;
        }
        [TestMethod]
        public void Characters()
        {
            char character = 'a';
            char symbol = '?';
            char number = '7';
            char space = ' ';
            char specialCharacter = '\n';
        }
        [TestMethod]
        public void WholeNumbers()
        {
            byte byteMin = 0;
            byte byteMax = 255;
            short shortMin = -32768;
            short shortMax = 32767;
            int intMin = -2147483648;
            int intMax = 2147483647;
            long longMin = -9223372036854775808;
            long longMax = 9223372036854775807;
            int a = 15;
            int b = -2;
        }

        [TestMethod]
        public void Decimals()
        {
            // float needs "f" at the end
            float floatExample = 1.23452323f;
            // Suffix Optional for doubles
            double doubleExample = 4.2069420d;
            // decimal needs "m" at the end
            decimal decimalExample = 4.20420420420678m;
        }

        enum PastryType {Cake, Cupcake, Eclaire, PetitFour, Croissant};

        [TestMethod]
        public void Enum()
        {
            PastryType myPastry = PastryType.Croissant;
            PastryType yourPastry = PastryType.PetitFour;
        }

        [TestMethod]
        public void Structs()
        {
            DateTime today = DateTime.Today;
            DateTime birthday = new DateTime(1998, 12, 22);
        }
    }
}
