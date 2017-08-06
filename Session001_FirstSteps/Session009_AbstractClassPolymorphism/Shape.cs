using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Session009_AbstractClassPolymorphism
{
    //Abstarct classes cannot be instantiated
    //because they are vague
    abstract class Shape
    {
        public string Name { get; set; } = "Shape";
        
        public virtual void GetInfo()
        {
            Console.WriteLine($"This is a {Name}");
        }

        //abstract methods are only meant to be overridden
        //and they are required
        public abstract double GetArea();

    }
}
