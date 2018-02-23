using System;

namespace Battleships
{
    class Program
    {
        static int Main(string[] args)
        {
            IInputService inputService = null;
            IRenderer renderer = null;

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
