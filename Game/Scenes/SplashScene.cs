using System;
using System.Collections.Generic;
using System.Text;

namespace Battleship.Scenes
{
    class SplashScene : Scene
    {
        int drawCount = 0;

        public SplashScene(Game game) : base(game)
        {
        }

        public override void Draw()
        {
            drawCount = 1;

            const string splashMessage = "Battleships!";

            Console.CursorVisible = false;

            var x = (game.Columns / 2) - (splashMessage.Length / 2);
            const int y = 2;

            Console.SetCursorPosition(x, y);

            Console.Write(splashMessage);

            if (drawCount >= 50) // draw the player select screen
            {

            }
        }

        public override void HandleInput()
        {
            // nothing to handle
        }

        public override void Update()
        {
            // nothing to update
        }
    }
}
