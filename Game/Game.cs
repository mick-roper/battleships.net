using Battleship.Scenes;
using System;
using System.Collections.Generic;
using System.Text;

namespace Battleship
{
    class Game : IDisposable
    {
        private Scene currentScene;

        public Game()
        {
            Rows = Console.WindowHeight;
            Columns = Console.WindowWidth;
        }

        public void Init()
        {
            currentScene = new SplashScene(this);

            State = GameState.Running;
        }

        public int Rows { get; }
        public int Columns { get; }

        public GameState State { get; private set; }

        public void Dispose()
        {
            // do nothing -for now
        }

        internal void Loop()
        {
            currentScene.HandleInput();

            currentScene.Update();

            currentScene.Draw();
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
