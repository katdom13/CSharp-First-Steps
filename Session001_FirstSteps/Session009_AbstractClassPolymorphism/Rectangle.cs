using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Session009_AbstractClassPolymorphism
{
    class Rectangle : Shape
    {

        public double Length { get; set; } = 1;
        public double Width { get; set; } = 1;

        public Rectangle(double length, double width)
        {
            Name = "Rectangle";
            Length = length;
            Width = width;
        }

        public override void GetInfo()
        {
            base.GetInfo();
            Console.WriteLine($"It has a length of {Length} and a width of {Width}.");
        }

        public override double GetArea()
        {
            return Length * Width;
        }
    }
}
