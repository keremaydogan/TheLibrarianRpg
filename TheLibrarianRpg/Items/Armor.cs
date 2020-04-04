using System;
using System.Collections.Generic;
using System.Text;

namespace TheLibrarianRpg
{
    public class Armor : Item
    {
        public int atkResist;

        public Armor(string name, int atkResist)
        {
            this.name = name;
            this.atkResist = atkResist;

            quantity = 1;
            maxQuantity = 1;

            equipped = false;
        }

        public override void Effect(bool equipped, PlayableChar pc)
        {
            if (equipped){
                pc.atkResistance += atkResist;
            }else{
                pc.atkResistance -= atkResist;
            }
        }
    }
}
