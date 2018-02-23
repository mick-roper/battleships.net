using System;
using System.Collections.Generic;
using System.Text;

namespace Battleships
{
    class ConsoleRenderer : IRenderer
    {
        readonly object syncroot = new object();

        public int Width => Console.BufferWidth;

        public int Height => Console.BufferHeight;

        public void Clear()
        {
            lock (syncroot)
            {
                Console.Clear(); 
            }
        }

        public void Draw(char character, int x, int y)
        {
            lock(syncroot)
            {
                Console.SetCursorPosition(x, y);
                Console.Write(character);
            }
        }

        public void ShowCursor(bool visible)
        {
            lock (syncroot)
            {
                Console.CursorVisible = visible;
            }
        }
    }
}
