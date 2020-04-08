using System;
using System.Collections.Generic;
using System.Text;

namespace TheLibrarianRpg.Characters
{
    public class Protagonist
    {
        public string name;
        public int wallet;
        public PlayableChar[] mercenary;

        public Protagonist()
        {
            name = "Librarian";
            mercenary = new PlayableChar[3];
        }

        public void Store(byte transaction)
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

    }
}
