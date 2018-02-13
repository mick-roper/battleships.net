using System;
using System.Collections.Generic;
using System.Text;

namespace Battleship
{
    public class Player
    {
        public Player(string name)
        {
            Name = name;
        }

        public string Name { get; }
        public Grid MyGrid { get; } = new Grid();
        public Grid TargetGrid { get; } = new Grid();
    }
}
