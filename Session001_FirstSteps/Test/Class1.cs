using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Test
{
    public static class Class1
    {
        private static Random rand = new Random();
        public static int GenerateRandom()
        {
            return rand.Next(1, 11);
        }
    }
}
