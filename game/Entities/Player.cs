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

        public Grid Grid { get; } = new Grid();
        public string Name { get; }
    }
}
