using Battleship.Scenes;
using System;

namespace Battleship
{
    class Game
    {
        readonly IRenderer renderer;
        readonly IInputHandler inputHandler;

        private Scene currentScene;

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
            currentScene.HandleInput(inputHandler);

            currentScene.Update();

            currentScene.Draw(renderer);

            renderer.Commit();
        }

        public void TransitionTo(Scene scene)
        {
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
