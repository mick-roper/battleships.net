using System;
using System.Collections.Generic;

namespace Battleship.Scenes
{
    class GameSetupScene : Scene
    {
        readonly Player player;
        readonly Player computer;

        SceneState state;
        string input, pieceToPlace, coords;

        List<string> piecesToPlace = new List<string> { "Destroyer", "Frigate", "Cruiser", "Battleship", "Carrier" };

        public GameSetupScene(Game game, Player player) : base(game)
        {
            this.player = player ?? throw new ArgumentNullException(nameof(player));
            this.computer = new Player("Computer");

            state = SceneState.NotInitialised;
        }

        protected override void DrawScene(IRenderer renderer)
        {
            DrawGrids(renderer);

            switch (state)
            {
                case SceneState.PlayerSelectPieceToPlace:
                    {
                        DrawInstruction(renderer, $"select the piece you want to place: {string.Join(", ", piecesToPlace)}");
                    }
                    break;
                case SceneState.PlayerPlacePiece:
                    {
                        DrawInstruction(renderer, $"type the coords for the piece:");
                    }
                    break;
            }
        }

        public override void HandleInput(IInputHandler inputHandler)
        {
            if (state == SceneState.PlayerSelectPieceToPlace ||
                state == SceneState.PlayerPlacePiece)
            {
                input = inputHandler.ReadInput();
            }
        }

        public override void Update()
        {
            switch (state)
            {
                case SceneState.NotInitialised:
                    {
                        state = SceneState.PlayerSelectPieceToPlace;
                    }
                    break;
                case SceneState.PlayerSelectPieceToPlace:
                    {
                        pieceToPlace = input;

                        if (piecesToPlace.Remove(pieceToPlace))
                        {
                            // only transition if selected piece is valid (i.e. can be removed from the possible pieces)
                            state = SceneState.PlayerPlacePiece;
                        }
                    }
                    break;
                case SceneState.PlayerPlacePiece:
                    {
                        coords = input;

                        throw new NotImplementedException("dont know how to put a piece on the grid!");

                        if (piecesToPlace.Count > 0)
                        {
                            state = SceneState.PlayerSelectPieceToPlace;
                        }
                        else
                        {
                            state = SceneState.InitialiseComputerPlayer;
                        }
                    }
                    break;
                default:
                    throw new NotImplementedException($"state '{state}' is not implemented");
            }
        }

        private static void DrawInstruction(IRenderer renderer, string instruction)
        {
            if (string.IsNullOrWhiteSpace(instruction)) return;

            int x = (renderer.Width / 2) - (instruction.Length / 2);
            int y = 3;

            renderer.SetPosition(x, y);
            renderer.Draw(instruction);
        }

        private void DrawGrids(IRenderer renderer)
        {
            int x = 0, y = 5;

            renderer.SetColour(ConsoleColor.Cyan);

            renderer.SetPosition(x, y);

            renderer.Draw(player.MyGrid.ToString());

            // 2: draw right grid
            x = player.MyGrid.Width + 10;

            renderer.SetPosition(x, y);

            renderer.Draw(player.TargetGrid.ToString());

            renderer.ResetColour();
        }

        enum SceneState
        {
            NotInitialised,
            PlayerSelectPieceToPlace,
            PlayerPlacePiece,
            InitialiseComputerPlayer,
            SetupComplete
        }
    }
}
