using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TextBasedRPG
{
    internal class EnemyChaser : Enemy
    {
        public EnemyChaser(int x, int y, EnemyManager manager) : base(x, y)
        {
            health = 3;
            maxHealth = health;
            damage = 1;
            sprite = 'C';
            spriteColor = ConsoleColor.Red;
        }

        public override void Update()
        {
            tempX = x;
            tempY = y;

            //AI Movement

            //Move Towards player
            if (manager.player.x + manager.player.y - (x + y) < 7 && manager.player.x + manager.player.y - (x + y) > -7)
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
            else
            //Random movement
            {
                switch (Universal.GenerateRandomNumber(1, 4))
                {
                    case 1:
                        x++;
                        break;
                    case 2:
                        x--;
                        break;
                    case 3:
                        y++;
                        break;
                    case 4:
                        y--;
                        break;
                }
            }

            base.Update();
        }
    }
}
