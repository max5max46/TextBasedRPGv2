using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace TextBasedRPG
{
    static public class Universal
    {
        static public Random RNG = new Random();

        public const int OFFSET_X = 1;
        public const int OFFSET_Y = 1;
        public const int PLAYER_HEALTH = 10;
        public const int PLAYER_DAMAGE = 1;

        static public int GenerateRandomNumber(int min, int max)
        {
            return RNG.Next(min, max + 1);
        }

        static public char[,] loadMap()
        {
            string[] convertTo2DArray = File.ReadAllText("map.txt").Split('\n');
            char [,]loadedMap = new char[convertTo2DArray[1].Length, convertTo2DArray.Length];

            for (int i = 0; i < convertTo2DArray.Length; i++)
            {
                for (int j = 0; j < convertTo2DArray[i].Length; j++)
                {
                    loadedMap[j, i] = convertTo2DArray[i][j];
                }
            }

            return loadedMap;
        }

        static public void DisplayText(string textToDisplay)
        {
            GameManager.UI.DisplayUiText(textToDisplay);
        }
    }
}
