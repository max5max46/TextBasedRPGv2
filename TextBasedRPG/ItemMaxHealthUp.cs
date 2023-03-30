using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TextBasedRPG
{
    internal class ItemMaxHealthUp : Item
    {
        public ItemMaxHealthUp(Vector2 position, Player player) : base(position, player)
        {
            sprite.character = '#';
            sprite.color = ConsoleColor.Cyan;
        }
        public override void ItemEffect()
        {
            player.ItemBuff(0, 3, 0);
            Universal.DisplayText("Picked up a Max Health Up         ");
            collected = true;
        }
    }
}
