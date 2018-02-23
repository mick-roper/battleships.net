using System;
using System.Runtime.CompilerServices;

[assembly:InternalsVisibleTo("Battleships.Tests")]

namespace Battleships
{
    class Program
    {
        static int Main(string[] args)
        {
            IInputService inputService = new ConsoleInputService();
            IRenderer renderer = new ConsoleRenderer();

            int exitCode;

            try
            {
                var game = new Game(inputService, renderer);

                exitCode = game.Run();
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex);

                exitCode = ExitCodes.ERROR;
            }

            return exitCode;
        }
    }
}
