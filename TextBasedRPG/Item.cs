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
        public Item(Vector2 position, Player player)
        {
            collected = false;
            this.position = position;
            this.player = player;
            sprite.renderPriority = 5;
        }

        public abstract void ItemEffect();
    }
}
