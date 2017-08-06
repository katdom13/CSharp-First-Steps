using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Session006_ControlAccess_GettersAndSetters
{
    class Animal
    {
        public string name;
        public string sound;

        //const can only be defined at declaration, cannot be changed after that
        public const string SHELTER = "Miss Kat's Home For Peculiar Animals";

        //readonly can be defined at runtime, but only at declaration or constructor
        //it cannot be changed after that
        public readonly int idNum;

        //Random is best static
        static Random rand = new Random();
        
        //different constructors

        //default
        public Animal()
            : this("No name", "No sound") {
        }

        public Animal(Animal a)
            : this(a.GetName(), a.Sound) {
            Owner = a.Owner;
            idNum = a.idNum;
        }

        //defining constructors
        public Animal(string name, string sound)
        {
            SetName(name);
            Sound = sound;

            NumOfAnimals = 1;

            //Random rand = new Random();
            idNum = rand.Next(1, int.MaxValue);
            rand.Next(10);
            //idNum = numOfAnimals;
        }

        //methods
        public void MakeSound()
        {
            Console.WriteLine("{0} says {1}", name, sound);
        }

        //java style getters and setters
        public void SetName(string name)
        {
            //no numbers 
            if (!name.Any(char.IsDigit))
            {
                this.name = name;
            }
            else
            {
                this.name = "No name";
                Console.WriteLine("Digits aren't allowed in name.");
            }
        }

        public string GetName()
        {
            return name;
        }

        //C# best practice
        public string Sound
        {
            get
            {
                return sound;
            }
            set
            {
                if (value.Length > 10)
                {
                    this.sound = "No sound";
                    Console.WriteLine("Sound is too long.");
                }
                else
                {
                    this.sound = value;
                }
            }
        }

        //C# getters and setters default implementation
        //can do without upper variable
        public string Owner { get; set; } = "No owner";

        //static values and methods plus static geters and setters
        private static int numOfAnimals = 0;
        public static int NumOfAnimals
        {
            get
            {
                return numOfAnimals;
            }
            set
            {
                numOfAnimals += value;
            }
        }

    }

}
