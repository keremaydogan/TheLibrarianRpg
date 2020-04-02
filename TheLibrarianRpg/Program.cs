using System;

namespace TheLibrarianRpg
{
    class Program
    {
        static void Main(string[] args)
        {
            int[] ints = new int[5];

            ints[2] = 5;

            for(int i =0; i < ints.Length; i++)
            {
                if(ints[i] == 5)
                {
                    ints[i] = 3;
                }

                
            }

            Console.WriteLine(ints[2]);
            Console.ReadKey();
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

        static void Fight(PlayableChar[] pChars, Mob[] mobs)
        {
            int teamSwitch = 1;
            int index = 1;
            bool pcDefeat = true, mobDefeat = true;
            while (pcDefeat && mobDefeat == false){
                switch (teamSwitch){
                    case (1):
                        pChars[(index - 1)/2].Attack(mobs);
                        break;
                    case (2):
                        mobs[index / 2 - 1].Attack(pChars);
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
                mobDefeat = mobs[0] == null;
                pcDefeat = pChars[0] == null;
            }

            //write win lose methods

        }

    }
}
