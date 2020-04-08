using System;
using System.Collections.Generic;
using System.Text;

namespace TheLibrarianRpg
{
    public class Mob : Character
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

        public void Fight(PlayableChar[] pChar)
        {
            maxValue = 0;
            float randcheck = 0;

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
                randcheck += pChar[i].mobValue;
            }
            if(randcheck == 0)
            {
                chosen = rand.Next(0, pChar.Length);
            }
            else
            {
                for (int i = 0; i < pChar.Length; i++)
                {
                    if (maxValue < pChar[i].mobValue)
                    {
                        chosen = i;
                    }
                    else if (maxValue == pChar[i].mobValue)
                    {
                        equalValue = rand.Next(2);
                        if (equalValue == 1)
                        {
                            chosen = i;
                        }
                    }
                }
            }

            Attack(pChar[chosen]);

        }

        public void Attack(PlayableChar pc)
        {
            float atk = 0;
            if (HitChance())
            {
                if (pc.DodgeChance())
                {
                    Console.WriteLine(pc.name + " dodged the attack.");
                }
                else
                {
                    if (CritChance())
                    {
                        atk += atkPower * critChance;
                    }
                    else
                    {
                        atk += atkPower;
                    }
                    atk = atk * AttackDeviRate();
                    atk = MathF.Ceiling(atk);

                    pc.hp -= atk;

                    Console.WriteLine(name + " attacked to " + pc.name + " and damaged " + atk + " HP.");
                    if (pc.hp <= 0)
                    {
                        Console.WriteLine(pc.name + " died.");
                        pc = null;
                    }
                }
            }else{
                Console.WriteLine(name + " missed the enemy.");
            }
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
