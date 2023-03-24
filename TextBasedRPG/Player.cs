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
            sprite = 'P';
            spriteColor = ConsoleColor.Green;

            char[,] loadedMap = Universal.loadMap();

            for (int i = 0; i < loadedMap.GetLength(0); i++)
            {
                for (int j = 0; j < loadedMap.GetLength(1); j++)
                {
                    if (loadedMap[i, j] == 'P')
                    {
                        x = i;
                        y = j;
                    }
                }
            }

            tempX = x;
            tempY = y;

        }

        public void Update()
        {
            if (health == 0)
                return;

            tempX = x;
            tempY = y;


            ClearInput();
            ConsoleKeyInfo keyInfo;
            keyInfo = Console.ReadKey(true);

            if (keyInfo.KeyChar == 's' || keyInfo.Key == ConsoleKey.DownArrow)
                y++;

            if (keyInfo.KeyChar == 'w' || keyInfo.Key == ConsoleKey.UpArrow)
                y--;

            if (keyInfo.KeyChar == 'a' || keyInfo.Key == ConsoleKey.LeftArrow)
                x--;

            if (keyInfo.KeyChar == 'd' || keyInfo.Key == ConsoleKey.RightArrow)
                x++;

            //Collision Check with map object
            if (Universal.loadMap()[x, y] == 'X')
            {
                x = tempX;
                y = tempY;
            }

            //Collision with win
            if (Universal.loadMap()[x, y] == 'W')
            {
                Universal.DisplayText("YOU WIN!!!!!");
                x = tempX;
                y = tempY;
            }

            //Collision Check with Enemys
            if (enemyManager.IsEnemyHere(x, y, true))
            {
                enemyManager.HitEnemy(x,y,damage);
                x = tempX;
                y = tempY;
            }

            //Collision Check with items
            if (itemManager.IsItemHere(x, y))
            {
                itemManager.CollectItem(x,y);
                x = tempX;
                y = tempY;
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
