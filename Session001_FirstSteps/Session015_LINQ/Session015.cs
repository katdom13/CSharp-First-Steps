using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Session015_LINQ
{
    class Session015
    {
        //LINQ is similar to SQL
        //but it can work with other data aside from
        //databases
        static void Main(string[] args)
        {
            QueryIntArray();
            QueryStringArray();
            QueryArrayList();
            QueryCollection();
            QueryAnimalArray();

            Console.ReadLine();
        }

        //query primitive data first

        static int[] QueryIntArray()
        {
            int[] nums = { 5, 10, 15, 20, 25, 30, 35, 40 };

            //get numbers bigger than 20;
            var gt20 = from n in nums
                       where n > 20
                       orderby nums
                       //a prominent difference is that
                       //the select statement is
                       //declared last
                       select n;

            Console.WriteLine("gt20 from QueryIntArray: ");
            foreach (int i in gt20)
            {
                Console.WriteLine(i);    
            }
            Console.WriteLine();

            //what is gt20 type?
            Console.WriteLine("Query type: {0}",
                gt20.GetType());
            //It is an ordered enumerable

            Console.WriteLine();

            //queries can ba converted intro lists
            //or arrays
            var listGT20 = gt20.ToList();
            var arrayGT20 = gt20.ToArray();

            return arrayGT20;

        }

        public static void QueryStringArray()
        {
            string[] dogs =
            {
                "K 9", "Manta", "Chino",
                "Scooby Doo", "Old Yeller",
                "Rin Tin Tin", "Benji", "Charlie B. Barkin",
                "Lassie", "Snoopy"
            };

            //Get string with spaces
            //arrange in alphabetical order

            var query = from d in dogs
                        where d.Contains(" ")
                        orderby d descending
                        select d;

            Console.WriteLine("query from QueryStringArray: ");
            foreach(var i in query)
            {
                Console.WriteLine(i);
            }
            Console.WriteLine();

        }

        //for custom data types
        public static void QueryArrayList()
        {
            ArrayList animals = new ArrayList()
            {
                new Animal("Manta", 18, 8),
                new Animal("Chino", 130, 4),
                new Animal("Bowser", 90, 3.8)
            };

            //convert ArrayList into an Enumerable
            //otherwise you cannot query it
            var animalEnumerable = animals.OfType<Animal>();

            var smAnimals = from a in animalEnumerable
                            where a.Weight <= 90
                            orderby a.Name ascending
                            select a;

            foreach(var i in smAnimals)
            {
                Console.WriteLine($"{i.Name} weighs {i.Weight}" +
                    $" and has a height of {i.Height}");
            }

            Console.WriteLine();

            Console.WriteLine("IEnumerable Type of ArrayList: {0}",
                animalEnumerable.GetType());

            Console.WriteLine();
        }

        public static void QueryCollection()
        {
            List<Animal> animalList = new List<Animal>()
            {
                new Animal("German Shepherd", 77, 25),
                new Animal("Chihuahua", 4.4, 7),
                new Animal("Saint Bernard", 200, 30)
            };

            var bigDogs = from dog in animalList
                          where (dog.Weight > 70) &&
                          (dog.Height > 25)
                          orderby dog.Name
                          select dog;

            foreach(var i in bigDogs)
            {
                Console.WriteLine($"A {i.Name} " +
                    $"weighs {i.Weight} pounds " +
                    $"and has a height of {i.Height} m");
            }
            Console.WriteLine();

        }

        public static void QueryAnimalArray()
        {
            Animal[] animals = new Animal[]
            {
                new Animal{Name = "German Shepherd",
                Height = 25,
                Weight = 77,
                AnimalID = 1},
                new Animal{Name = "Chihuahua",
                Height = 7,
                Weight = 4.4,
                AnimalID = 2},
                new Animal{Name = "Saint Bernard",
                Height = 30,
                Weight = 200,
                AnimalID = 3},
                new Animal{Name = "Pug",
                Height = 12,
                Weight = 16,
                AnimalID = 1},
                new Animal{Name = "Beagle",
                Height = 15,
                Weight = 23,
                AnimalID = 2}
            };

            Owner[] owners = new[]
            {
                new Owner{Name = "Katherine Domingo",
                OwnerID = 1},
                new Owner{Name = "Sally Smith",
                OwnerID = 2},
                new Owner{Name = "Paul Brooks",
                OwnerID = 3}
            };

            //remove name and height
            //specify it in 'select' statement
            var nameHeight = from a in animals
                             select new
                             {
                                 a.Name,
                                 a.Height
                             };

            PrintEnumerable(nameHeight);

            //convert to an object array
            Array arrNameHeight = nameHeight.ToArray();

            Console.WriteLine("Converted to array: ");
            foreach(var i in arrNameHeight)
            {
                Console.WriteLine(i.ToString());
            }
            Console.WriteLine();

            //create an inner join
            //join info in owners and animals
            var join = from a in animals
                       join o in owners
                       on a.AnimalID equals
                       o.OwnerID
                       select new
                       {
                           OwnerName = o.Name,
                           AnimalName = a.Name
                       };

            foreach(var i in join)
            {
                Console.WriteLine($"{i.OwnerName} owns {i.AnimalName}");
            }
            Console.WriteLine();

            //another join
            //elements within elements
            var groupJoin = from o in owners
                            orderby o.OwnerID
                            join a in animals
                            on o.OwnerID equals a.AnimalID
                            into ownerGroup
                            select new
                            {
                                Owner = o.Name,
                                Animals = from animal in ownerGroup
                                          orderby animal.Name
                                          select animal
                            };

            int totalAnimals = 0;
            
            foreach(var x in groupJoin)
            {
                Console.WriteLine(x.Owner);
                foreach(var y in x.Animals)
                {
                    totalAnimals++;
                    Console.WriteLine("* {0}", y.Name);
                }
            }

            //if something is to be the title,
            //it should be on the 'from' statement
            //'foreach' loops is to 'select'
            Console.WriteLine();

            var groupJoin2 = from a in animals
                             orderby a.AnimalID
                             join o in owners on
                             a.AnimalID equals o.OwnerID
                             into animalGroup
                             select new
                             {
                                 Animal = a.Name,
                                 Owners = from o2 in animalGroup
                                         orderby o2.Name
                                         select o2
                             };

            foreach(var i in groupJoin2)
            {
                Console.WriteLine(i.Animal);
                foreach(var j in i.Owners)
                {
                    Console.WriteLine("* {0}", j.Name);
                }
            }

        }

        private static void PrintEnumerable(IEnumerable<object> e)
        {
            foreach (var i in e)
            {
                Console.WriteLine(i.ToString());
            }
            Console.WriteLine();
        }
        
    }
}
