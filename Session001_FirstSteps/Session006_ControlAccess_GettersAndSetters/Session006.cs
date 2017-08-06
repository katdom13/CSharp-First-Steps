using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Session006_ControlAccess_GettersAndSetters
{
    class Session006
    {
        static void Main(string[] args)
        {
            Animal pug = new Animal();
            pug.SetName("Manta");
            pug.Sound = "Bork";

            pug.MakeSound();

            pug.Owner = "Kat";

            Console.WriteLine("{0}'s owner is {1}.", pug.GetName(), pug.Owner);
            Console.WriteLine("{0}'s ID is {1}.", pug.GetName(), pug.idNum);
            
            Console.WriteLine("Total number of animals: {0}", Animal.NumOfAnimals);

            Console.WriteLine();

            Animal pug2 = new Animal();
            pug2.SetName("Chino");
            pug2.Sound = "Bark";

            pug2.MakeSound();

            pug2.Owner = "Kat";

            Console.WriteLine("{0}'s owner is {1}.", pug2.GetName(), pug2.Owner);
            Console.WriteLine("{0}'s ID is {1}.", pug2.GetName(), pug2.idNum);

            Console.WriteLine("Total number of animals: {0}", Animal.NumOfAnimals);

            Console.WriteLine();

            Animal fox = new Animal() {
                name = "Nick",
                sound = "Rawrr",
                Owner = "Judy"
            };

            fox.MakeSound();

            Console.WriteLine("{0}'s owner is {1}.", fox.GetName(), fox.Owner);
            Console.WriteLine("{0}'s ID is {1}.", fox.GetName(), fox.idNum);

            Console.WriteLine("Total number of animals: {0}", Animal.NumOfAnimals);

            Console.WriteLine();

            Animal bunny = new Animal();

            bunny.SetName("Judy");
            bunny.Sound = "Scronch";

            bunny.MakeSound();

            Console.WriteLine("{0}'s owner is {1}.", bunny.GetName(), bunny.Owner);
            Console.WriteLine("{0}'s ID is {1}.", bunny.GetName(), bunny.idNum);

            Console.WriteLine("Total number of animals: {0}", Animal.NumOfAnimals);

            Console.WriteLine();

            Animal copyOfManta = new Animal(pug);
            copyOfManta.SetName("Manta2");

            Console.WriteLine("{0}'s owner is {1}.", copyOfManta.GetName(), copyOfManta.Owner);
            Console.WriteLine("{0}'s ID is {1}.", copyOfManta.GetName(), copyOfManta.idNum);

            Console.WriteLine("Total number of animals: {0}", Animal.NumOfAnimals);

            Console.ReadLine();

        }
    }
}
