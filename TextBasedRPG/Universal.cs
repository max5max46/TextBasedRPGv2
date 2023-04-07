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
        static public string mapName;

        static public int GenerateRandomNumber(int min, int max)
        {
            return RNG.Next(min, max + 1);
        }

        static public char[,] loadMap()
        {
            string[] convertTo2DArray = File.ReadAllText(mapName).Split('\n');
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
