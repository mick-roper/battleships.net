using System;

namespace Battleship.Scenes
{
    class GameoverScene : Scene
    {
        readonly Player winner;

        public GameoverScene(Game game, Player winner) : base(game, "Game over!")
        {
            this.winner = winner ?? throw new ArgumentNullException(nameof(winner));
        }

        public override void HandleInput(IInputHandler inputHandler)
        {
            // do nothing
        }

        public override void Update()
        {
            // do nothing
        }

        protected override void DrawScene(IRenderer renderer)
        {
            var message = $"{winner.Name} won!";

            int x, y;

            x = (renderer.Width / 2) - (message.Length / 2);
            y = 5;

            renderer.SetColour(ConsoleColor.Blue);

            renderer.SetPosition(x, y);
        }
    }
}
