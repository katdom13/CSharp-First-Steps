using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Session007_InheritancePolymorphism
{
    class Animal
    {
        private string name;
        protected string sound;

        //a delegate represents "has-a" relationship
        //Other objects within objects
        protected AnimalIDInfo animalIDInfo = new AnimalIDInfo();

        public Animal()
            : this("No name", "No sound") { }

        public Animal(string name, string sound)
        {
            Name = name;
            Sound = sound;
        }
        
        public Animal(Animal a)
            : this(a.Name, a.Sound) { }

        //some methods
        public virtual void MakeSound()
        {
            Console.WriteLine($"{Name} says {Sound}");
        }

        //from delegate
        public void SetAnimalIDInfo(string owner)
        {
            animalIDInfo.Owner = owner;
        }

        public void GetAnimalIDInfo()
        {
            Console.WriteLine($"{Name} has an id of {animalIDInfo.IDNum} and is owned by {animalIDInfo.Owner}");
        }

        public string Name
        {
            get
            {
                return name;
            }
            set
            {
                if (value.Any(char.IsDigit))
                {
                    name = "No name";
                    Console.WriteLine("Digits in name are not allowed.");
                }
                else
                {
                    name = value;
                }
            }
        }

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
                    sound = "No sound";
                    Console.WriteLine("Sound is too long");
                }
                else
                {
                    sound = value;
                }
            }
        }

        //inner class
        //classes within class
        //has access to private properties of the owner class
        //can house helper methods
        //it is like a big static class, but can be instantiated
        public class AnimalHealthHelp
        {
            public bool HealthyWeight(double height, double weight)
            {
                //Animal a = new Animal();
                //a.name = "I can access private fields";

                double calc = height / weight;
                if ((calc >= .18) && (calc <= .27))
                {
                    return true;
                }
                else
                {
                    return false;
                }
            }
        }

    }

}
