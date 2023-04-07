using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TextBasedRPG
{
    internal class ItemHealthUp : Item
    {
        public ItemHealthUp(Vector2 position, Player player) : base(position, player)
        {
            sprite.character = '+';
            sprite.color = ConsoleColor.Green;
        }
        public override void ItemEffect()
        {
            player.ItemBuff(Setting.HEAL_AMOUNT, 0, 0);
            Universal.DisplayText("Picked up a Heal         ");
            collected = true;
        }
    }
}
