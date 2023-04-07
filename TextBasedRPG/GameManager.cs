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
        static bool gameLoop;
        static public int whichLevel;

        static public Player player;
        static public Renderer renderer;
        static public EnemyManager enemyManager;
        static public ItemManager itemManager;
        static public HUD UI;
        static MainMenu menu;
        static LoadLevel loadLevel;


        public GameManager()
        {
            whichLevel = 5;
            gameLoop = true;
            
            menu = new MainMenu();
            player = new Player();
            ChangeLevel();

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

                player.Update();
                enemyManager.Update();
                UI.Update();

            }
        }

        static public void EndGame()
        {
            gameLoop = false;
        }

        static public void ChangeLevel()
        {
            loadLevel = new LoadLevel(whichLevel, player, enemyManager, itemManager, renderer, UI);
        }
    }
}
