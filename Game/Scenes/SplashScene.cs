using System;
using System.Collections.Generic;
using System.Text;

namespace Battleship.Scenes
{
    class SplashScene : Scene
    {
        public SplashScene(Game game) : base(game)
        {
        }

        public override void Draw()
        {
            const string splashMessage = "/t/t/tBattleships!";

            Console.CursorVisible = false;

            var x = game.Rows - (splashMessage.Length / 2);
            const int y = 5;

            Console.SetCursorPosition(x, y);

            Console.Write(splashMessage);
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
