using System;
using System.Threading;

namespace Battleship
{
    class Program
    {
        const int FRAME_DELAY = 200;

        static void Main(string[] args)
        {
            IRenderer renderer = new ConsoleRenderer(new DoubleBuffer(100, 50));
            IInputHandler inputHandler = new ConsoleInputHandler();

            try
            {
                var game = new Game(renderer, inputHandler);

                Console.CancelKeyPress += (s, e) => { e.Cancel = true; game.Quit(); };

                game.Init();

                while (game.State != Game.GameState.Exit)
                {
                    game.Loop();

                    Thread.Sleep(FRAME_DELAY);
                }

                game.Cleanup();
            }
            catch (Exception ex)
            {
                Console.ForegroundColor = ConsoleColor.Red;

                Console.Clear();

                Console.SetCursorPosition(0, 0);

                Console.Write("An unrecoverable error occured!!\n\n");
                Console.Write(ex);

                Console.Write("\n\nPress 'enter' key to exit...");

                Console.ReadKey();
            }
        }
    }
}
