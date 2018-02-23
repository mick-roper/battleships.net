using System;
using System.Collections.Generic;
using System.Text;

namespace Battleships
{
    abstract class Scene
    {
        public Scene(ISceneManager sceneManager)
        {
            SceneManager = sceneManager;
        }

        protected ISceneManager SceneManager { get; }

        public abstract void HandleInput();
        public abstract void Update();
        public abstract void Render(IRenderer renderer);
    }
}
