﻿using System;
using System.Collections.Generic;
using System.Text;

namespace TheLibrarianRpg
{
    public class Outskirts
    {
        Mob[] mob;
        public Outskirts()
        {
            mob = new Mob[] { };
            for(int i = 0; i < mob.Length; i++)
            {
                mob[i] = new Mob();
            }
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
