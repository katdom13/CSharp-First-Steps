using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Session008_OOPGame
{
    class Warrior
    {
        public string Name { get; set; } = "Warrior";
        public int MaxHealth { get; set; } = 0;
        public int MaxAttack { get; set; } = 0;
        public int MaxBlock { get; set; } = 0;

        //random generator
        static Random rand = new Random();

        public Warrior()
            : this("Warrior", 0, 0, 0) { }

        public Warrior(string name, int health, int attk, int blk)
        {
            Name = name;
            MaxHealth = health;
            MaxAttack = attk;
            MaxBlock = blk;
        }


        //methods
        public int Attack()
        {
            return rand.Next(1, (int)MaxAttack + 1);
        }

        public int Block()
        {
            return rand.Next(1, (int)MaxBlock + 1);
        }

    }
}
