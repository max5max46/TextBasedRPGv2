using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TextBasedRPG
{
    public struct Vector2
    {
        public int x;
        public int y;

        public Vector2(int x, int y)
        {
            this.x = x;
            this.y = y;
        }

        public static bool operator ==(Vector2 a, Vector2 b)
        {
            if (a.x == b.x && a.y == b.y)
                return true;
            return false;
        }

        public static bool operator !=(Vector2 a, Vector2 b)
        {
            return !(a == b);
        }

        public static Vector2 operator +(Vector2 a, Vector2 b)
        => new Vector2(a.x + b.x, a.y + b.y);

        public static Vector2 operator -(Vector2 a, Vector2 b)
        => new Vector2(a.x - b.x, a.y - b.y);

        public override string ToString()
        {
            return "(" + x + "," + y + ")";
        }
    }

    public struct Sprite
    {
        public char character;
        public ConsoleColor color;
        public ConsoleColor colorBG;
        public int renderPriority;

        public Sprite(char sprite = '~', ConsoleColor color = ConsoleColor.White, int renderPriority = 10, ConsoleColor colorBG = ConsoleColor.White)
        {
            this.character = sprite;
            this.color = color;
            this.renderPriority = renderPriority;
            this.colorBG = colorBG;
        }

        public static bool operator ==(Sprite a, Sprite b)
        {
            if (a.character == b.character)
                return true;
            return false;
        }

        public static bool operator !=(Sprite a, Sprite b)
        {
            return !(a == b);
        }

        public override string ToString()
        {
            return character.ToString();
        }
    }
}
