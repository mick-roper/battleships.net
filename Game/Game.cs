using Battleship.Scenes;
using System;

namespace Battleship
{
    class Game
    {
        readonly IRenderer renderer;
        readonly IInputHandler inputHandler;

        private Scene currentScene;
        bool sceneTransitionThisLoop = false;

        public Game(IRenderer renderer, IInputHandler inputHandler)
        {
            this.renderer = renderer ?? throw new ArgumentNullException(nameof(renderer));
            this.inputHandler = inputHandler ?? throw new ArgumentNullException(nameof(inputHandler));
        }

        internal void Quit()
        {
            State = GameState.Exit;
        }

        internal void Cleanup()
        {
            currentScene = null;
        }

        public void Init()
        {
            currentScene = new SplashScene(this);

            State = GameState.Running;
        }

        public GameState State { get; private set; }

        internal void Loop()
        {
            sceneTransitionThisLoop = false;

            currentScene.HandleInput(inputHandler);

            currentScene.Update();

            if (!sceneTransitionThisLoop)
            {
                currentScene.Draw(renderer); 
            }

            renderer.Commit();
        }

        public void TransitionTo(Scene scene)
        {
            sceneTransitionThisLoop = true;

            currentScene = scene;
        }

        public enum GameState
        {
            NotInitialised,
            Running,
            Exit
        }
    }
}
