using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TextBasedRPG
{
    internal class ItemDamageUp : Item
    {
        public ItemDamageUp(int x, int y, Player player) : base(x, y, player)
        {
            sprite = '^';
            spriteColor = ConsoleColor.DarkRed;
        }
        public override void ItemEffect()
        {
            player.ItemBuff(0, 0, 1);
            Universal.DisplayText("Picked up a Damage Up         ");
            collected = true;
        }

    }
}
