using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Session005_ClassesAndOOP
{
    //static classes can be made by adding 'static' to a class
    //static classes can house static methods and static values ONLY.
    //they are great for helper classes.
    public static class ShapeMath
    {
        public static double GetArea(string shape = "",
            double length1 = 0, double length2 = 0)
        {

            if (String.Equals(shape, "Rectangle", StringComparison.OrdinalIgnoreCase))
            {
                return length1 * length2;
            }else if (String.Equals(shape, "Triangle", StringComparison.OrdinalIgnoreCase))
            {
                return length1 * (length2 / 2);
            }else if (String.Equals(shape, "Circle", StringComparison.OrdinalIgnoreCase))
            {
                return 3.14159 * Math.Pow(length1, 2);
            }
            else
            {
                return -1;
            }

        }
    }
}
