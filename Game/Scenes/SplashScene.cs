using System;
using System.Collections.Generic;
using System.Text;

namespace Battleship.Scenes
{
    class SplashScene : Scene
    {
        const byte MAX_DRAWS_BEFORE_TRANSITION = 25;
        byte drawCount = 0;

        public SplashScene(Game game) : base(game)
        {
        }

        public override void Draw()
        {
            drawCount += 1;

            const string banner = "Battleships!";

            Console.CursorVisible = false;

            var x = (game.Columns / 2) - (banner.Length / 2);
            const int y = 2;

            Console.SetCursorPosition(x, y);

            Console.Write(banner);

            if (drawCount >= MAX_DRAWS_BEFORE_TRANSITION) // draw the player select screen
            {
                game.TransitionTo(new PlayerConfigScene(game));
            }
        }

        public override void HandleInput()
        {
            // do nothing
        }

        public override void Update()
        {
            // do nothing
        }
    }
}
