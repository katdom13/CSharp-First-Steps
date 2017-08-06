using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Session005_ClassesAndOOP
{
    class Session005
    {
        static void Main(string[] args)
        {

            //STRUCTS
            Rectangle r1;
            r1.length = 200;
            r1.width = 50;
            PrintArea(r1);
            //doesn't execute auto increment # of rectangles because of 'no initialization'

            Rectangle r2 = new Rectangle();
            r2.length = 100;
            r2.width = 50;
            PrintArea(r2);
            //doesn't execute auto increment # of rectangles because of 'default initialization'

            Rectangle r3 = new Rectangle(200, 50);
            PrintArea(r3);

            Rectangle r4 = new Rectangle(100, 50);
            PrintArea(r4);

            r4 = r3;
            r3.length = 100;

            PrintArea(r4);

            Console.WriteLine("R4 Length: {0}", r4.length);

            //structs are 'pass by reference'

            //CLASSES
            Console.WriteLine();

            Animal dog = new Animal()
            {
                name = "Manta",
                sound = "Bork"
            };

            dog.MakeSound();
            Console.WriteLine("# of Animals: {0}", Animal.GetNumAnimals());
            Console.WriteLine();

            Animal fox = new Animal("Nick", "Raww");
            fox.MakeSound();
            Console.WriteLine("# of Animals: {0}", Animal.GetNumAnimals());
            Console.WriteLine();

            fox = dog;

            fox.MakeSound();
            Console.WriteLine("# of Animals: {0}", Animal.GetNumAnimals());
            Console.WriteLine();

            dog.name = "Chino";
            
            Console.WriteLine(fox.name);

            //classes are 'pass by reference'
            //workaround in third constructor of Animals
            Console.WriteLine();

            fox = new Animal(dog);

            dog.name = "Manta";
            Console.WriteLine(fox.name);
            Console.WriteLine();
            Console.WriteLine("Current # of animals: {0}", Animal.GetNumAnimals());

            //STATIC UTILITY CLASS
            Console.WriteLine();
            Console.WriteLine("Area of circle: {0}", ShapeMath.GetArea("circle", 2,2));

            Console.ReadLine();
        }

        static void PrintArea(Rectangle r)
        {
            Console.WriteLine("Area of {0}: {1}", r.GetType().Name, r.Area());
            Console.WriteLine("# of rectangles: {0}", Rectangle.GetNumOfRectangles());
            Console.WriteLine();
        }

        //STRUCTS
        struct Rectangle
        {
            public double length;
            public double width;
            
            //structs can't have parameterless constructors
            
            public Rectangle(double length = 1, double width = 1)
            {
                this.length = length;
                this.width = width;
                ++numOfRectangles;
            }

            public double Area()
            {
                return length * width;
            }

            static int numOfRectangles = 0;

            public static int GetNumOfRectangles()
            {
                return numOfRectangles;
            }

        }

    }
}
