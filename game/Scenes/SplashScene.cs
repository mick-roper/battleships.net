using System;
using System.Collections.Generic;
using System.Text;

namespace Battleships.Scenes
{
    class SplashScene : Scene
    {
        const int MAX_TICKS = 25;
        const string SPLASH_MESSAGE = "Battleships!";

        public SplashScene(IGame game) : base(game)
        {
        }

        public override void HandleInput(IInputService inputService)
        {
            return; // nothing to handle
        }

        public override void Render(IRenderer renderer)
        {
            renderer.ShowCursor(false);

            int messageLength = SPLASH_MESSAGE.Length;
            int x, y;

            x = (renderer.Width / 2) + (messageLength / 2);
            y = 1;

            for (int i = 0; i < messageLength; i++)
            {
                renderer.Draw(SPLASH_MESSAGE[i], x += i, y);
            }
        }

        public override void Update(TimeSpan elapsed)
        {
            // todo: transition to other scene after ticks have elapsed

            return;
        }
    }
}
