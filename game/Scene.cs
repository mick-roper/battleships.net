using Battleships.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace Battleships
{
    abstract class Scene
    {
        public Scene(IGame game)
        {
            Game = game;
        }

        protected IGame Game { get; }

        /// <summary>
        /// Writes a centralised banner message
        /// </summary>
        /// <param name="message">The message</param>
        /// <param name="renderer">The renderer</param>
        /// <param name="y">The optional 'y' coord</param>
        protected void WriteCentral(string message, IRenderer renderer, int y = 1)
        {
            int messageLength = message.Length;

            int x = (renderer.Width / 2) + (messageLength / 2);

            for (int i = 0; i < messageLength; i++)
            {
                renderer.Draw(message[i], x + i, y);
            }
        }

        /// <summary>
        /// Handles input
        /// </summary>
        /// <param name="inputService">the input service</param>
        public abstract void HandleInput(IInputService inputService);
        /// <summary>
        /// Updates the scene
        /// </summary>
        public abstract void Update();
        /// <summary>
        /// Renders the scene
        /// </summary>
        /// <param name="renderer">The renderer</param>
        public abstract void Render(IRenderer renderer);
    }
}
