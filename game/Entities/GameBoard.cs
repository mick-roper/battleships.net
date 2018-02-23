using System;
using System.Collections.Generic;
using System.Text;

namespace Battleships.Entities
{
    class GameBoard
    {
        readonly IDictionary<Tuple<char, byte>, Tile> tiles = new Dictionary<Tuple<char, byte>, Tile>(BOUNDARY * BOUNDARY);

        const byte BOUNDARY = 10;

        public GameBoard()
        {
            for (byte y = 0; y < BOUNDARY; y++)
            {
                for (char x = (char)65; x < 65 + BOUNDARY; x++)
                {
                    tiles[new Tuple<char, byte>(x, y)] = Tile.Sea;
                }
            }
        }

        enum Tile
        {
            Sea,
            Destroyer,
            Frigate,
            Cruiser,
            Battleship,
            Carrier,
            Shot_Miss,
            Shot_Hit
        }
    }
}
