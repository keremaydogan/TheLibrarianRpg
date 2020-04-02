﻿using System;
using System.Collections.Generic;
using System.Text;

namespace TheLibrarianRpg
{
    public class Item
    {
        public string name;
        public int price;
        public string[] classRequirement;
        public int levelRequirement;

        public int quantity;
        public int maxQuantity;

        public string itemEffect;

        public bool equipped;
        public virtual void ItemEffect(){
        }
        public virtual void UnequipEffect(){
        }
    }
}