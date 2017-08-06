using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Session007_InheritancePolymorphism
{
    //Dog is an Animal
    class Dog : Animal
    {
        public string Sound2 { get; set; } = "Bork";

        public Dog(string name="No name", string sound="No sound", string sound2 = "Bork")
            : base(name, sound)
        {
            Sound2 = sound2;
        }

        //new is default for overriding
        //override is for virtual methods
        public override void MakeSound()
        {
            Console.WriteLine($"{Name} says {Sound} and {Sound2}");
            
            //protected fields can be changed and accessed directly in subclasses
            //unlike private

            //OK
            //this.sound = "BorkBork";

            //Not OK
            //this.name = "Beemo";
        }

    }
}
