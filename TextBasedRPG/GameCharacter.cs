using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TextBasedRPG
{
    internal class GameCharacter : GameObject
    {
        public bool alive;
        public int health;
        public int maxHealth;
        public int damage;

        public virtual void TakeDamage(int damage = 0)
        {
            health -= damage;

            if (health < 0)
                health = 0;

            if (health < 1)
                alive = false;
        }

        public override void Draw()
        {
            if (health < 1) 
            {
                sprite.character = 'X';
                sprite.renderPriority = 9;
            }

            base.Draw();
        }
    }
}
