using Battleships.Scenes;
using System;
using System.Threading;

namespace Battleships
{
    sealed class Game : IGame
    {
        const int MIN_FPS = 1000 / 30;

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

            long t = 0, lastUpdate = GetTicks();
            TimeSpan elapsed;

            do
            {
                t = GetTicks();

                while (t < lastUpdate + MIN_FPS)
                {
                    Thread.Sleep(TimeSpan.FromTicks((lastUpdate + MIN_FPS) - t));
                }

                lastUpdate = GetTicks();

                sceneTransitionThisTick = false;

                currentScene.HandleInput(inputService);

                currentScene.Update(elapsed);

                if (!sceneTransitionThisTick)
                {
                    currentScene.Render(renderer); 
                }

                Thread.Sleep(200);
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
