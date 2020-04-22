using System;
using System.Collections.Generic;
using System.Text;

namespace TheLibrarianRpg
{
    public class Accessory : Item
    {
        //Only Basic Stats! 
        public Accessory(string name)
        {
            this.name = name;

            equipped = false;
        }
    }
}
