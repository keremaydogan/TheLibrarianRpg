using System;

namespace TheLibrarianRpg
{
    class Program
    {
        static void Main(string[] args)
        {
            for (int i = 0; i < 30; i++)
            {}
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
            int totalXp = mob[0].xpValue + mob[1].xpValue + mob[2].xpValue;
            while (pcDefeat && mobDefeat == false){
                switch (teamSwitch){
                    case (1):
                        pChar[(index - 1)/2].Fight(mob);
                        break;
                    case (2):
                        mob[index / 2 - 1].Fight(pChar);
                        break;
                }
                TeamCompactor(pChar);
                TeamCompactor(mob);
                if (teamSwitch == 1){
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
            //if(mobDefeat)
            //Win(totalXp)
            //else
            //Lose()
            //write win lose methods

        }

        //Check compactor if you want...
        static void TeamCompactor(Character[] chars)
        {
            bool compact = true;
            for(int i = 1; i < chars.Length; i++){
                if(chars[i] != null && chars[i-1] == null){
                    compact = false;
                }
            }
            if (!compact){
                Character[] bridge = new Character[2];
                bridge[0] = new Character();
                bridge[1] = new Character();
                int ind = 0;
                for(int i = 0; i < chars.Length; i++){
                    if (chars[i] != null)
                    {
                        bridge[ind] = chars[i];
                        ind++;
                    }
                }
                bridge[0] = chars[0];
                bridge[1] = chars[0];
            }
            
        }
    }
}
