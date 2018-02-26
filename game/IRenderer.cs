using System;
using System.Collections.Generic;
using System.Text;

namespace Battleships
{
    interface IRenderer
    {
        /// <summary>
        /// Gets the width of the rendering surface
        /// </summary>
        int Width { get; }
        /// <summary>
        /// Gets the height of the rendering surface
        /// </summary>
        int Height { get; }
        /// <summary>
        /// Draws a character to the screen
        /// </summary>
        /// <param name="character">The character to draw</param>
        /// <param name="x">The x coord</param>
        /// <param name="y">The y coord</param>
        void Draw(char character, int x, int y);
        /// <summary>
        /// Sets the cursor visibility
        /// </summary>
        /// <param name="visible"><c>true</c> to show the cursor, else <c>false</c></param>
        void ShowCursor(bool visible);
        /// <summary>
        /// Clears the current display
        /// </summary>
        void Clear();
        /// <summary>
        /// Sets the current position
        /// </summary>
        /// <param name="x"></param>
        /// <param name="y"></param>
        void SetPosition(int x, int y);
    }
}
