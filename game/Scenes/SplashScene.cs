using System;
using System.Collections.Generic;
using System.Text;

namespace Battleships.Scenes
{
    class SplashScene : Scene
    {
        const int MAX_TICKS = 25;
        const string SPLASH_MESSAGE = "Battleships!";

        bool isFirstRender = true;

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

            if (isFirstRender)
            {
                renderer.Clear();
                isFirstRender = false;
            }

            WriteBannerMessaeg(SPLASH_MESSAGE, renderer);
        }

        public override void Update(TimeSpan elapsed)
        {
            // todo: transition to other scene after ticks have elapsed

            return;
        }
    }
}
