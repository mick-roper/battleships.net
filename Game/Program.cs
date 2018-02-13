using System;

namespace Game
{
    class Program
    {
        static void Main(string[] args)
        {
            using (var game = new Game())
            {
                while (game.State != Game.GameState.Exit)
                {
                    game.HandleInput();

                    game.Update();

                    game.Draw();
                }
            }
        }
    }
}
