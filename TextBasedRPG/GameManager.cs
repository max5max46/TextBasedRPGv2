using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace TextBasedRPG
{
    internal class GameManager
    {
        bool gameLoop;

        static public Renderer renderer;
        Player player;
        static public EnemyManager enemyManager;
        static public ItemManager itemManager;
        static public HUD UI;


        public GameManager()
        {
            gameLoop = true;

            renderer = new Renderer();
            player = new Player();
            enemyManager = new EnemyManager(player);
            itemManager = new ItemManager(player);
            UI = new HUD(player, enemyManager);
            player.SetManagers(enemyManager, itemManager);
            enemyManager.GiveAllEnemysTheEnemyManager();

        }

        public void Game()
        {

            while (gameLoop)
            {

                itemManager.Draw();
                enemyManager.Draw();
                player.Draw();
                UI.Draw();

                renderer.Render();

                enemyManager.Update();
                player.Update();
                UI.Update();

            }
        }

        public void EndGame()
        {
            gameLoop = false;
        }
    }
}
