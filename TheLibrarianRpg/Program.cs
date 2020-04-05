using System;

namespace TheLibrarianRpg
{
    class Program
    {
        static void Main(string[] args)
        {
            Random rand = new Random();
            for(int i = 0; i < 30; i++)
            {
                float f = rand.Next(-11, +10);
                Console.WriteLine(f);
                f = f * 0.01F + 1;
                Console.WriteLine(f);
                f = f * 50;
                f = MathF.Ceiling(f);
                Console.WriteLine("=== " + f);
            }
            
            Console.ReadLine();

        }

        static int ReadNumber(int min, int max)
        {
            int num;
            string entry = Console.ReadLine();
            while (!int.TryParse(entry, out num) || num < min || num > max)
            {
                Console.WriteLine("[INVALID ENTRY]");
                entry = Console.ReadLine();
            }
            return num;
        }

        static void Fight(PlayableChar[] pChar, Mob[] mob)
        {
            int teamSwitch = 1;
            int index = 1;
            bool pcDefeat = true, mobDefeat = true;
            while (pcDefeat && mobDefeat == false){
                switch (teamSwitch){
                    case (1):
                        pChar[(index - 1)/2].Fight(mob);
                        break;
                    case (2):
                        mob[index / 2 - 1].Fight(pChar);
                        break;
                }

                //Find a solution for compacting char lists.
                //A = alive   0 = Dead
                // A0A => AA0   or   0A0 => A00

                if(teamSwitch == 1){
                    teamSwitch = 2;
                }else{
                    teamSwitch = 1;
                }
                if(index == 6){
                    index = 0;
                }
                index++;
                mobDefeat = mob[0] == null;
                pcDefeat = pChar[0] == null;
                Console.WriteLine("\nPress any key to continue.");
                Console.ReadKey();
            }

            //write win lose methods

        }

    }
}
