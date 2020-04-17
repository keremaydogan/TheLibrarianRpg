using System;
using System.Collections.Generic;
using System.Text;

namespace TheLibrarianRpg
{
    public class Protagonist
    {
        public string name;
        public int wallet;
        public PlayableChar[] mercenary;

        public bool buyItem;

        int entry;

        public Protagonist()
        {
            mercenary = new PlayableChar[3];
        }

        public void Menu()
        {
            Console.WriteLine("IIII Librarian IIII\nWallet: " + wallet + "coins\n1) Map\n2) To-do list\n3) Mercenaries (" + MercArrLen() +")");
        }

        public void BuyMerc()
        {

        }

        public void PartWMerc()
        {

        }

        public void BuyItem(Item newItem)
        {
            Console.WriteLine("Choose mercenary.");
            for(int i = 0; i < MercArrLen(); i++){
                Console.WriteLine((i + 1) + ") " + mercenary[i].name);
            }
            entry = ReadNumber(0, MercArrLen());
            if(entry != 0 && mercenary[entry - 1].inventory.Length == mercenary[entry - 1].InventLen())
            {
                Console.WriteLine();
            }else if(entry != 0){
                mercenary[entry - 1].TakeItem(newItem);
            }
        }

        public void SellItem()
        {

        }

        public int MercArrLen()
        {
            int arrayLen = -1;
            for (int i = 0; i < mercenary.Length && arrayLen == 1; i++)
            {
                if (mercenary[i] == null)
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
