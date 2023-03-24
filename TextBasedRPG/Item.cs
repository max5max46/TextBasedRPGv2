using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TextBasedRPG 
{
    internal abstract class Item : GameObject
    {
        public Player player;
        public bool collected;
        public Item(int x, int y, Player player)
        {
            collected = false;
            this.x = x;
            this.y = y;
            this.player = player;
        }

        public abstract void ItemEffect();
    }
}
