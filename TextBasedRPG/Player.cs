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
            health = Universal.PLAYER_HEALTH;
            maxHealth = Universal.PLAYER_HEALTH;
            damage = Universal.PLAYER_DAMAGE;
            sprite.character = 'P';
            sprite.color = ConsoleColor.Green;
            sprite.renderPriority = 1;

            char[,] loadedMap = Universal.loadMap();

            for (int i = 0; i < loadedMap.GetLength(0); i++)
            {
                for (int j = 0; j < loadedMap.GetLength(1); j++)
                {
                    if (loadedMap[i, j] == 'P')
                    {
                        position.x = i;
                        position.y = j;
                    }
                }
            }

            tempPosition = position;

        }

        public void Update()
        {
            if (health == 0)
                return;

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

            //Collision Check with map object
            if (Universal.loadMap()[position.x, position.y] == 'X')
            {
                position = tempPosition;
            }

            //Collision with win
            if (Universal.loadMap()[position.x, position.y] == 'W')
            {
                Universal.DisplayText("YOU WIN!!!!!");
                position = tempPosition;
            }

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

        public void SetManagers(EnemyManager enemyManager, ItemManager itemManager)
        {
            this.enemyManager = enemyManager;
            this.itemManager = itemManager;
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
    }
}
