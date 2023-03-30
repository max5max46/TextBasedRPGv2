using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TextBasedRPG
{
    internal class ItemDamageUp : Item
    {
        public ItemDamageUp(Vector2 position, Player player) : base(position, player)
        {
            sprite.character = '^';
            sprite.color = ConsoleColor.DarkRed;
        }
        public override void ItemEffect()
        {
            player.ItemBuff(0, 0, 1);
            Universal.DisplayText("Picked up a Damage Up         ");
            collected = true;
        }

    }
}
