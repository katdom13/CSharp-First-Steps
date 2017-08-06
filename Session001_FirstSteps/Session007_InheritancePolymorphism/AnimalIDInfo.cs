using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Session007_InheritancePolymorphism
{
    class AnimalIDInfo
    {
        private static Random rand = new Random();

        public int IDNum { get; set; } = rand.Next(1, int.MaxValue);
        public string Owner { get; set; } = "No owner";
    }
}
