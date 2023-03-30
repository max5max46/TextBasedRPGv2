using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TextBasedRPG
{
    internal class Renderer
    {
        Sprite[,] spritesToRender;
        private Sprite[,] spritesToRenderReset;

        public Renderer()
        {
            char[,] loadedMap = Universal.loadMap();
            spritesToRenderReset = new Sprite[loadedMap.GetLength(0), loadedMap.GetLength(1)];
            spritesToRender = new Sprite[loadedMap.GetLength(0), loadedMap.GetLength(1)];

            for (int x = 0; x < loadedMap.GetLength(0); x++)
            {
                for (int y = 0; y < loadedMap.GetLength(1); y++)
                {
                    char changeTile = loadedMap[x, y];

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
                    spritesToRenderReset[x, y] = new Sprite(changeTile, ConsoleColor.White);
                }
            }

            ResetRenderBuffer();
        }

        public void SendToRenderer(Vector2 position, Sprite sprite)
        {
            if (spritesToRender[position.x, position.y].renderPriority >= sprite.renderPriority)
            {
                spritesToRender[position.x, position.y] = sprite;
            }
        }

        public void Render()
        {
            for (int x = 0; x < spritesToRender.GetLength(0); x++)
            {
                for (int y = 0; y < spritesToRender.GetLength(1); y++)
                {
                    Console.SetCursorPosition(x + Universal.OFFSET_X, y + Universal.OFFSET_Y);
                    Console.ForegroundColor = spritesToRender[x, y].color;
                    Console.Write(spritesToRender[x, y].character);
                    Console.ResetColor();
                }
            }

            ResetRenderBuffer();
        }

        void ResetRenderBuffer()
        {
            for (int x = 0; x < spritesToRenderReset.GetLength(0); x++)
                for (int y = 0; y < spritesToRenderReset.GetLength(1); y++)
                    spritesToRender[x, y] = spritesToRenderReset[x, y];
        }
    }
}
