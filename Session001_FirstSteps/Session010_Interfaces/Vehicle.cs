using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Session010_Interfaces
{

    //Interfaces are implemented by adding ':'
    //like extending a class
    //except multiple interfaces are allowed
    class Vehicle : IDrivable
    {
        //observe how an interface does not really need the override method.

        public Vehicle(string brand = "No Brand", int wheels = 0, int speed = 0)
        {
            Brand = brand;
            Wheels = wheels;
            Speed = speed;
        }

        //exclusive for vehicles
        public string Brand { get; set; }

        public int Wheels { get; set; }
        public double Speed { get; set; }

        public void Move()
        {
            Console.WriteLine($"The {Wheels}-wheeled {Brand} moves fast with a speed of " +
                $"{Speed} MPH.");
        }

        public void Stop()
        {
            Console.WriteLine($"The {Brand} stops.");
        }
    }
}
