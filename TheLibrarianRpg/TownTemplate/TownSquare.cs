using System;
using System.Collections.Generic;
using System.Text;

namespace TheLibrarianRpg
{
    public class TownSquare
    {
        public string name;
        public string townDesc;

        public string taName;
        public string taDesc;
        public PlayableChar[] taMercenary;
        int taMercQty;

        public string stName;
        public Armor[] stArmor;
        public Consumable[] stConsumable;
        public Accessory[] stAccessory;
        public Weapon[] stWeapon;

        public Outskirts outskirts;

        public Protagonist librarian;

        public TownSquare(string name, Tavern tavern, Store store)
        {
            this.name = name;

            librarian = new Protagonist();

            //Tavern
            taMercenary = new PlayableChar[taMercQty];
            for (int i = 0; i < taMercenary.Length; i++)
            {
                taMercenary[i] = new PlayableChar();
            }

            //Store
            stArmor = new Armor[8];
            stConsumable = new Consumable[8];
            stAccessory = new Accessory[8];
            stWeapon = new Weapon[8];

            //Outskirts
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
                Console.WriteLine("1) {0}\n2) {1}\n3) {2}\n4) To another city", taName, stName, "");
                entry = ReadNumber(0, 4);
                
                switch (entry)
                {
                    case (1):
                        Tavern();
                        break;
                    case (2):
                        Store();
                        break;
                    case (3):
                        //Buraya yetkili bi abi modülü veya bölümü geçmek için şart olan dungeon modülünü koyabilirsin
                        break;
                    case (4):

                        break;
                }
                
            } while(entry != 0);
        }

        public void Tavern()
        {
            int entry = 0;
            do
            {
                Console.Clear();
                Console.WriteLine("IIIIII " + taName.ToUpper() + " IIIIII");



            } while (entry != 0);
        }
        public void Store()
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
                    entry = ReadNumber(0, 4);
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
                        case (4):
                            SellGoods(stConsumable);
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
        void SellGoods(Item[] items)
        {
            int entry;
            ShowGoods(items);
            Console.WriteLine("Choose item:");
            entry = ReadNumber(0, StArrayLen(items));
            if (entry != 0)
            {
                if(librarian.wallet < items[entry - 1].price)
                {
                    Console.WriteLine("You don't have enough money.");
                    Console.ReadKey();
                }

                librarian.BuyItem(items[entry - 1]);
            }
        }
        public void ShowGoods(Item[] items)
        {
            Console.WriteLine(items[0].GetType().ToString().ToUpper());
            for (int i = 0; i < StArrayLen(items); i++)
            {
                Console.WriteLine((i + 1) + ") " + items[i].name);
            }
        }
        public int StArrayLen(Item[] array)
        {
            int arrayLen = -1;
            for (int i = 0; i < array.Length && arrayLen == -1; i++)
            {
                if (array[i] == null)
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
