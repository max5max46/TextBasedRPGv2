using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TextBasedRPG
{
    internal class EnemyChaser : Enemy
    {
        public EnemyChaser(Vector2 position, EnemyManager manager) : base(position)
        {
            health = 3;
            maxHealth = health;
            damage = 1;
            sprite.character = 'C';
            sprite.color = ConsoleColor.Red;
        }

        public override void Update()
        {
            tempPosition = position;

            //AI Movement

            if (manager.player.position.x + manager.player.position.y - (position.x + position.y) < 6 && manager.player.position.x + manager.player.position.y - (position.x + position.y) > -6)
            {
                if (Math.Abs(manager.player.position.x - position.x) > Math.Abs(manager.player.position.y - position.y))
                {
                    if (manager.player.position.x > position.x)
                        position.x++;
                    else
                        position.x--;
                }
                else
                {
                    if (manager.player.position.y > position.y)
                        position.y++;
                    else
                        position.y--;
                }
            }
            else
            //Random movement
            {
                switch (Universal.GenerateRandomNumber(1, 4))
                {
                    case 1:
                        position.x++;
                        break;
                    case 2:
                        position.x--;
                        break;
                    case 3:
                        position.y++;
                        break;
                    case 4:
                        position.y--;
                        break;
                }
            }

            base.Update();
        }
    }
}
