using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Schema;

namespace TextBasedRPG
{
    internal class EnemyManager
    {
        public Player player;
        public Enemy[] enemys;

        public EnemyManager(Player player) 
        {
            
            this.player = player;
            int enemyArrayIndex = 0;
            int totalEnemys = 0;
            char[,] loadedMap = Universal.loadMap();
            EnemyManager enemyManager = GameManager.enemyManager;

            for (int x = 0; x < loadedMap.GetLength(0); x++)
            {
                for (int y = 0; y < loadedMap.GetLength(1); y++)
                {
                    if (loadedMap[x, y] == 'B' || loadedMap[x, y] == 'R' || loadedMap[x, y] == 'C')
                        totalEnemys++;
                }
            }

            enemys = new Enemy[totalEnemys];

            for (int x = 0; x < loadedMap.GetLength(0); x++)
            {
                for (int y = 0; y < loadedMap.GetLength(1); y++)
                {
                    if (loadedMap[x, y] == 'C')
                    {
                        enemys[enemyArrayIndex] = new EnemyChaser(x, y, enemyManager); 
                        enemyArrayIndex++;
                    }

                    if (loadedMap[x, y] == 'R')
                    {
                        enemys[enemyArrayIndex] = new EnemyRunner(x, y, enemyManager);
                        enemyArrayIndex++;
                    }

                    if (loadedMap[x, y] == 'B')
                    {
                        enemys[enemyArrayIndex] = new EnemyBouncer(x, y, enemyManager);
                        enemyArrayIndex++;
                    }
                        
                }
            }
        }


        public void Update()
        {
            for (int i = 0; i < enemys.Length; i++)
            {
                if (enemys[i].alive == true)
                    enemys[i].Update();
            }
        }

        public void Draw()
        {
            for (int i = 0; i < enemys.Length; i++)
            {
                enemys[i].Draw();
            }
        }


        public bool IsEnemyHere (int x, int y, bool isntEnemy)
        {
            bool foundSelf = isntEnemy;

            for (int i = 0; i < enemys.Length; i++)
            {
                if (enemys[i].x == x && enemys[i].y == y && enemys[i].alive)
                {
                    if (foundSelf == true)
                        return true;
                    else
                        foundSelf = true;
                }
            }

            return false;
        }

        public bool IsPlayerHere(int x, int y)
        {
            if (player.x == x && player.y == y && player.alive)
                return true;

            return false;
        }

        public void HitPlayer(int damage)
        {
            player.TakeDamage(damage);
        }

        public void HitEnemy(int x, int y, int damage)
        {
            for (int i = 0; i < enemys.Length; i++)
            {
                if (enemys[i].x == x && enemys[i].y == y)
                {
                    enemys[i].TakeDamage(damage);
                    Universal.DisplayText("Enemy Health: " + enemys[i].health + "      ");
                    return;
                }
            }
        }

        public void GiveAllEnemysTheEnemyManager()
        {
            for (int i = 0; i < enemys.Length; i++)
            {
                enemys[i].SetEnemyManager(GameManager.enemyManager);
            }
        }
    }
}
