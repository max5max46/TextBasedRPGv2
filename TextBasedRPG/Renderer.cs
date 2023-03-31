using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TextBasedRPG
{
    internal class Renderer
    {
        private Sprite[,] renderBuffer1;
        private Sprite[,] renderBuffer2;
        private Sprite[,] renderBufferReset;
        private bool onBuffer1;

        public Renderer()
        {
            char[,] loadedMap = Universal.loadMap();
            
            renderBufferReset = new Sprite[loadedMap.GetLength(0), loadedMap.GetLength(1)];
            renderBuffer1 = new Sprite[loadedMap.GetLength(0), loadedMap.GetLength(1)];
            renderBuffer2 = new Sprite[loadedMap.GetLength(0), loadedMap.GetLength(1)];

            onBuffer1 = true;

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
                    renderBufferReset[x, y] = new Sprite(changeTile, ConsoleColor.White);
                }
            }

            ResetRenderBuffer();
        }

        public void SendToRenderer(Vector2 position, Sprite sprite)
        {
            if (onBuffer1)
            {
                if (renderBuffer1[position.x, position.y].renderPriority >= sprite.renderPriority)
                    renderBuffer1[position.x, position.y] = sprite;
            }
            else
            {
                if (renderBuffer2[position.x, position.y].renderPriority >= sprite.renderPriority)
                    renderBuffer2[position.x, position.y] = sprite;
            }
        }

        public void Render()
        {
            for (int x = 0; x < renderBuffer1.GetLength(0); x++)
            {
                for (int y = 0; y < renderBuffer1.GetLength(1); y++)
                {
                    if (onBuffer1)
                    {
                        if (renderBuffer1[x, y] != renderBuffer2[x, y])
                        {
                            Console.SetCursorPosition(x + Universal.OFFSET_X, y + Universal.OFFSET_Y);
                            Console.ForegroundColor = renderBuffer1[x, y].color;
                            Console.Write(renderBuffer1[x, y].character);
                            Console.ResetColor();
                        }
                    }
                    else
                    {
                        if (renderBuffer2[x, y] != renderBuffer1[x, y])
                        {
                            Console.SetCursorPosition(x + Universal.OFFSET_X, y + Universal.OFFSET_Y);
                            Console.ForegroundColor = renderBuffer2[x, y].color;
                            Console.Write(renderBuffer2[x, y].character);
                            Console.ResetColor();
                        }
                    }
                }
            }

            if (onBuffer1)
                onBuffer1 = false;
            else
                onBuffer1 = true;

            ResetRenderBuffer();
        }

        void ResetRenderBuffer()
        {
            if (onBuffer1)
            {
                for (int x = 0; x < renderBufferReset.GetLength(0); x++)
                    for (int y = 0; y < renderBufferReset.GetLength(1); y++)
                        renderBuffer1[x, y] = renderBufferReset[x, y];
            }
            else
            {
                for (int x = 0; x < renderBufferReset.GetLength(0); x++)
                    for (int y = 0; y < renderBufferReset.GetLength(1); y++)
                        renderBuffer2[x, y] = renderBufferReset[x, y];
            }
        }
    }
}
