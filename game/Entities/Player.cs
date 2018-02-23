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

        public string Name { get; }
    }
}
