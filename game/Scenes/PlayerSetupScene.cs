﻿using Battleships.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace Battleships.Scenes
{
    class PlayerSetupScene : Scene
    {
        bool isFirstRender = true;
        bool playerNameInputComplete = false;

        StringBuilder playerNameBuilder = new StringBuilder(10);

        public PlayerSetupScene(IGame game) : base(game)
        {
        }

        public override void HandleInput(IInputService inputService)
        {
            if (!isFirstRender)
            {
                var c = inputService.ReadChar();

                playerNameInputComplete = c == '\r';

                if (!playerNameInputComplete)
                {
                    playerNameBuilder.Append(c);
                }
            }
        }

        public override void Render(IRenderer renderer)
        {
            renderer.ShowCursor(false);

            if (isFirstRender)
            {
                renderer.Clear();
                isFirstRender = false;
            }

            int y = 1;

            WriteCentral("Player Setup", renderer, y);

            y = 3;

            WriteCentral("Enter your name", renderer, y);

            y = 5;

            renderer.SetPosition((renderer.Width / 2) + playerNameBuilder.Length, y);

            renderer.ShowCursor(true);
        }

        public override void Update()
        {
            if (playerNameInputComplete)
            {
                Player player = new Player(playerNameBuilder.ToString());
                Scene nextScene = new BoardSetupScene(Game, player);
                Game.TransitionTo(nextScene);
            }
        }
    }
}
