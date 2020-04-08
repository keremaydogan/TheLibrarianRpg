using System;
using System.Collections.Generic;
using System.Text;

namespace TheLibrarianRpg.TownTemplate
{
    public class Store
    {
        public string name;
        public Armor[] armor;
        public int armorQty;
        public Consumable[] consumable;
        public int consQty;
        public Accessory[] accessory;
        public int acsQty;
        public Weapon[] weapon;
        public int weaponQty;

        public Store()
        {
            armor = new Armor[armorQty];
            consumable = new Consumable[consQty];
            accessory = new Accessory[acsQty];
            weapon = new Weapon[weaponQty];
        }

        public void Menu()
        {
            int entry = 0;
            do
            {
                Console.Clear();
                Console.WriteLine("IIIIII " + name.ToUpper() + " IIIIII");
                Console.WriteLine("1) Armor\n2) Weapon\n3) Accessory\n4) Consumable");
                entry = ReadNumber(0, 4);
                ShowGoods(entry);
                

            } while (entry != 0);
        }

        public void ShowGoods(int entry)
        {
            switch (entry)
            {
                case (1):
                    Console.WriteLine("Armors:");
                    for (int i = 0; i < armor.Length; i++){
                        Console.WriteLine((i + 1) + ") " + armor[i].name);
                    }
                    break;
                case (2):
                    Console.WriteLine("Weapons:");
                    for (int i = 0; i < weapon.Length; i++){
                        Console.WriteLine((i + 1) + ") " + weapon[i].name);
                    }
                    break;
                case (3):
                    Console.WriteLine("Accessories:");
                    for (int i = 0; i < accessory.Length; i++){
                        Console.WriteLine((i + 1) + ") " + accessory[i].name);
                    }
                    break;
                case (4):
                    Console.WriteLine("Consumables:");
                    for (int i = 0; i < consumable.Length; i++){
                        Console.WriteLine((i + 1) + ") " + consumable[i].name);
                    }
                    break;
            }
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
