using System;
using System.Collections.Generic;
using System.Text;

namespace Battleship.Scenes
{
    abstract class Scene
    {
        protected readonly Game game;

        public Scene(Game game)
        {
            this.game = game;
        }

        public abstract void HandleInput(IInputHandler inputHandler);
        public abstract void Update();
        public abstract void Draw(IRenderer renderer);
    }
}
