using System;

namespace TheLibrarianRpg
{
    class Program
    {
        static void Main(string[] args)
        {



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
            }

            //write win lose methods

        }

    }
}
