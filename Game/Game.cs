using System;
using System.Collections.Generic;
using System.Text;

namespace Game
{
    class Game : IDisposable
    {
        public Game()
        {
            
        }

        public GameState State { get; private set; }

        public enum GameState
        {
            Exit
        }

        internal void HandleInput()
        {
            throw new NotImplementedException();
        }

        internal void Draw()
        {
            throw new NotImplementedException();
        }

        internal void Update()
        {
            throw new NotImplementedException();
        }

        public void Dispose()
        {
            // do nothing
        }
    }
}
