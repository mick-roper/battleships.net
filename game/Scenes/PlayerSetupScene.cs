using System;
using System.Collections.Generic;
using System.Text;

namespace Battleships.Scenes
{
    class PlayerSetupScene : Scene
    {
        bool isFirstRender = true;

        public PlayerSetupScene(IGame game) : base(game)
        {
        }

        public override void HandleInput(IInputService inputService)
        {
            return;
        }

        public override void Render(IRenderer renderer)
        {
            renderer.ShowCursor(false);

            if (isFirstRender)
            {
                renderer.Clear();
                isFirstRender = false;
            }

            WriteBanner("Player Setup", renderer);
        }

        public override void Update()
        {
            return;
        }
    }
}
