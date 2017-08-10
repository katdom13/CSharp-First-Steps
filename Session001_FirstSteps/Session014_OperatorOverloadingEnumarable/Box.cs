using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Session014_OperatorOverloadingEnumarable
{
    //this class is going to be used
    //as ana example for operator overloading
    class Box
    {
        public double Height { get; set; }
        public double Width { get; set; }
        public double Breadth { get; set; }

        public Box()
            : this(1, 1, 1) { }

        public Box(int height, int length, int breadth)
        {
            Height = height;
            Width = Width;
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
                Width = box1.Width + box2.Width,
                Breadth = box1.Breadth + box2.Breadth
            };

            return totalBox;
        }

        public static Box operator -(Box box1, Box box2)
        {
            Box diffBox = new Box()
            {
                Height = box1.Height - box2.Height,
                Width = box1.Width - box2.Width,
                Breadth = box1.Breadth - box2.Breadth
            };
            return diffBox;
        }

        //== overloading requires != counterpart
        public static bool operator ==(Box box1, Box box2)
        {
            if ((box1.Height == box2.Height) &&
                (box1.Width == box2.Width) &&
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
                (box1.Width != box2.Width) ||
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
            return $"Box with height:{Height}, width:{Width}, breadth:{Breadth}";
        }

    }
}
