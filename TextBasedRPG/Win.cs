using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TextBasedRPG
{
    public static class Win
    {
        public static void WinScreen()
        {
            Console.Clear();
            Console.WriteLine("\n ────────────────────────────────────────\n" +
                              "   █▄ ▄█ ▄██▄ █  █    █   █ ▀█▀ █▄ █  █\n" +
                              "    ▀█▀  █  █ █  █    █ ▄ █  █  █▀██  █\n" +
                              "     █   ▀██▀ ▀██▀    ▀█▀█▀ ▄█▄ █  █  ▄\n" +
                              " ────────────────────────────────────────\n\n" +
                              " Thank you for Playing! (Press any Button to Exit)"
                              );


            Console.ReadKey(true);
            GameManager.EndGame();

        }

    }
}
