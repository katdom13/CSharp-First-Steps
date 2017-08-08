using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Session012_GenericsAndDelegates
{
    class Animal
    {
        public string Name { get; set; }

        public Animal(string name = "No name")
        {
            Name = name;
        }

        //override of tostring()
        //like in java
        public override string ToString()
        {
            return Name;
        }

        //static generic methods
        public static void GetSum<T>(T num1, T num2)
        {
            double dblX = Convert.ToDouble(num1);
            double dblY = Convert.ToDouble(num2);
            Console.WriteLine($"{dblX} + {dblY} = {dblX + dblY}");
        }

        public static void Swap<T>(ref T num1, ref T num2)
        {
            T temp = num1;
            num1 = num2;
            num2 = temp;
        }

    }
}
