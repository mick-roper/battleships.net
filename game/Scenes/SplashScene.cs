using System;
using System.Collections.Generic;
using System.Text;

namespace Battleships.Scenes
{
    class SplashScene : Scene
    {
        const int DISPLAY_FOR_TICKS = 25;
        const string SPLASH_MESSAGE = "Battleships!";

        bool isFirstRender = true;

        int tickCount;

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

            WriteCentral(SPLASH_MESSAGE, renderer);
        }

        public override void Update()
        {
            if ((tickCount += 1) >= DISPLAY_FOR_TICKS)
            {
                Game.TransitionTo(new PlayerSetupScene(Game));
            }
        }
    }
}
