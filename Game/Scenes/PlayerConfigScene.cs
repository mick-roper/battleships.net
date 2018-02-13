using System;
using System.Collections.Generic;
using System.Text;

namespace Battleship.Scenes
{
    class PlayerConfigScene : Scene
    {
        SceneState state;
        string playerName;

        public PlayerConfigScene(Game game) : base(game, "Player Setup")
        {
            state = SceneState.DrawingBanner;
        }

        protected override void DrawScene(IRenderer renderer)
        {
            const string header = "Please type your name";

            var x = (renderer.Width / 2) - (header.Length / 2);
            int y = 2;

            renderer.ChangeCursorVisibility(false);

            renderer.SetPosition(x, y);

            renderer.Draw(header);

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
                var player = new Player(playerName);

                game.TransitionTo(new PlayScene(game, player));
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
