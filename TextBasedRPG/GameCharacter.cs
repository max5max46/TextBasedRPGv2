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

        public void TakeDamage(int damage = 0)
        {
            health -= damage;
            if (health == 0)
                alive = false;
        }

        public override void Draw()
        {
            if (health < 1) sprite = 'X';
            base.Draw();
        }
    }
}
