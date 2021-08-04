using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _05_Classes
{
    public class Greeter
    {
        // 1 access modifier -> visibility in the program 
        // 2 return type -> What the method gives back
        // 3 name -> Uses PascalCase
        // 3(4) Method Signature -> The method name and the parameters
        // 4 Parameters -> What we need to pass to the method
        // 5 Statements -> Code executed
        public void SayHello(string name)
        {
            Console.WriteLine($"Hello {name}!");
        }

        //Overload, same name different signature
        public void SayHello()
        {
            Console.WriteLine("Hello stranger!");
        }

        Random _randy = new Random();
        public void RandomGreeting()
        {
            string[] availableGreetings = new string[] { "Hello", "Hi", "Greetings", "Sup", "Howdy","What's popping?" };
            int randomNumber = _randy.Next(0, availableGreetings.Length);
            string randomGreeting = availableGreetings[randomNumber];
            Console.WriteLine(randomGreeting);
        }
    }
}
