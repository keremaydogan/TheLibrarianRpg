using System;
using System.Collections.Generic;
using System.Text;

namespace TheLibrarianRpg.TownTemplate
{
    public class Store
    {
        public string name;
        public Item[] goods;
        int itemQty;
        public Store()
        {
            goods = new Item[itemQty];
            for (int i = 0; i < goods.Length; i++)
            {
                goods[i] = new Item();
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
