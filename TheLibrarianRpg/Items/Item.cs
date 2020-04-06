using System;
using System.Collections.Generic;
using System.Text;

namespace TheLibrarianRpg
{
    public class Item : Stats
    {
        public string name;
        public int price;
        public string[] classRequirement;
        public int levelRequirement;

        public int quantity;
        public int maxQuantity;

        public bool equipped;

        public string ItemDef()
        {
            string str = "";
            if (vigor != 0){
                str += "VIG: " + vigor + " ";
            }
            if (strength != 0){
                str += "STR: " + strength + " ";
            }
            if (endurance != 0){
                str += "END: " + vigor + " ";
            }
            if (dexterity != 0){
                str += "DEX: " + dexterity + " ";
            }
            str += "\n";
            return str;
        }
    }
}
