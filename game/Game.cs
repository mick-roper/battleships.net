using Battleships.Scenes;
using System;
using System.Threading;

namespace Battleships
{
    sealed class Game : IGame
    {
        const int MAX_UPDATES_PER_SECOND = 5;
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

            do
            {
                sceneTransitionThisTick = false;

                currentScene.HandleInput(inputService);

                currentScene.Update();

                if (!sceneTransitionThisTick)
                {
                    currentScene.Render(renderer); 
                }

                Thread.Sleep(MIN_WAIT_TICKS);
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
