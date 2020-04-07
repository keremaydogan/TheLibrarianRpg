using System;
using System.Collections.Generic;
using System.Text;

namespace TheLibrarianRpg.TownTemplate
{
    public class Tavern
    {
        public string name;
        public PlayableChar[] mercenary;
        int mercQty;
        public Tavern()
        {
            mercenary = new PlayableChar[mercQty];
            for (int i = 0; i < mercenary.Length; i++)
            {
                mercenary[i] = new PlayableChar();
            }
        }

        public void Menu()
        {
            int entry = 0;
            do
            {
                Console.Clear();
                Console.WriteLine("IIIIII " + name.ToUpper() + " IIIIII");
                


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
