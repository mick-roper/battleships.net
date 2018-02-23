using System;
using System.Collections.Generic;
using System.Text;

namespace Battleships.Entities
{
    class Player
    {
        public Player(string name)
        {
            Name = name;
        }

        public GameBoard Board { get; } = new GameBoard();
        public string Name { get; }
    }
}
