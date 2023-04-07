using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TextBasedRPG
{
    internal class MainMenu
    {
        public MainMenu()
        {
            //Plays Music Track
            System.Media.SoundPlayer musicPlayer = new System.Media.SoundPlayer();
            musicPlayer.SoundLocation = "MafiaMadnessBgMusic.wav";
            musicPlayer.PlayLooping();

            Console.WriteLine("          _____   ______   _________    ____________  ____________  ________          \n" +
                              "         /     | /     |  /   ___   \\  |           | |           | |    _   \\         \n" +
                              "        /      |/      | /   /   \\   \\ |    _______| |____    ___| |   | \\   \\        \n" +
                              "       /   /|     /|   | |   |___|   | |   |______       |   |     |   |__\\   \\       \n" +
                              "      /   / |    / |   | |    ___    | |    _____|       |   |     |    ____   \\      \n" +
                              "     /   /  |___/  |   | |   |   |   | |   |          ___|   |____ |   |    \\   \\     \n" +
                              "    /   /          |   | |   |   |   | |   |         |           | |   |     \\   \\    \n" +
                              "   /___/           |___| |___|   |___| |___|         |___________| |___|      \\___\\   \n" +
                              "──────────────────────────────────────────────────────────────────────────────────────\n" +
                              "                        ██▄██  ▄▀▀▄  █▀▀▄  █▄ █  █▀▀▀  ▄▀▀█  ▄▀▀█                     \n" +
                              "                        █ █ █  █▄▄█  █  █  █▀██  █▀▀    ▀▄    ▀▄                      \n" +
                              "                        █   █  █  █  █▄▄▀  █  █  █▄▄▄  █▄▄▀  █▄▄▀                     \n\n\n" +
                              "                                Press any Button to Begin                             \n\n\n\n\n\n" +
                              " By: Dylan Adams                                                               v1.0.0 ");


            Console.ReadKey(true);
            Console.Clear();
            Console.CursorVisible = false;
        }

    }
}
