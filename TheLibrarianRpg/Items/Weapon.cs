using System;
using System.Collections.Generic;
using System.Text;

namespace TheLibrarianRpg
{
    public class Weapon : Item
    {
        public Weapon(string name, int atkPower, float critChance, int critDeviRate)
        {
            this.name = name;
            this.atkPower = atkPower;
            this.critChance = critChance;

            equipped = false;
        }
    }
}
