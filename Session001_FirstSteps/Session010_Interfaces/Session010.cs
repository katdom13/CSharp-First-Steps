using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Session010_Interfaces
{
    class Session010
    {
        static void Main(string[] args)
        {
            //Basic use of interface
            Vehicle buick = new Vehicle("Buick", 4, 120);

            //check if buick implements IDrivable
            //similar to checking if a class is an instance of a parent class
            if (buick is IDrivable)
            {
                buick.Move();
                buick.Stop();
            }
            else
            {
                Console.WriteLine("This {0} is not drivable", buick.Brand);
            }

            //MORE COMPLEX IMPLEMENTATION
            Console.WriteLine();

            IElectronicDevice TV = TVRemote.GetDevice();
            PowerButton powButton = new PowerButton(TV);

            powButton.Execute();
            powButton.Undo();

            Console.WriteLine();

            IElectronicDevice TV2 = new Television(80);
            VolumeButton volButton = new VolumeButton(TV2);

            volButton.Execute();
            volButton.Undo();

            if(TV2 is IElectronicDevice)
            {
                powButton = new PowerButton(TV2);
                powButton.Undo();
            }

            Console.ReadLine();

        }
    }
}
