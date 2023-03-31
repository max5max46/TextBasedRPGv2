using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TextBasedRPG
{
    internal class Enemy : GameCharacter
    {
        public EnemyManager manager;

        public Enemy(Vector2 position)
        {
            alive = true;
            this.position = position;
            tempPosition = position;
            sprite.renderPriority = 3;
        }

        public virtual void Update()
        {
            //Collision Check with map object
            if (Universal.loadMap()[position.x, position.y] == 'X' || Universal.loadMap()[position.x, position.y] == 'W')
            {
                position = tempPosition;
            }

            //Collision Check for other enemys
            if (manager.IsEnemyHere(position, false))
            {
                position = tempPosition;
            }

            //Collision Check for Player
            if (manager.IsPlayerHere(position))
            {
                position = tempPosition;
                manager.HitPlayer(damage);
            }
        }

        public void SetEnemyManager(EnemyManager manager)
        {
            this.manager = manager;
        }
    }
}
