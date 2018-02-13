using System;
using System.Collections.Generic;
using System.Text;

namespace Battleship.Scenes
{
    class PlayerConfigScene : Scene
    {
        SceneState state;
        string playerName;

        public PlayerConfigScene(Game game) : base(game)
        {
            state = SceneState.DrawingBanner;
        }

        public override void Draw(IRenderer renderer)
        {
            const string banner = "Please type your name";

            var x = (game.Columns / 2) - (banner.Length / 2);
            const int y = 2;

            renderer.ChangeCursorVisibility(false);

            renderer.SetPosition(x, y);

            renderer.Write(banner);

            renderer.SetPosition(x, y + 2);

            renderer.SetColour(ConsoleColor.Green);

            state = SceneState.WaitingForInput;
        }

        public override void HandleInput(IInputHandler inputHandler)
        {
            if (state == SceneState.WaitingForInput)
            {
                playerName = inputHandler.ReadInput();

                state = SceneState.ReadyForTransition;
            }
        }

        public override void Update()
        {
            if (state == SceneState.ReadyForTransition)
            {
                throw new NotImplementedException("transition not wired up yet!");
            }
        }

        enum SceneState
        {
            DrawingBanner = 0,
            WaitingForInput = 1,
            ReadyForTransition = 2
        }
    }
}
