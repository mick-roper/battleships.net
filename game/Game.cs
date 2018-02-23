using System;
using System.Threading;

namespace Battleships
{
    sealed class Game
    {
        GameState state;
        Scene currentScene;
        int tickCount;

        public Game()
        {
            state = GameState.Initialising;

            // todo: setup stuff

            state = GameState.Initialised;
        }

        public int Run()
        {
            if (state != GameState.Initialised) return ExitCodes.NOT_INITIALISED;

            state = GameState.Running;

            while (state != GameState.Exiting)
            {
                currentScene.HandleInput();



                Thread.Sleep(200);

                tickCount += 1;
            }

            return ExitCodes.OK;
        }

        enum GameState
        {
            Initialising,
            Initialised,
            Running,
            Exiting,
        }
    }
}
