using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Session015_LINQ
{
    class Animal
    {
        public string Name { get; set; }
        public double Weight { get; set; }
        public double Height { get; set; }
        public int AnimalID { get; set; }

        public Animal(string name = "No name",
            double weight = 0,
            double height = 0)
        {
            Name = name;
            Weight = weight;
            Height = height;
        }

        public override string ToString()
        {
            return
                $"Name: {Name}\n" +
                $"Weight: {Weight}\n" +
                $"Height: {Height}\n" +
                $"AnimalID: {AnimalID}\n";
        }

    }
}
