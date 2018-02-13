using System;
using System.Collections.Generic;
using System.Text;

namespace Battleship.Scenes
{
    class PlayScene : Scene
    {
        readonly Player player;

        public PlayScene(Game game, Player player) : base(game)
        {
            this.player = player ?? throw new ArgumentNullException(nameof(player));
        }

        protected override void DrawScene(IRenderer renderer)
        {
            throw new NotImplementedException();
        }

        public override void HandleInput(IInputHandler inputHandler)
        {
            throw new NotImplementedException();
        }

        public override void Update()
        {
            throw new NotImplementedException();
        }
    }
}
