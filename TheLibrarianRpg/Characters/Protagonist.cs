using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;

namespace TheLibrarianRpg
{
    public class Protagonist
    {
        public string name;
        public int wallet;
        public PlayableChar[] mercenary;

        public bool buyItem;

        int entry;

        //SellItem
        public Item selctdItem;
        int mercId;
        int sellItem;

        public Protagonist()
        {
            mercenary = new PlayableChar[3];
        }

        public void Menu()
        {
            entry = 1;
            while (entry == 0){
                Console.WriteLine("IIII Librarian IIII\nWallet: " + wallet + " coins\n1) Map\n2) To-do list\n3) Mercenaries (" + MercArrLen() + ")");
                entry = ReadNumber(0, 3);
                switch (entry)
                {
                    case (1):
                        Map();
                        break;
                    case (2):
                        Quests();
                        break;
                    case (3):
                        MercsMenu();
                        break;
                    case (0):
                        Console.WriteLine("Are you sure? (0: yes, any other answer: no)");
                        entry = ReadNumber(int.MinValue, int.MaxValue);
                        if (entry == 0){
                            Environment.Exit(0);
                        }
                        break;
                }
            }
        }

        void Map()
        {

        }

        void Quests()
        {

        }
        public void BuyMerc(PlayableChar newMerc)
        {
            mercenary[2] = newMerc;
            MercCompactor();
        }

        public void DismissMerc()
        {
            int merc;
            Console.WriteLine("Choose mercenary:");
            merc = ReadNumber(1, MercArrLen()) - 1;
            Console.WriteLine("Are you sure about dismiss " + mercenary[merc].name + "?");
            Console.WriteLine("(1: yes, any other answer: no)");
            if (entry == 1)
            {
                mercenary[merc] = null;
                MercCompactor();
                Console.WriteLine("Done.");
            }
            entry = 1;
            Console.ReadKey();
        }

        public void BuyItem(Item newItem)
        {
            Console.WriteLine("Choose mercenary: (0 to back)");
            for(int i = 0; i < MercArrLen(); i++){
                Console.WriteLine((i + 1) + ") " + mercenary[i].name);
            }
            entry = ReadNumber(0, MercArrLen());
            if(entry != 0 && mercenary[entry - 1].inventory.Length == mercenary[entry - 1].InventLen()){
                Console.WriteLine(mercenary[entry - 1].name + " don't have space for item.");
                Console.ReadKey();
            }else if(entry != 0){
                wallet -= newItem.price;
                mercenary[entry - 1].TakeItem(newItem);
            }
        }

        public void SellItem()
        {
            SelectItem();
            Console.WriteLine("Do you want to sell " + mercenary[mercId].inventory[sellItem].name + "?");
            Console.WriteLine("(1: yes, any other answer: no)");
            entry = ReadNumber(int.MinValue, int.MaxValue);
            if (entry == 1){
                
                wallet += mercenary[mercId].inventory[sellItem].price / 2;
                mercenary[mercId].RemoveItem(sellItem);
            }
        }

        public void SelectItem()
        {
            Console.WriteLine("Choose mercenary:");
            mercId = ReadNumber(1, MercArrLen()) - 1;
            mercenary[mercId].ShowInventory(typeof(TheLibrarianRpg.Item));
            Console.WriteLine("Select item to sell:");
            sellItem = ReadNumber(1, mercenary[mercId].InventLen()) - 1;
            selctdItem = mercenary[mercId].inventory[sellItem];
        }

        void ShowMercs()
        {
            for (int i = 0; i < MercArrLen(); i++)
            {
                Console.WriteLine(mercenary[i].fightScreenDef());
            }
        }

        void MercsMenu()
        {
            int merc1;
            int merc2;
            int item1;
            int item2;
            Item bridge = new Item();
            int medpCheck;
            bool medpAvbl; //Medpack available
            int[] validIds = new int[3]; 
            do
            {
                medpAvbl = false;
                medpCheck = 0;
                for(int i = 0; i < MercArrLen(); i++){
                    medpCheck += mercenary[i].medPack;
                }
                if(medpCheck > 0){
                    medpAvbl = true;
                }
                Console.Clear();
                ShowMercs();
                Console.WriteLine();
                Console.WriteLine("1) Organize inventories (swap items)\n2) Use medicine pack\n3) Dismiss mercenary");
                entry = ReadNumber(0, 3);
                switch (entry)
                {
                    case (1):
                        Console.WriteLine("Choose inventory:");
                        merc1 = ReadNumber(1, MercArrLen()) - 1;
                        mercenary[merc1].ShowInventory(typeof(TheLibrarianRpg.Item));
                        Console.WriteLine("Choose item 1:");
                        item1 = ReadNumber(1, mercenary[merc1].InventLen()) - 1;
                        Console.WriteLine("Choose inventory:");
                        merc2 = ReadNumber(1, MercArrLen()) - 1;
                        mercenary[merc2].ShowInventory(typeof(TheLibrarianRpg.Item));
                        Console.WriteLine("Choose item 2:");
                        item2 = ReadNumber(1, mercenary[merc2].InventLen()) - 1;
                        bridge = mercenary[merc1].inventory[item1];
                        mercenary[merc1].inventory[item1] = mercenary[merc2].inventory[item2];
                        mercenary[merc2].inventory[item2] = bridge;
                        Console.WriteLine("Done.");
                        Console.ReadKey();
                        break;

                    case (2):
                        Console.WriteLine("Choose mercenary:");
                        merc1 = ReadNumber(1, MercArrLen()) - 1;
                        if (!medpAvbl){
                            Console.WriteLine("No one has medpack.");
                            Console.ReadKey();
                        }else if(mercenary[merc1].medPack == 0){
                            Console.WriteLine("You don't have medpack. Do you want to take from others?");
                            Console.WriteLine("(1: yes, any other answer: no)");
                            if(entry == 1){
                                for (int i = 0; i < MercArrLen(); i++){
                                    if (mercenary[i].medPack != 0){
                                        Console.WriteLine((i + 1) + ") " + mercenary[i].name + " " + mercenary[i].medPack + "/" + mercenary[i].medPackMax);
                                        validIds[i] = i + 1;
                                    }
                                }
                                do{
                                    merc2 = ReadNumber(1, MercArrLen());
                                } while (!validIds.Contains(merc2));
                                merc2--;
                                mercenary[merc2].medPack--;
                                mercenary[merc1].medPack++;
                                mercenary[merc1].UseMedPack();
                            }
                        }
                        else{
                            mercenary[merc1].UseMedPack();
                        }
                        Console.WriteLine("Done.");
                        Console.ReadKey();
                        entry = 1;
                        break;

                    case (3):
                        DismissMerc();
                        break;
                }
            } while (entry != 0);
        }

        void MercCompactor()
        {
            bool compact = true;
            for (int i = 1; i < mercenary.Length; i++)
            {
                if (mercenary[i] != null && mercenary[i - 1] == null)
                {
                    compact = false;
                }
            }
            if (!compact)
            {
                Character[] bridge = new Character[2];
                bridge[0] = new Character();
                bridge[1] = new Character();
                int ind = 0;
                for (int i = 0; i < mercenary.Length; i++)
                {
                    if (mercenary[i] != null)
                    {
                        bridge[ind] = mercenary[i];
                        ind++;
                    }
                }
                bridge[0] = mercenary[0];
                bridge[1] = mercenary[0];
            }

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
