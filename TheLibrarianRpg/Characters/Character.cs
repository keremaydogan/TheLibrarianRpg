using System;
using System.Collections.Generic;
using System.Text;

namespace TheLibrarianRpg
{
    public class Character : Stats
    {
        public string name;
        public float maxHp;

        Random rand;

        public Character()
        {
            rand = new Random();
        }

        public bool CritChance()
        {
            int rnd = rand.Next(1, 101);
            if(critChance >= rnd)
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        public bool DodgeChance()
        {
            int rnd = rand.Next(1, 101);
            if (dodgeChance >= rnd)
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        public bool HitChance()
        {
            int rnd = rand.Next(1, 101);
            if (hitChance >= rnd)
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        public float AttackDeviRate()
        {
            float f = rand.Next(-10, +11);
            f = f * 0.01F + 1;
            return f;
        }
    }
}
