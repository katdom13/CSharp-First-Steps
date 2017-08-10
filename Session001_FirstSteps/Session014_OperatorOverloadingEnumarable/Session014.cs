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

            //get type
            Console.WriteLine("AnimalFarm Type: {0}",
                animals.GetType());
            Console.WriteLine();
            //it is its own type

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
            Box box1 = new Box();
            Box box2 = new Box(2, 3, 4);

            //no need to access parts of box
            //for adding
            Box box3 = box1 + box2;
            Console.WriteLine("Box 1 + Box 2: {0}", box3);

            box3 = box1 - box2;
            Console.WriteLine("Box 1 - Box 2: {0}", box3);

            bool isEqual = box1 != box2;

            Console.WriteLine("Box1 != Box2 : {0}", isEqual);

            Box box4 = new Box();

            isEqual = box1 == box4;

            Console.WriteLine("Box1 == Box4 : {0}", isEqual);

            Console.ReadLine();

        }
    }
}
