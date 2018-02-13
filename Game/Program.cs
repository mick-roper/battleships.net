using System;
using System.Threading;

namespace Battleship
{
    class Program
    {
        const int FRAME_DELAY = 200;

        static void Main(string[] args)
        {
            const int columns = 100, rows = 25;

            try
            {
                using (var game = new Game(rows, columns))
                {
                    while (game.State != Game.GameState.Exit)
                    {
                        game.Loop();

                        Thread.Sleep(FRAME_DELAY);
                    }
                }
            }
            catch (Exception ex)
            {
                Console.ForegroundColor = ConsoleColor.Red;

                Console.Clear();
                Console.SetCursorPosition(0, 0);

                Console.Write("An unrecoverable error occured!!\n\n");
                Console.Write(ex);

                Console.Write("\n\nPress any key to exit...");

                Console.ReadKey();
            }
        }
    }
}
