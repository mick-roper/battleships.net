﻿using System;
using System.Collections.Generic;
using System.Text;

namespace Battleship.Scenes
{
    class PlayScene : Scene
    {
        readonly Player player;
        readonly Player computer;

        SceneState state;
        string input;

        int playerShots = 0, compShots = 0, playerHits = 0, compHits = 0;

        public PlayScene(Game game, Player player) : base(game)
        {
            this.player = player ?? throw new ArgumentNullException(nameof(player));
            this.computer = new Player("Computer");

            state = SceneState.NotInitialised;
        }

        protected override void DrawScene(IRenderer renderer)
        {
            throw new NotImplementedException();
        }

        public override void HandleInput(IInputHandler inputHandler)
        {
            if (state > SceneState.NotInitialised)
            {
                input = inputHandler.ReadInput();
            }
        }

        public override void Update()
        {
            switch (state)
            {
                default:
                case SceneState.NotInitialised:
                    {
                        state = SceneState.PlayerPlacePieces;
                    }
                    break;
            }
        }

        enum SceneState
        {
            NotInitialised,
            PlayerPlacePieces,
            ComputerPlacePieces,
            PlayerTurnToShoot,
            ComputerTurnToShoot,
            GameOver
        }
    }
}