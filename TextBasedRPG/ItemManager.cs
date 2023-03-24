using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TextBasedRPG
{
    internal class ItemManager
    {
        public Player player;
        public Item[] items;

        public ItemManager(Player player)
        {
            this.player = player;
            char[,] loadedMap = Universal.loadMap();
            int totalItems = 0;
            int itemArrayIndex = 0;

            for (int x = 0; x < loadedMap.GetLength(0); x++)
            {
                for (int y = 0; y < loadedMap.GetLength(1); y++)
                {
                    if (loadedMap[x, y] == '#' || loadedMap[x, y] == '^' || loadedMap[x, y] == '+')
                        totalItems++;
                }
            }

            items = new Item[totalItems];

            for (int x = 0; x < loadedMap.GetLength(0); x++)
            {
                for (int y = 0; y < loadedMap.GetLength(1); y++)
                {
                    if (loadedMap[x, y] == '#')
                    {
                        items[itemArrayIndex] = new ItemMaxHealthUp(x, y, player);
                        itemArrayIndex++;
                    }

                    if (loadedMap[x, y] == '^')
                    {
                        items[itemArrayIndex] = new ItemDamageUp(x, y, player);
                        itemArrayIndex++;
                    }

                    if (loadedMap[x, y] == '+')
                    {
                        items[itemArrayIndex] = new ItemHealthUp(x, y, player);
                        itemArrayIndex++;
                    }

                }
            }
        }

        public void Draw()
        {
            for (int i = 0; i < items.Length; i++)
            {
                if (items[i].collected == false)
                    items[i].Draw();
            }
        }

        public bool IsItemHere(int x, int y)
        {
            for (int i = 0; i < items.Length; i++)
            {
                if (items[i].x == x && items[i].y == y && items[i].collected == false)
                    return true;
            }

            return false;
        }

        public void CollectItem(int x, int y)
        {
            for (int i = 0; i < items.Length; i++)
            {
                if (items[i].x == x && items[i].y == y)
                    items[i].ItemEffect();
            }
        }
    }
}
