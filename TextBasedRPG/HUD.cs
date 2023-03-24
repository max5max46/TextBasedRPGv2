using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TextBasedRPG
{
    internal class HUD
    {
        int playerHealth;
        int playerMaxHealth;
        int playerDamage;

        string textToDisplay;

        int offsetX;
        int offsetY;

        char[,] loadedMap;

        Player player;

        public HUD(Player player, EnemyManager enemyManager)
        {
            offsetX = Universal.OFFSET_X;
            offsetY = Universal.OFFSET_Y;
            loadedMap = Universal.loadMap();
            this.player = player;

            playerHealth = player.health;
            playerMaxHealth = player.maxHealth;
            playerDamage = player.damage;

            textToDisplay = "";

            //Draw Map Border
            for (int i = 0; i < loadedMap.GetLength(0); i++)
            {
                Console.SetCursorPosition(i + offsetX, offsetY - 1);
                Console.Write('─');
            }

            for (int i = 0; i < loadedMap.GetLength(0); i++)
            {
                Console.SetCursorPosition(i + offsetX, loadedMap.GetLength(1) + offsetY);
                Console.Write('─');
            }

            for (int i = 0; i < loadedMap.GetLength(1); i++)
            {
                Console.SetCursorPosition(offsetX - 1, i + offsetY);
                Console.Write('│');
            }

            for (int i = 0; i < loadedMap.GetLength(1); i++)
            {
                Console.SetCursorPosition(loadedMap.GetLength(0) + offsetX, i + offsetY);
                Console.Write('│');
            }

            Console.SetCursorPosition(offsetX - 1, offsetY - 1);
            Console.Write('┌');

            Console.SetCursorPosition(offsetX + loadedMap.GetLength(0), offsetY - 1);
            Console.Write('┐');

            Console.SetCursorPosition(offsetX - 1, offsetY + loadedMap.GetLength(1));
            Console.Write('└');

            Console.SetCursorPosition(offsetX + loadedMap.GetLength(0), offsetY + loadedMap.GetLength(1));
            Console.Write('┘');

            Console.SetCursorPosition(offsetX - 1, offsetY + loadedMap.GetLength(1) + 1);
            Console.Write("┌───────────────────────────────────────────┐"); Console.SetCursorPosition(offsetX - 1, offsetY + loadedMap.GetLength(1) + 2);
            Console.Write("│                                           │"); Console.SetCursorPosition(offsetX - 1, offsetY + loadedMap.GetLength(1) + 3);
            Console.Write("│                                           │"); Console.SetCursorPosition(offsetX - 1, offsetY + loadedMap.GetLength(1) + 4);
            Console.Write("└───────────────────────────────────────────┘");
        }

        public void Update()
        {
            
            playerDamage = player.damage;
            playerHealth = player.health;
            playerMaxHealth = player.maxHealth;
        }


        public void Draw()
        {
            Console.SetCursorPosition(offsetX + 1, offsetY + loadedMap.GetLength(1) + 2);
            Console.Write("Player Health: " + playerHealth + "/" + playerMaxHealth + "    ");

            Console.SetCursorPosition(offsetX + 24, offsetY + loadedMap.GetLength(1) + 2);
            Console.Write("Player Damage: " + playerDamage);

            Console.SetCursorPosition(offsetX + 1, offsetY + loadedMap.GetLength(1) + 3);
            Console.Write("                                     ");
            Console.SetCursorPosition(offsetX + 1, offsetY + loadedMap.GetLength(1) + 3);
            Console.Write(textToDisplay);

            textToDisplay = "";

        }

        public void DisplayUiText(string textToDisplay)
        {
            this.textToDisplay = textToDisplay;
        }
    }
}
