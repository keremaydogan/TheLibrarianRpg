using System;
using System.Collections.Generic;
using System.Text;

namespace TheLibrarianRpg
{
    public class Tavern
    {
        public string taName;
        public string taDesc;
        public PlayableChar[] taMercenary;
        int taMercQty;
        public Tavern()
        {
            taMercenary = new PlayableChar[taMercQty];
            for (int i = 0; i < taMercenary.Length; i++)
            {
                taMercenary[i] = new PlayableChar();
            }
        }

        public void Menu()
        {
            int entry = 0;
            do
            {
                Console.Clear();
                Console.WriteLine("IIIIII " + taName.ToUpper() + " IIIIII");
                


            } while (entry != 0);
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
    }
}
