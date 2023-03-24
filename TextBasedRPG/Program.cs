using System;
using System.IO;

namespace TextBasedRPG
{
    internal class Program
    {
        public static GameManager gameManager;
        static void Main(string[] args)
        {
            Console.CursorVisible = false;
            gameManager = new GameManager();
            gameManager.Game();
        }
    }
}
