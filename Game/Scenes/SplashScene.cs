namespace Battleship.Scenes
{
    class SplashScene : Scene
    {
        const byte MAX_DRAWS_BEFORE_TRANSITION = 25;
        byte drawCount = 0;

        readonly int crCount;

        public SplashScene(Game game) : base(game)
        {

        }

        protected override void DrawScene(IRenderer renderer)
        {
            drawCount += 1;

            if (drawCount >= MAX_DRAWS_BEFORE_TRANSITION) // draw the player select screen
            {
                game.TransitionTo(new PlayerConfigScene(game));
            }
        }

        public override void HandleInput(IInputHandler inputHandler)
        {
            // do nothing
        }

        public override void Update()
        {
            // do nothing
        }
    }
}
