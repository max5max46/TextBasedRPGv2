using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TextBasedRPG
{
    internal class ItemMaxHealthUp : Item
    {
        public ItemMaxHealthUp(int x, int y, Player player) : base(x, y, player)
        {
            sprite = '#';
            spriteColor = ConsoleColor.Cyan;
        }
        public override void ItemEffect()
        {
            player.ItemBuff(0, 3, 0);
            Universal.DisplayText("Picked up a Max Health Up         ");
            collected = true;
        }
    }
}
