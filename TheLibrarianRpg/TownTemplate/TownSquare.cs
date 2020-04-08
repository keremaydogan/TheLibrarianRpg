using System;
using System.Collections.Generic;
using System.Text;

namespace TheLibrarianRpg.TownTemplate
{
    public class TownSquare
    {
        public string name;
        public string townDesc;

        public Tavern tavern;

        public Store store;

        public Outskirts outskirts;

        public TownSquare(string name, Protagonist protagonist)
        {
            this.name = name;

            tavern = new Tavern(protagonist);

            store = new Store(protagonist);

            outskirts = new Outskirts();
        }

        public void Menu()
        {
            int entry = 0;
            do
            {
                Console.Clear();
                Console.WriteLine(name.ToUpper());
                Console.WriteLine(townDesc);
                Console.WriteLine("Where do you want to go?");
                entry = ReadNumber(0, 4);
                Console.WriteLine("1) {0}\n2) {1}\n3) {2}\n4) To another city", tavern.name, store.name);
                switch (entry)
                {
                    case (1):
                        tavern.Menu();
                        break;
                    case (2):
                        store.Menu();
                        break;
                    case (3):
                        //Buraya yetkili bi abi modülü veya bölümü geçmek için şart olan dungeon modülünü koyabilirsin
                        break;
                    case (4):

                        break;
                }
                
            } while(entry != 0);
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
