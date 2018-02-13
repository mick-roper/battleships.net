using System;

namespace Battleship
{
    public class Player
    {
        public Player(string name)
        {
            if (string.IsNullOrWhiteSpace(name)) throw new ArgumentException("value cannot be null, empty or whitespace", nameof(name));

            Name = name;
        }

        public string Name { get; }
        public Grid MyGrid { get; } = new Grid();
        public Grid TargetGrid { get; } = new Grid();

        public override string ToString()
        {
            return Name;
        }
    }
}
