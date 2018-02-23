using Battleships.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace Battleships.Scenes
{
    class BoardSetupScene : Scene
    {
        Player player;

        bool isFirstRender = true;

        public BoardSetupScene(IGame game, Player player) : base(game)
        {
            this.player = player;
        }

        public override void HandleInput(IInputService inputService)
        {
            return; // for now, do nothing
        }

        public override void Render(IRenderer renderer)
        {
            renderer.ShowCursor(false);

            if (isFirstRender)
            {
                renderer.Clear();
                isFirstRender = false;
            }

            WriteCentral("Place your pieces...", renderer);

            int x = 5, y = 5;

            player.Board.Render(x, y, renderer);
        }

        public override void Update()
        {
            return; // update the players board
        }
    }
}
