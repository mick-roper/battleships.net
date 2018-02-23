using System;
using System.Collections.Generic;
using System.Text;

namespace Battleships.Entities
{
    class Grid
    {
        public const char X_AXIS_OFFSET = 'A', Y_AXIS_OFFSET = '0';

        readonly IDictionary<Coordinate, Tile> tiles = new Dictionary<Coordinate, Tile>(BOUNDARY * BOUNDARY);

        public const byte BOUNDARY = 10;

        public Grid()
        {
            for (byte y = 0; y < BOUNDARY; y++)
            {
                for (byte x = 0; x < BOUNDARY; x++)
                {
                    var t = new Coordinate(ToXChar(x), ToYChar(y));
                    tiles[t] = Tile.Water;
                }
            }
        }

        public Tile GetTileAt(char x, char y)
        {
            var coord = new Coordinate(x, y);

            return tiles[coord];
        }

        public static char ToXChar(byte x)
        {
            return (char)(x + X_AXIS_OFFSET);
        }

        public static char ToYChar(byte y)
        {
            return (char)(y + Y_AXIS_OFFSET);
        }
    }
}
