using System;

namespace Battleships
{
    class Program
    {
        static int Main(string[] args)
        {
            IInputService inputService = null;
            IRenderer renderer = null;

            var game = new Game(inputService, renderer);

            return game.Run();
        }
    }
}
