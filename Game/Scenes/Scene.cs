namespace Battleship.Scenes
{
    abstract class Scene
    {
        protected readonly Game game;

        readonly string banner;

        public Scene(Game game, string banner = null)
        {
            this.game = game;
            this.banner = string.IsNullOrWhiteSpace(banner) ? "Battleships!" : banner;
        }

        public abstract void HandleInput(IInputHandler inputHandler);
        public abstract void Update();
        protected abstract void DrawScene(IRenderer renderer);

        public void Draw(IRenderer renderer)
        {
            renderer.SetPosition(0, 0);

            DrawBanner(renderer);

            DrawScene(renderer);
        }

        private void DrawBanner(IRenderer renderer)
        {
            renderer.ChangeCursorVisibility(false);

            var x = (renderer.Width / 2) - (banner.Length / 2);
            const int y = 2;

            renderer.SetPosition(x, y);

            renderer.Draw(banner);

            renderer.SetPosition(0, y + 1);
        }
    }
}
