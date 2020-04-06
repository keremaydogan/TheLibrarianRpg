﻿using System;
using System.Collections.Generic;
using System.Text;

namespace TheLibrarianRpg.TownTemplate
{
    public class Store
    {
        public string name;
        public Item[] items;
        public Store(string name, int itemQty)
        {
            this.name = name;
            items = new Item[itemQty];
        }

        public void Menu()
        {
            int entry = 0;
            do
            {
                Console.Clear();



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