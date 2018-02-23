using System;
using System.Collections.Generic;
using System.Text;

namespace Battleships
{
    abstract class Scene
    {
        public Scene(IGame game)
        {
            Game = game;
        }

        protected IGame Game { get; }

        public abstract void HandleInput(IInputService inputService);
        public abstract void Update(int ticks);
        public abstract void Render(IRenderer renderer);
    }
}
