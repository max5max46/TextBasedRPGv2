using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TextBasedRPG
{
    internal class EnemyBouncer : Enemy
    {
        public EnemyBouncer(Vector2 position, EnemyManager manager) : base(position)
        {
            health = Setting.BOUNCER_HEALTH;
            maxHealth = health;
            damage = Setting.BOUNCER_DAMAGE;
            sprite.character = 'B';
            sprite.color = ConsoleColor.Magenta;
        }

        public override void Update()
        {
            tempPosition = position;

            //AI Movement

            //Move Towards player
            if (manager.player.position.x + manager.player.position.y - (position.x + position.y) < 4 && manager.player.position.x + manager.player.position.y - (position.x + position.y) > -4)
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

            base.Update();
        }
    }
}
