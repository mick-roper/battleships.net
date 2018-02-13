using System;
using System.Collections.Generic;
using System.Text;

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

            x = renderer.Width / 2 - 5;
            y += 1;

            renderer.SetPosition(x, y);
        }

        private void DrawGrids(IRenderer renderer)
        {
            int x = 5, y = 5;

            renderer.SetColour(ConsoleColor.Cyan);

            renderer.SetPosition(x, y);

            // 1: draw player grid
            var buffer = new StringBuilder(10);
            Grid grid = player.MyGrid;

            for (int row = 0; row < grid.Height; row++)
            {
                for (int col = 0; col < grid.Width; col++)
                {
                    buffer.Append(player.MyGrid[row, col].Content);
                }

                renderer.Draw(buffer.ToString());
                renderer.SetPosition(x++, y);

                buffer.Clear();
            }

            // 2: draw target grid
            x = grid.Width + 10;
            renderer.SetPosition(x, y);

            grid = player.TargetGrid;

            for (int row = 0; row < grid.Height; row++)
            {
                for (int col = 0; col < grid.Width; col++)
                {
                    buffer.Append(player.MyGrid[row, col].Content);
                }

                renderer.Draw(buffer.ToString());
                renderer.SetPosition(x++, y);

                buffer.Clear();
            }

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
