using Battleship.Scenes;
using System;
using System.Collections.Generic;
using System.Text;

namespace Battleship
{
    class Game : IDisposable
    {
        private Scene currentScene;

        public Game(int rows, int columns)
        {
            Rows = rows;
            Columns = columns;

            if (rows > Console.LargestWindowHeight) throw new ArgumentOutOfRangeException(nameof(rows), rows, $"value cannot be greater than {Console.LargestWindowHeight}");
            if (columns > Console.LargestWindowWidth) throw new ArgumentOutOfRangeException(nameof(columns), columns, $"value cannot be greater than {Console.LargestWindowWidth}");

            Console.SetBufferSize(Rows, columns);
            Console.SetWindowSize(Rows, Columns);

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
            Running,
            Exit
        }
    }
}
