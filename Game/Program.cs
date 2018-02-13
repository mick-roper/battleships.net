using System;
using System.Threading;

namespace Battleship
{
    class Program
    {
        const int FRAME_DELAY = 200;

        static void Main(string[] args)
        {
            var wrapper = new ConsoleWrapper();

            try
            {
                var game = new Game(wrapper, wrapper);

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
                wrapper.SetColour(ConsoleColor.Red);

                wrapper.Clear();

                wrapper.SetPosition(0, 0);

                wrapper.Draw("An unrecoverable error occured!!\n\n");
                wrapper.Draw(ex.ToString());

                wrapper.Draw("\n\nPress 'enter' key to exit...");

                wrapper.ReadInput();
            }
        }
    }
}
