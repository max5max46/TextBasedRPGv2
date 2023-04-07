using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TextBasedRPG
{
    internal class GameObject
    {
        public Vector2 position;
        public Vector2 tempPosition;
        public Sprite sprite;

        static public int offsetX = Setting.OFFSET_X;
        static public int offsetY = Setting.OFFSET_Y;


        public virtual void Draw()
        {
            GameManager.renderer.SendToRenderer(position, sprite);
        }
    }
}
