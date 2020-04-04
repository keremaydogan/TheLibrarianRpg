using System;
using System.Collections.Generic;
using System.Text;

namespace TheLibrarianRpg
{
    public class Accessory : Item
    {
        public Accessory(string name)
        {
            this.name = name;

            quantity = 1;
            maxQuantity = 1;

            equipped = false;
        }

        public override void Effect(bool equipped, PlayableChar pc)
        {
        }
    }
}
