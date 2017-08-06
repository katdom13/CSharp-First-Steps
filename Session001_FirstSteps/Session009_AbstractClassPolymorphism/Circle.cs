using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Session009_AbstractClassPolymorphism
{
    class Circle : Shape
    {
        public double Radius { get; set; } = 1;
        
        public Circle(double radius)
        {
            Name = "Circle";
            Radius = radius;
        }

        //overridden method GetInfo
        public override void GetInfo()
        {
            base.GetInfo();
            Console.WriteLine($"It has a radius of {Radius}.");
        }

        //overridden abstract method
        public override double GetArea()
        {
            return Math.PI * (Math.Pow(Radius, 2.0));
        }
    }
}
