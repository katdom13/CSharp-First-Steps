using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Session008_OOPGame
{
    class Session008
    {
        static void Main(string[] args)
        {
            Warrior w1 = new Warrior("Max", 1000, 120, 40);
            Warrior w2 = new Warrior("Bob", 1000, 120, 40);

            Battle.StartFight(w1, w2);

            Console.ReadLine();

        }
    }
}
