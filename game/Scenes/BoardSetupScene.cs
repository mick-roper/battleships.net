using Battleships.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace Battleships.Scenes
{
    class BoardSetupScene : GridScene
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

            WriteCentral($"{player.Name} - place your pieces", renderer);

            int x = 0, y = 5;

            DrawGrid(player.Grid, x, y);

            DrawInstruction(x + 30, y);
        }

        private void DrawInstruction(int x, int y)
        {
            throw new NotImplementedException();
        }

        private void DrawGrid(Grid grid, int x, int y)
        {
            throw new NotImplementedException();
        }

        public override void Update()
        {
            return; // update the players board
        }
    }
}
