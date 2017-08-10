using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Session014_OperatorOverloadingEnumarable
{
    //this class is going to be used
    //as an example for operator overloading
    class Box
    {
        public double Height { get; set; }
        public double Length { get; set; }
        public double Breadth { get; set; }

        public Box()
            : this(1, 1, 1) { }

        public Box(int height, int length, int breadth)
        {
            Height = height;
            Length = length;
            Breadth = breadth;
        }

        //With operator overloading
        //you can customize the function of certain operators
        //like +, -, *, /, %
        //!, ==, !=, >, <, >=, <=, ++ and --

        //overloading operators
        //take operators as method names
        //just add 'operator' after return type

        //it is also static because it belongs to the whole class
        //not the object
        public static Box operator +(Box box1, Box box2)
        {
            Box totalBox = new Box()
            {
                Height = box1.Height + box2.Height,
                Length = box1.Length + box2.Length,
                Breadth = box1.Breadth + box2.Breadth
            };

            return totalBox;
        }

        public static Box operator -(Box box1, Box box2)
        {
            Box diffBox = new Box()
            {
                Height = box1.Height - box2.Height,
                Length = box1.Length - box2.Length,
                Breadth = box1.Breadth - box2.Breadth
            };
            return diffBox;
        }

        //== overloading requires != counterpart
        public static bool operator ==(Box box1, Box box2)
        {
            if ((box1.Height == box2.Height) &&
                (box1.Length == box2.Length) &&
                (box1.Breadth == box2.Breadth))
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        public static bool operator !=(Box box1, Box box2)
        {
            if ((box1.Height != box2.Height) ||
                (box1.Length != box2.Length) ||
                (box1.Breadth != box2.Breadth))
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        //somewhere in the previous exercises, I also covered how
        //to override the ToString() method
        public override string ToString()
        {
            return $"Box with height:{Height}, length:{Length}, breadth:{Breadth}";
        }

    }
}
