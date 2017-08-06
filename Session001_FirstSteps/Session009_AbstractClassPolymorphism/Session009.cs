using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Session009_AbstractClassPolymorphism
{
    class Session009
    {
        static void Main(string[] args)
        {
            Shape[] shapes = new Shape[] {
                new Circle(5.0),
                new Rectangle(4.0, 5.0)
            };
            
            //see the polymorphism
            foreach(Shape s in shapes)
            {
                s.GetInfo();
                Console.WriteLine("{0} area: {1:f3}", s.Name,s.GetArea());

                //is and as
                //are like 'instanceof' in java
                //but observe the difference
                Circle c = s as Circle;
                if (c == null)
                {
                    Console.WriteLine("This is not a circle.");
                }

                if (s is Circle)
                {
                    Console.WriteLine("This is a circle.");
                }

                Console.WriteLine();

            }

            //BASE TYPECASTING
            Console.WriteLine();

            Object c1 = new Circle(5.0);
            Circle c2 = (Circle)c1;
            c2.Radius = 4.0;

            //wont be able to get c1's area because it is an object type
            //must be casted as circle first
            Console.WriteLine("C1 has area of {0:f3}", ((Circle)c1).GetArea());

            Console.ReadLine();

        }
    }
}
