using System;

namespace Battleships
{
    class Program
    {
        static int Main(string[] args)
        {
            var game = new Game();

            return game.Run();
        }
    }
}
