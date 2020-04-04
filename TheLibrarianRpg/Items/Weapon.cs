using System;
using System.Collections.Generic;
using System.Text;

namespace TheLibrarianRpg
{
    public class Weapon : Item
    {
        public float atkPower;
        public float critChance;
        public int critDeviRate; //Critic attack deviation rate

        public Weapon(string name, int atkPower, float critChance, int critDeviRate)
        {
            this.name = name;
            this.atkPower = atkPower;
            this.critChance = critChance;
            this.critDeviRate = critDeviRate;

            quantity = 1;
            maxQuantity = 1;

            equipped = false;
        }

        public override void Effect(bool equipped, PlayableChar pc)
        {
            if (equipped){
                pc.atkPower += atkPower;
            }else{
                pc.atkPower -= atkPower;
            }
        }
    }
}
