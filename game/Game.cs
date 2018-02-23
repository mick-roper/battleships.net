﻿using Battleships.Scenes;
using System;
using System.Threading;

namespace Battleships
{
    sealed class Game : IGame
    {
        Scene currentScene;
        IInputService inputService;
        IRenderer renderer;

        GameState state;
        int tickCount;

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
                tickCount += 1;
                sceneTransitionThisTick = false;

                currentScene.HandleInput(inputService);

                currentScene.Update(tickCount);

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

        enum GameState
        {
            Initialising,
            Initialised,
            Running,
            Exiting
        }
    }
}