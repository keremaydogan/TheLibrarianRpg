using System;
using System.Collections.Generic;
using System.Text;

namespace TheLibrarianRpg
{
    class Mob : Character
    {
        public int xpValue;

        private int atkScore;
        private int hpScore;

        int maxValue;
        int chosen;
        int equalValue;

        public string mobDef;

        private Random rand = new Random();

        public Mob()
        {
        }

        public void Attack(PlayableChar[] pChar)
        {
            maxValue = 0;

            for (int i = 0; i < pChar.Length; i++)
            {
                pChar[i].mobValue += pChar[i].atkPower * atkScore;
            }

            for (int i = 0; i < pChar.Length; i++)
            {
                if(atkPower >= pChar[i].hp)
                {
                    pChar[i].mobValue += 5 * hpScore;
                }
                else if (atkPower * 3 >= pChar[i].hp)
                {
                    pChar[i].mobValue += hpScore;
                }
            }

            //for (int i = 0; i < pChar.Length; i++)
            //{

            //}

            for (int i = 0; i < pChar.Length; i++)
            {
                if(maxValue < pChar[i].mobValue)
                {
                    chosen = i;
                }
                else if (maxValue == pChar[i].mobValue)
                {
                    equalValue = rand.Next(2);
                    if(equalValue == 1)
                    {
                        chosen = i;
                    }
                }
            }

            pChar[chosen].hp -= atkPower;
            if (hp < 0)
            {
                hp = 0;
            }
            Console.WriteLine(name + " attacked to " + pChar[chosen].name + ".");
        }

        public string fightScreenDef()
        {
            return "IIIIIIIIIIIIIIIIIIIIIIII\nII Name: " + name + "\nII HP: " + hp + "/" + maxHp + "\n";
        }

        public string detailedDef()
        {
            return "IIIIIIIIIIIIIIIIIIIIIIII\nII Name: " + name + "\nII HP: " + hp + "/" + maxHp + "\nII ATK: " + atkPower + "\nII DEF: " + atkResistance + "\nII " + mobDef + "\n";
        }

    }
}
