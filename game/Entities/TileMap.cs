using System;
using System.Collections.Generic;
using System.Text;

namespace Battleships.Entities
{
    static class TileMap
    {
        static readonly IDictionary<Tile, char> tileMap = new Dictionary<Tile, char> {
            [Tile.Water] = '~',
            [Tile.Shot_Hit] = 'O',
            [Tile.Shot_Miss] = 'X',
            [Tile.Battleship] = '#',
            [Tile.Frigate] = '#',
            [Tile.Destroyer] = '#',
            [Tile.Cruiser] = '#',
            [Tile.Carrier] = '#',
        };

        internal static char GetCharacterFor(Tile tile)
        {
            return tileMap[tile];
        }
    }
}
