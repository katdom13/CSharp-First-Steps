using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Session007_InheritancePolymorphism
{
    class Session007
    {
        static void Main(string[] args)
        {
            Animal fox = new Animal()
            {
                Name = "Nick",
                Sound = "Grrr"
            };

            Dog pug = new Dog()
            {
                Name = "Manta",
                Sound = "Woof",
                Sound2 = "Bork"
            };

            fox.MakeSound();
            pug.MakeSound();

            fox.Sound = "Rawwr";

            fox.SetAnimalIDInfo("Judy");
            pug.SetAnimalIDInfo("Kat");

            fox.GetAnimalIDInfo();
            pug.GetAnimalIDInfo();

            //INNER CLASS
            Console.WriteLine();

            //call inner class
            //it belongs to the class, not object
            //since it is a helper class
            Animal.AnimalHealthHelp help = new Animal.AnimalHealthHelp();
            Console.WriteLine($"Is my animal healthy? {help.HealthyWeight(11,46)}");

            //VIRTUAL
            Console.WriteLine();

            Animal pug2 = new Dog("Chino", "Foom", "Borkage");

            //doesntshow sound2 because it implements the animal version of makesound.
            //can be mended with 'virtual' in parent class, 'override' in subclass
            //instead of 'new'
            pug2.MakeSound();

            Console.ReadLine();

        }
    }
}
