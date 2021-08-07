using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _06_Inheritance
{
    public class Mammal : Animal
    {
        public string FurColor { get; set; }
        public Mammal()
        {
            HasFur = true;
            NumberOfLegs = 4;
            Console.WriteLine("This is the mammal constructor");
        }

        public override void MakeSounds()
        {
            Console.WriteLine("Bark!");
        }
    }

    public class Horse : Mammal
    {
        // protected = private but also including inherited classes
        public double Speed { get; set; } = 30d;
        public Horse()
        {
        }

        public void Roar()
        {
            base.MakeSounds();
        }

        public override void MakeSounds()
        {
            Console.WriteLine($"The {GetType().Name} says Neigh");
        }

        public override string ToString()
        {
            return "Hooooorse";
        }
    }

    public class Mustang : Horse
    {
        
    }

    public class Dog : Mammal
    {
        public bool HasFloppyEars { get; set; }
        public Dog()
        {
            
        }
    }
}
