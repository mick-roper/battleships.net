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

        public override void Draw()
        {
            const string banner = "Please type your name";

            var x = (game.Columns / 2) - (banner.Length / 2);
            const int y = 2;

            Console.SetCursorPosition(x, y);

            Console.Write(banner);

            Console.SetCursorPosition(x, y + 2);

            state = SceneState.WaitingForInput;
        }

        public override void HandleInput()
        {
            if (state > SceneState.DrawingBanner)
            {
                playerName = Console.ReadLine();

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
