using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Session005_ClassesAndOOP
{
    class Animal
    {
        public string name;
        public string sound;

        //unlike structs, classes can have explicit parameterless constructors
        public Animal()
        {
            name = "No name";
            sound = "No sound";
            ++numOfAnimals;
        }

        public Animal(string name = "No name", string sound = "No sound")
        {
            this.name = name;
            this.sound = sound;
            ++numOfAnimals;
        }

        public Animal(Animal a)
        {
            this.name = a.name;
            this.sound = a.sound;
            ++numOfAnimals;
        }

        public void MakeSound()
        {
            Console.WriteLine("{0} says {1}", name, sound);
        }

        //static fields and methods
        //belong to the class, not the object.

        static int numOfAnimals = 0;
        public static int GetNumAnimals()
        {
            return numOfAnimals;
        }

    }
}
