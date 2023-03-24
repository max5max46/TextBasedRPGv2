using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TextBasedRPG
{
    internal class ItemHealthUp : Item
    {
        public ItemHealthUp(int x, int y, Player player) : base(x, y, player)
        {
            sprite = '+';
            spriteColor = ConsoleColor.Green;
        }
        public override void ItemEffect()
        {
            player.ItemBuff(6, 0, 0);
            Universal.DisplayText("Picked up a Heal         ");
            collected = true;
        }
    }
}
