using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Session014_OperatorOverloadingEnumarable
{
    class Session014
    {
        static void Main(string[] args)
        {
            //ENUMERABLE
            //test own enumerable

            //Create an animalFarm object
            AnimalFarm animals = new AnimalFarm();

            //add animals array style
            //this is because of implementing
            //IEnumerable interface
            animals[0] = new Animal("Manta");
            animals[1] = new Animal("Chino");
            animals[2] = new Animal("Saxony");
            animals[3] = new Animal("Charlotte");

            //iterate via foreach
            Console.WriteLine("In animal list: ");
            foreach (Animal a in animals)
            {
                Console.WriteLine(a.Name);
            }
            Console.WriteLine();

            //OPERATOR OVERLOADING

            Console.ReadLine();

        }
    }
}
