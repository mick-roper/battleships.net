using System;
using System.Collections.Generic;
using System.Text;

namespace Battleships
{
    abstract class Scene
    {
        public Scene(IGame sceneManager)
        {
            SceneManager = sceneManager;
        }

        protected IGame SceneManager { get; }

        public abstract void HandleInput(IInputService inputService);
        public abstract void Update(int ticks);
        public abstract void Render(IRenderer renderer);
    }
}
