using System;
using System.Collections.Generic;
using System.Text;

namespace TheLibrarianRpg
{
    public class Store
    {
        public string stName;
        public Armor[] stArmor;
        public Accessory[] stAccessory;
        public Weapon[] stWeapon;

        public Store()
        {
            stArmor = new Armor[8];
            stAccessory = new Accessory[8];
            stWeapon = new Weapon[8];
        }

        public void Menu()
        {
            int entry = 0;
            do
            {
                Console.Clear();
                Console.WriteLine("IIIIII " + stName.ToUpper() + " IIIIII");
                Console.WriteLine("1) Buy\n2) Sell");
                Console.WriteLine("(0 to back)");
                entry = ReadNumber(0, 2);
                if (entry == 1)
                {
                    Console.Clear();
                    Console.WriteLine("IIIIII " + stName.ToUpper() + " IIIIII");
                    Console.WriteLine("1) Armor\n2) Weapon\n3) Accessory\n4) Consumable");
                    Console.WriteLine("(0 to back)");
                    entry = ReadNumber(0, 3);
                    Console.Clear();
                    Console.WriteLine("IIIIII " + stName.ToUpper() + " IIIIII");
                    switch (entry)
                    {
                        case (1):
                            SellGoods(stArmor);
                            break;
                        case (2):
                            SellGoods(stWeapon);
                            break;
                        case (3):
                            SellGoods(stAccessory);
                            break;
                    }
                    entry = 1;
                }
                else if (entry == 2)
                {


                    entry = 2;
                }

                

            } while (entry != 0);
        }

        public void ShowGoods(Item[] items)
        {
            Console.WriteLine(items[0].GetType().ToString().ToUpper());
            for (int i = 0; i < StArrayLen(items); i++){
                Console.WriteLine((i + 1) + ") " + items[i].name);
            }
        }

        void SellGoods(Item[] items)
        {
            int entry;
            ShowGoods(items);
            Console.WriteLine("Choose item:");
            entry = ReadNumber(0, StArrayLen(items));
            if (entry != 0)
            {

            }    
        }

        public int StArrayLen(Item[] array)
        {
            int arrayLen = -1;
            for(int i = 0; i < array.Length && arrayLen == 1; i++)
            {
                if(array[i] == null)
                {
                    arrayLen = i;
                }
            }
            return arrayLen;
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
