using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Session008_OOPGame
{
    class Battle
    {
        public static void StartFight(Warrior w1, Warrior w2)
        {
            Console.WriteLine("Get ready...");

            Console.WriteLine("Warrior Stats");

            Console.WriteLine();

            Console.WriteLine($"Warrior name: {w1.Name}\n" +
                $"Max Health: {w1.MaxHealth}\n" +
                $"Attack: {w1.MaxAttack}\n" +
                $"Block: {w1.MaxBlock}");
            Console.WriteLine();
            Console.WriteLine($"Warrior name: {w2.Name}\n" +
                $"Max Health: {w2.MaxHealth}\n" +
                $"Attack: {w2.MaxAttack}\n" +
                $"Block: {w2.MaxBlock}\n");

            while (true)
            {

                if (GetGameStats(w1, w2) == (byte)GameStatus.Game_Over)
                {
                    break;
                }
                if (GetGameStats(w2, w1) == (byte)GameStatus.Game_Over)
                {
                    break;
                }
            }

        }

        public static byte GetGameStats(Warrior a, Warrior b)
        {
            //attack
            int attack = a.Attack();
            int block = b.Block();
            //calculate damage
            int dmg = attack - block;

            if (dmg > 0)
            {
                b.MaxHealth = b.MaxHealth - dmg;
            }
            else dmg = 0;

            //print all events
            Console.WriteLine($"{a.Name} deals {dmg} damage.\n" +
                $"{b.Name} has {b.MaxHealth} HP.\n");

            //check status
            if (b.MaxHealth <= 0)
            {
                Console.WriteLine($"{b.Name} has died. {a.Name} emerges victorious.\n" +
                    $"Game Over");
                return (byte)GameStatus.Game_Over;
            }
            else return (byte)GameStatus.Continue;
            //repeat
        }

        enum GameStatus: byte
        {
            Continue = 0,
            Game_Over = 1
        }

    }
}
