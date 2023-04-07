using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TextBasedRPG
{
    internal class LoadLevel
    {
        public LoadLevel(int levelToLoad, Player player, EnemyManager enemyManager, ItemManager itemManager, Renderer renderer, HUD UI)
        {
            GameManager.whichLevel++;
            Universal.mapName = "map" + levelToLoad + ".txt";
            Vector2 newPlayerPosition = new Vector2(0,0);

            char[,] loadedMap = Universal.loadMap();

            for (int i = 0; i < loadedMap.GetLength(0); i++)
            {
                for (int j = 0; j < loadedMap.GetLength(1); j++)
                {
                    if (loadedMap[i, j] == 'P')
                    {
                        newPlayerPosition.x = i;
                        newPlayerPosition.y = j;
                    }
                }
            }


            Console.Clear();
            Console.CursorVisible = false;

            player.SetPosition(newPlayerPosition);

            renderer = new Renderer();
            enemyManager = new EnemyManager(player);
            itemManager = new ItemManager(player);
            UI = new HUD(player, enemyManager);

            

            GameManager.renderer = renderer;
            GameManager.enemyManager = enemyManager;
            GameManager.itemManager = itemManager;
            GameManager.UI = UI;


            player.SetManagers();
            enemyManager.GiveAllEnemysTheEnemyManager();

        }

    }
}
