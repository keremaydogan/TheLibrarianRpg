using System;
using System.Collections.Generic;
using System.Text;

namespace TheLibrarianRpg
{
    class PlayableChar : Character
    {
        public int xp;
        public int level;

        private int vigor;
        private int strength;
        private int endurance;
        private int dexterity;

        private int vigorMultp;
        private int strengthMultp;
        private int enduranceMultp;
        private int dexterityMultp;

        private int vigorBase;
        private int strengthBase;
        private int enduranceBase;
        private int dexterityBase;

        public int statPoints;

        public float mobValue;

        public Item[] inventory;
        public Item[] equipment;

        private int entry;
        private int[] inventoryID;

        public PlayableChar()
        {
            vigor = 4;
            strength = 4;
            endurance = 4;
            dexterity = 4;
            vigorBase = vigor;
            strengthBase = strength;
            enduranceBase = endurance;
            dexterityBase = dexterity;

            inventoryID = new int[17];
        }

        public void Attack(Mob[] mob)
        {
            Console.WriteLine("1) Attack\n2) Check\n3\n3) Use item\n4) Change equipment");
            entry = ReadNumber(1, 4);
            switch (entry)
            {
                case 1:
                    Console.WriteLine("Choose enemy:");
                    for(int i = 0; i < mob.Length; i++)
                    {
                        Console.WriteLine((i + 1) + ") " + mob[i].name);
                    }
                    entry = ReadNumber(1, mob.Length);

                    // ENTER ATTACK EQUATION
                    //
                    //
                    //

                    Console.WriteLine(name + " attacked to " + mob[entry -1].name + ".");
                    break;

                case 2:
                    Console.WriteLine("Choose enemy:");
                    for (int i = 0; i < mob.Length; i++)
                    {
                        Console.WriteLine((i + 1) + ") " + mob[i].name);
                    }
                    entry = ReadNumber(1, mob.Length);
                    Console.WriteLine(mob[entry - 1].detailedDef() + "Press any key to continue...");
                    Console.ReadKey();
                    break;

                case 3:

                    break;

                case 4:

                    break;
            }
        }
        public void SetStats()
        {
            entry = 0;
            int statIndex;
            int change;
            string stats = "Stats ("+ name +"):\n1) Vigor: "+ vigor +"\n2) Strength: "+ strength +"\n3) Endurance: "+ endurance +"\n4) Dexterity: "+ dexterity +"\n\nFirst enter statistic's no (enter '5' to exit this screen). Then enter the change that you want in '+/-num' format.\nYou can't reduce saved stat points.\n\nRemaining stat points: " + statPoints + "\n\n";

            do
            {
                Console.Clear();
                Console.Write(stats);

                Console.WriteLine(",\n\nEnter statistic's no:");
                statIndex = ReadNumber(1, 5);
                Console.WriteLine("Enter change:");
                
                switch (statIndex)
                {
                    case 1:
                        change = ReadNumber(-(vigor - 1), statPoints);
                        while(statPoints - change < 0 || vigor + change < vigorBase){
                            Console.WriteLine("[INVALID ENTRY]");
                            change = ReadNumber(-(vigor - 1), statPoints);
                        }
                        vigor += change;
                        statPoints -= change;
                        break;
                    case 2:
                        change = ReadNumber(-(strength - 1), statPoints);
                        while (statPoints - change < 0 || strength + change < strengthBase) {
                            Console.WriteLine("[INVALID ENTRY]");
                            change = ReadNumber(-(vigor - 1), statPoints);
                        }
                        vigor += change;
                        statPoints -= change;
                        break;
                    case 3:
                        change = ReadNumber(-(endurance - 1), statPoints);
                        while (statPoints - change < 0 || endurance + change < enduranceBase){
                            Console.WriteLine("[INVALID ENTRY]");
                            change = ReadNumber(-(vigor - 1), statPoints);
                        }
                        vigor += change;
                        statPoints -= change;
                        break;
                    case 4:
                        change = ReadNumber(-(dexterity - 1), statPoints);
                        while (statPoints - change < 0 || dexterity + change < dexterityBase){
                            Console.WriteLine("[INVALID ENTRY]");
                            change = ReadNumber(-(vigor - 1), statPoints);
                        }
                        vigor += change;
                        statPoints -= change;
                        break;
                }
                if(entry == 5) {
                    Console.WriteLine("Are you sure? Changes are permanent.\n(5: yes, any other number: no)" );
                    entry = ReadNumber(int.MinValue, int.MaxValue);
                }
            } while (entry != 5);
            StatEquation();
        }

        void ChangeEquipment()
        {
            int inventIDLen;
            int answer;
            do{
                Console.Clear();
                ShowEquipment();
                Console.WriteLine("Choose equipment: (4 to exit)");
                entry = ReadNumber(1, 4);
                switch (entry){
                    case (1):
                        ShowInventory(typeof(TheLibrarianRpg.Weapon));
                        break;
                    case (2):
                        ShowInventory(typeof(TheLibrarianRpg.Armor));
                        break;
                    case (3):
                        ShowInventory(typeof(TheLibrarianRpg.Accessory));
                        break;
                }
                if(entry != 4){
                    for (inventIDLen = 0; inventoryID[inventIDLen] != -1; inventIDLen++) { }
                    Console.WriteLine("\nChoose item:");
                    answer = ReadNumber(1, inventIDLen);

                    for(int i = 0; i < inventory.Length; i++){
                        if (inventory[i].GetType() == equipment[entry - 1].GetType() && inventory[i].equipped == true){
                            inventory[i].equipped = false;
                        }
                    }
                    equipment[entry - 1] = inventory[inventoryID[answer - 1]];
                    inventory[inventoryID[answer - 1]].equipped = true;
                }
            } while (entry != 4);
        }

        void ShowInventory(Type itemType)
        {
            for(int i = 0; i < inventoryID.Length; i++){
                inventoryID[i] = -1;
            }
            int invId = 0;
            string inventName;
            if (itemType == typeof(TheLibrarianRpg.Item)){
                Console.WriteLine("IIII INVENTORY IIII");
                for (int i = 0; inventory[i] != null && i < inventory.Length; i++){
                    inventoryID[i] = i;
                    Console.WriteLine((i + 1) + ") " + inventory[i].name);
                }
                Console.WriteLine("IIIIIIIIIIIIIIIIIIII\n");
            }else{
                inventName = itemType.GetType().Name.ToString().ToUpper();
                Console.WriteLine("IIII " + inventName + " IIII");

                for (int i = 0; i < inventory.Length; i++){
                    if(inventory[i].GetType() == itemType){
                        inventoryID[invId] = i;
                        invId++;
                        Console.WriteLine((invId) + ") " + inventory[i].name);
                    }
                }
                Console.WriteLine("IIIIIIIIIIIIIIIIIIII\n");
            }
        }

        void ShowEquipment()
        {
            string[] itemNames = new string[3];
            Console.WriteLine("IIII EQUIPMENT IIII");
            Console.WriteLine("1) Weapon: " + equipment[0].name + " ATK: +" + equipment[0].itemEffect + "\n2) Armor: " + equipment[1].name + " DEF: +" + equipment[1].itemEffect + "\n3) Accessory: " + equipment[2].name + " Efct: " + equipment[2].itemEffect);
            Console.WriteLine("IIIIIIIIIIIIIIIIIIII\n");
        }

        void StatEquation()
        {
            maxHp += vigor * vigorMultp;
            hp = maxHp;
            atkPower += strength * strengthMultp;
            atkResistance += endurance * enduranceMultp;
            critChance += dexterity * dexterityMultp;
            critChance += dexterity * dexterityMultp;
            dodgeChance += dexterity * dexterityMultp;

            vigorBase = vigor;
            strengthBase = strength;
            enduranceBase = endurance;
            dexterityBase = dexterity;
        }

        void TakeItem(Item newItem)
        {
            if(newItem.GetType() == typeof(TheLibrarianRpg.Consumable))
            {
                for(int i = 0; i < inventory.Length && newItem.quantity != 0; i++)
                {
                    if (newItem.name == inventory[i].name )
                    {
                        inventory[i].quantity += newItem.quantity;
                        newItem.quantity = 0;
                        if(inventory[i].quantity > inventory[i].maxQuantity)
                        {
                            newItem.quantity = inventory[i].quantity - inventory[i].maxQuantity;
                            inventory[i].quantity = inventory[i].maxQuantity;
                        }
                    }
                }

                if(newItem.quantity > 0)
                {
                    Console.WriteLine("Inventory is full.");
                }
                else
                {
                    newItem = null;
                }
            }
            else
            {
                if(inventory[inventory.Length - 1] != null)
                {
                    Console.WriteLine("Inventory is full.");
                    Console.ReadKey();
                }
                else
                {
                    int i = 0;
                    for(; i < inventory.Length && inventory[i] != null; i++){}
                    inventory[i] = new Item();
                    inventory[i] = newItem;
                    newItem = null;
                }
            }
        }

        void RemoveItem(int iRem)
        {
            int sub;
            if (inventory[iRem].quantity > 1)
            {
                Console.WriteLine("How many do you want to remove?");
                sub = ReadNumber(0, inventory[iRem].quantity);
                inventory[iRem].quantity -= sub;
            }
            if(inventory[iRem].quantity <= 1)
            {
                for(; iRem < (inventory.Length - 1); iRem++)
                {
                    inventory[iRem] = inventory[iRem + 1];
                }
                inventory[inventory.Length - 1] = null;
            }
        }

        void SwapItems()
        {
            var bridgeItem = new Item();

            int item1, item2;
            Console.WriteLine("Enter first item's no.");
            item1 = ReadNumber(1, inventory.Length);
            item1--;
            Console.WriteLine("Enter second item's no.");
            item2 = ReadNumber(1, inventory.Length);
            item2--;

            bridgeItem = inventory[item1];
            inventory[item1] = inventory[item2];
            inventory[item2] = bridgeItem;
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

        public string fightScreenDef()
        {
            return "IIIIIIIIIIIIIIIIIIIIIIII\nII Name: " + name + "\nII HP: " + hp + "/" + maxHp;
        }

    }
}
