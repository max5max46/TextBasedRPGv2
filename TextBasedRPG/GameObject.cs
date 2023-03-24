using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TextBasedRPG
{
    internal class GameObject
    {
        public int x;
        public int y;
        public int tempX;
        public int tempY;
        public char sprite;
        public ConsoleColor spriteColor = ConsoleColor.White;

        static public int offsetX = Universal.OFFSET_X;
        static public int offsetY = Universal.OFFSET_Y;


        public virtual void Draw()
        {
            GameManager.renderer.SendToRenderer(x, y, sprite, spriteColor);
        }
    }
}
