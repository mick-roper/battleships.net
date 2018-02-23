using Battleships.Scenes;
using System;
using System.Threading;

namespace Battleships
{
    sealed class Game : IGame
    {
        const int MAX_UPDATES_PER_SECOND = 10;
        const int MIN_WAIT_TICKS = 1000 / MAX_UPDATES_PER_SECOND;

        Scene currentScene;
        IInputService inputService;
        IRenderer renderer;

        GameState state;

        bool sceneTransitionThisTick = false;

        public Game(IInputService inputService, IRenderer renderer)
        {
            this.inputService = inputService ?? throw new ArgumentNullException(nameof(inputService));
            this.renderer = renderer ?? throw new ArgumentNullException(nameof(renderer));

            currentScene = new SplashScene(this);

            state = GameState.Initialised;
        }

        public int Run()
        {
            if (state != GameState.Initialised) return ExitCodes.NOT_INITIALISED;

            state = GameState.Running;

            long t = 0, delay = 0, lastUpdate = GetTicks();

            do
            {
                t = GetTicks();
                delay = lastUpdate + MIN_WAIT_TICKS;

                // calculate delay
                if (t < delay)
                {
                    Thread.Sleep(TimeSpan.FromTicks(delay - t));
                }

                lastUpdate = GetTicks();

                sceneTransitionThisTick = false;

                currentScene.HandleInput(inputService);

                currentScene.Update(TimeSpan.FromTicks(lastUpdate - t));

                if (!sceneTransitionThisTick)
                {
                    renderer.Clear();

                    currentScene.Render(renderer); 
                }
            }
            while (state != GameState.Exiting);

            return ExitCodes.OK;
        }

        public void TransitionTo(Scene scene)
        {
            currentScene = scene;
            sceneTransitionThisTick = true;
        }

        public void Exit()
        {
            state = GameState.Exiting;
        }

        private static long GetTicks()
        {
            return DateTime.Now.Ticks;
        }

        enum GameState
        {
            Initialising,
            Initialised,
            Running,
            Exiting
        }
    }
}
