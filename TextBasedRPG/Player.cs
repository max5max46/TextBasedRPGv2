using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace TextBasedRPG
{
    internal class Player : GameCharacter
    {
        EnemyManager enemyManager;
        ItemManager itemManager;

        public Player()
        {
            alive = true;
            health = Setting.PLAYER_HEALTH;
            maxHealth = health;
            damage = Setting.PLAYER_DAMAGE;
            sprite.character = 'P';
            sprite.color = ConsoleColor.Yellow;
            sprite.renderPriority = 1;

            tempPosition = position;

        }

        public void Update()
        {
            if (health == 0)
            {
                GameManager.EndGame();
                return;
            }

            tempPosition = position;

            ClearInput();
            ConsoleKeyInfo keyInfo;
            keyInfo = Console.ReadKey(true);

            if (keyInfo.KeyChar == 's' || keyInfo.Key == ConsoleKey.DownArrow)
                position.y++;

            if (keyInfo.KeyChar == 'w' || keyInfo.Key == ConsoleKey.UpArrow)
                position.y--;

            if (keyInfo.KeyChar == 'a' || keyInfo.Key == ConsoleKey.LeftArrow)
                position.x--;

            if (keyInfo.KeyChar == 'd' || keyInfo.Key == ConsoleKey.RightArrow)
                position.x++;

            if (keyInfo.Key == ConsoleKey.Escape)
                GameManager.EndGame();

            //Collision Check with map object
            if (Universal.loadMap()[position.x, position.y] == 'X')
            {
                position = tempPosition;
            }

            //Collision with win
            if (Universal.loadMap()[position.x, position.y] == 'W')
            {
                GameManager.ChangeLevel();
                position = tempPosition;
            }

            if (enemyManager == null)
                Console.ReadKey();

            //Collision Check with Enemys
            if (enemyManager.IsEnemyHere(position, true))
            {
                enemyManager.HitEnemy(position, damage);
                position = tempPosition;
            }

            //Collision Check with items
            if (itemManager.IsItemHere(position))
            {
                itemManager.CollectItem(position);
                position = tempPosition;
            }
        }

        public void SetManagers()
        {
            this.enemyManager = GameManager.enemyManager;
            this.itemManager = GameManager.itemManager;
        }

        private void ClearInput()
        {
            while (Console.KeyAvailable)
            {
                Console.ReadKey(true);
            }
        }

        public void ItemBuff(int heal = 0, int gainMaxHealth = 0, int gainDamage = 0)
        {
            damage += gainDamage;
            maxHealth += gainMaxHealth;
            health += heal;
            if (health > maxHealth)
                health = maxHealth;
        }

        public void SetPosition(Vector2 position)
        {
            this.position = position;
            this.tempPosition = position;
        }
    }
}
