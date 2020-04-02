using System;
using System.Collections.Generic;
using System.Text;

namespace TheLibrarianRpg
{
    public class Weapon : Item
    {
        public int atkPower;
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
        }
    }
}
