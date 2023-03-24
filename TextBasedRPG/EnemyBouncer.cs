using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TextBasedRPG
{
    internal class EnemyBouncer : Enemy
    {
        public EnemyBouncer(int x, int y, EnemyManager manager) : base(x, y)
        {
            health = 5;
            maxHealth = health;
            damage = 2;
            sprite = 'B';
            spriteColor = ConsoleColor.Magenta;
        }

        public override void Update()
        {
            tempX = x;
            tempY = y;

            //AI Movement

            //Move Towards player
            if (manager.player.x + manager.player.y - (x + y) < 4 && manager.player.x + manager.player.y - (x + y) > -4)
            {
                if (Math.Abs(manager.player.x - x) > Math.Abs(manager.player.y - y))
                {
                    if (manager.player.x > x)
                        x++;
                    else
                        x--;
                }
                else
                {
                    if (manager.player.y > y)
                        y++;
                    else
                        y--;
                }
            }

            base.Update();
        }
    }
}
