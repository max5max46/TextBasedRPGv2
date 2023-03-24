using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TextBasedRPG
{
    internal class Renderer
    {
        char[,] spritesToRender;
        ConsoleColor[,] spriteColors;

        public Renderer()
        {
            ResetRenderBuffer();
        }

        public void SendToRenderer(int x, int y, char sprite, ConsoleColor color = ConsoleColor.White)
        {
            spritesToRender[x,y] = sprite;
            spriteColors[x,y] = color;
        }

        public void Render()
        {
            for (int x = 0; x < spritesToRender.GetLength(0); x++)
            {
                for (int y = 0; y < spritesToRender.GetLength(1); y++)
                {
                    Console.SetCursorPosition(x + Universal.OFFSET_X, y + Universal.OFFSET_Y);
                    Console.ForegroundColor = spriteColors[x, y];
                    Console.Write(spritesToRender[x, y]);
                    Console.ResetColor();
                }
            }

            ResetRenderBuffer();
        }

        void ResetRenderBuffer()
        {
            spritesToRender = Universal.loadMap();

            for (int x = 0; x < spritesToRender.GetLength(0); x++)
            {
                for (int y = 0; y < spritesToRender.GetLength(1); y++)
                {
                    char changeTile = spritesToRender[x, y];

                    switch (changeTile)
                    {
                        case 'X':
                            changeTile = '█';
                            break;

                        case 'W':
                            changeTile = 'W';
                            break;

                        default:
                            changeTile = ' ';
                            break;
                    }
                    spritesToRender[x, y] = changeTile;
                }
            }

            spriteColors = new ConsoleColor[spritesToRender.GetLength(0), spritesToRender.GetLength(1)];

            for (int x = 0; x < spriteColors.GetLength(0); x++)
            {
                for (int y = 0; y < spriteColors.GetLength(1); y++)
                {
                    spriteColors[x,y] = ConsoleColor.White;
                }
            }

        }

    }
}
