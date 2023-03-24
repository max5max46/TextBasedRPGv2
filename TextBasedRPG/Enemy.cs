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

        public Enemy(int x, int y)
        {
            alive = true;
            this.x = x;
            this.y = y;
            tempX = this.x;
            tempY = this.y;
        }

        public virtual void Update()
        {
            //Collision Check with map object
            if (Universal.loadMap()[x,y] == 'X')
            {
                x = tempX;
                y = tempY;
            }

            //Collision Check for other enemys
            if (manager.IsEnemyHere(x,y,false))
            {
                x = tempX;
                y = tempY;
            }

            //Collision Check for Player
            if (manager.IsPlayerHere(x,y))
            {
                x = tempX;
                y = tempY;
                manager.HitPlayer(damage);
            }
        }

        public void SetEnemyManager(EnemyManager manager)
        {
            this.manager = manager;
        }
    }
}
