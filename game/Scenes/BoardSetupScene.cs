using Battleships.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace Battleships.Scenes
{
    class BoardSetupScene : Scene
    {
        Player player;

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
            return; // draw the grid with pieces
        }

        public override void Update()
        {
            return; // update the players board
        }
    }
}
