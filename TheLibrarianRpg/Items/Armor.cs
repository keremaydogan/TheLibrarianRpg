using System;
using System.Collections.Generic;
using System.Text;

namespace TheLibrarianRpg
{
    public class Armor : Item
    {
        public Armor(string name, int atkResist)
        {
            this.name = name;
            this.atkResistance = atkResist;

            quantity = 1;
            maxQuantity = 1;

            equipped = false;
        }
    }
}
