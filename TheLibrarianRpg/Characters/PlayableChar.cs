using System;
using System.Collections.Generic;
using System.Text;

namespace TheLibrarianRpg
{
    public class PlayableChar : Character
    {
        public int xp;
        public int level;
        public int statPoints;

        public int price;

        public string pcClass;

        private int vigorMultp;
        private int strengthMultp;
        private int enduranceMultp;
        private int dexterityMultp;

        private int vigorBase;
        private int strengthBase;
        private int enduranceBase;
        private int dexterityBase;

        public float mobValue;

        public Item[] inventory;
        public Item[] equipment;

        private int entry;
        private int[] inventoryID;
        private int inventIDLen;
        public bool takeItem;

        public int medPackMax;
        public int medPack;


        public PlayableChar()
        {
            vigor = 1;
            strength = 1;
            endurance = 1;
            dexterity = 1;
            vigorBase = vigor;
            strengthBase = strength;
            enduranceBase = endurance;
            dexterityBase = dexterity;

            level = 1;

            medPackMax = 4;
            medPack = 4;

            inventory = new Item[8];

            equipment = new Item[3];

            inventoryID = new int[9];
        }

        public void Fight(Mob[] mob)
        {
            Console.WriteLine("1) Attack\n2) Check\n3) Use medicine pack\n4) Change equipment");
            entry = ReadNumber(1, 4);
            while(entry == 3 && medPack == 0)
            {
                Console.WriteLine("Your medicine package is empty.");
                entry = ReadNumber(1, 4);
            }
            switch (entry)
            {
                case 1:
                    Attack(mob);
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
                    UseMedPack();
                    break;

                case 4:
                    ChangeEquipment();
                    break;
            }
        }

        public void Attack(Mob[] mob)
        {
            float atk = 0;
            Console.WriteLine("Choose enemy:");
            for (int i = 0; i < mob.Length; i++)
            {
                Console.WriteLine((i + 1) + ") " + mob[i].name);
            }
            entry = ReadNumber(1, mob.Length);

            if (HitChance())
            {
                if (mob[entry - 1].DodgeChance())
                {
                    Console.WriteLine(mob[entry - 1].name + " dodged the attack.");
                }
                else
                {
                    if (CritChance())
                    {
                        atk += atkPower * critDeviRate;
                    }
                    else
                    {
                        atk += atkPower;
                    }
                    atk = atk * AttackDeviRate();
                    atk = MathF.Ceiling(atk);

                    mob[entry - 1].hp -= atk;

                    Console.WriteLine(name + " attacked to " + mob[entry - 1].name + " and damaged " + atk + " HP.");
                    if (mob[entry - 1].hp <= 0)
                    {
                        Console.WriteLine(mob[entry - 1].name + " died.");
                        mob[entry - 1] = null;
                    }
                }
            }else{
                Console.WriteLine(name + " missed the enemy.");
            }
        }

        public void SetStats()
        {
            entry = 0;
            int statIndex;
            int change;
            string stats = "Stats ("+ name +"):\n1) Vigor: "+ vigor +"\n2) Strength: "+ strength +"\n3) Endurance: "+ endurance +"\n4) Dexterity: "+ dexterity +"\n\nFirst enter statistic's no (enter '0' to exit this screen). Then enter the change that you want in '+/-num' format.\nYou can't reduce saved stat points.\n\nRemaining stat points: " + statPoints + "\n\n";

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
                if(entry == 0) {
                    Console.WriteLine("Are you sure? Changes are permanent.\n(0: yes, any other number: no)" );
                    entry = ReadNumber(int.MinValue, int.MaxValue);
                }
            } while (entry != 0);
            StatEquation();
        }

        void ChangeEquipment()
        {
            int answer;
            do{
                Console.Clear();
                ShowEquipment();
                Console.WriteLine("Choose equipment: (0 to exit)");
                entry = ReadNumber(0, 3);
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
                if(entry != 0){
                    for (inventIDLen = 0; inventoryID[inventIDLen] != -1; inventIDLen++) { }
                    Console.WriteLine("\nChoose item:");
                    answer = ReadNumber(1, inventIDLen);

                    for(int i = 0; i < inventory.Length; i++){
                        if (inventory[i].GetType() == equipment[entry - 1].GetType() && inventory[i].equipped == true){
                            inventory[i].equipped = false;
                            ItemEffect(i);
                        }
                    }
                    equipment[entry - 1] = inventory[inventoryID[answer - 1]];
                    inventory[inventoryID[answer - 1]].equipped = true;
                    ItemEffect(inventoryID[answer - 1]);
                }
            } while (entry != 0);
        }

        public void ReplenishMedPack()
        {
            medPack = medPackMax;
        }

        public void UseMedPack()
        {
            if(medPack == 0){
                Console.WriteLine("Your medicine package is empty.");
                Console.ReadKey();
            }
            else{
                hp += MathF.Ceiling((maxHp * (1 / 4)));
                if(hp > maxHp)
                {
                    hp = maxHp;
                }
            }
        }

        void ItemEffect(int itemIndex)
        {
            Type type = inventory[itemIndex].GetType();
            if (type == typeof(TheLibrarianRpg.Weapon))
            {
                if (inventory[itemIndex].equipped){
                    atkPower += inventory[itemIndex].atkPower;
                }else{
                    atkPower -= inventory[itemIndex].atkPower;
                }
            }else if(type == typeof(TheLibrarianRpg.Armor)){
                if (inventory[itemIndex].equipped)
                {
                    atkResistance += inventory[itemIndex].atkResistance;
                }else{
                    atkResistance -= inventory[itemIndex].atkResistance;
                }
            }else if(type == typeof(TheLibrarianRpg.Accessory)){
                if (inventory[itemIndex].equipped)
                {
                    vigor += inventory[itemIndex].vigor;
                    strength += inventory[itemIndex].strength;
                    endurance += inventory[itemIndex].endurance;
                    dexterity += inventory[itemIndex].dexterity;
                }else{
                    vigor -= inventory[itemIndex].vigor;
                    strength -= inventory[itemIndex].strength;
                    endurance -= inventory[itemIndex].endurance;
                    dexterity -= inventory[itemIndex].dexterity;
                }
            }

            //ADD FLASK

        }

        public int InventLen()
        {
            int inventLen = -1;
            for (int i = 0; i < inventory.Length && inventLen == -1; i++){
                if(inventory[i] == null){
                    inventLen = i;
                }
            }
            return inventLen;
        }

        public void ShowInventory(Type itemType)
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

        public void ShowEquipment()
        {
            Console.WriteLine("IIII EQUIPMENT IIII");
            Console.WriteLine("1) Weapon: " + equipment[0].name + " ATK: +" + equipment[0].atkPower + "\n2) Armor: " + equipment[1].name + " DEF: +" + equipment[1].atkResistance + "\n3) Accessory: " + equipment[2].name + " Efct: " + equipment[2].ItemDef());
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

        public void TakeItem(Item newItem)
        {
            if (inventory[inventory.Length - 1] != null)
            {
                Console.WriteLine("Inventory is full.");
                Console.ReadKey();
            }
            else
            {
                int i = 0;
                for (; i < inventory.Length && inventory[i] != null; i++) { }
                inventory[i] = new Item();
                inventory[i] = newItem;
                newItem = null;
            }
        }

        public void RemoveItem(int iRem)
        {
            for (; iRem < (inventory.Length - 1); iRem++)
            {
                inventory[iRem] = inventory[iRem + 1];
            }
            inventory[inventory.Length - 1] = null;
        }

        int InventoryValue()
        {
            int value = 0;
            for(int i = 0; i < InventLen(); i++){
                value += inventory[i].price;
            }
            value = value / 2;
            return value;
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

        public void StatScreen() 
        {
            Console.WriteLine(name);
            Console.WriteLine(hp + "/" + maxHp);
            Console.WriteLine("ATK: " + atkPower + "  " + "DEF: " + atkResistance);
            Console.WriteLine("Critical attack chance: " + critChance);
            Console.WriteLine("Hit chance: " + hitChance);
            Console.WriteLine("Dodge chance: " + dodgeChance);
            Console.WriteLine("VIG: " + vigor + "    STR: " + strength + "    END: " + endurance + "    DEX: " + dexterity);
        }
        public string TavernDef()
        {
            string def = name + "\n" + pcClass + "\nII HP: " + hp + "/" + maxHp + "\nATK:" + atkPower + "\nDEF:" + atkResistance + "\n";

            return def;
        }

        public string fightScreenDef()
        {
            return "IIIIIIIIIIIIIIIIIIIIIIII\nII Name: " + name + "\nII HP: " + hp + "/" + maxHp + "\n";
        }

    }
}
