using System;
using System.Collections.Generic;
using System.Text;

namespace Battleship
{
    class ConsoleRenderer : IRenderer
    {
        readonly IBuffer buffer;

        public ConsoleRenderer(IBuffer buffer)
        {
            this.buffer = buffer ?? throw new ArgumentNullException(nameof(buffer));
        }

        public int Width => throw new NotImplementedException();

        public int Height => throw new NotImplementedException();

        public void ChangeCursorVisibility(bool visible)
        {
            throw new NotImplementedException();
        }

        public void Commit()
        {
            throw new NotImplementedException();
        }

        public void Draw(string data)
        {
            throw new NotImplementedException();
        }

        public void ResetColour()
        {
            throw new NotImplementedException();
        }

        public void SetColour(ConsoleColor colour)
        {
            throw new NotImplementedException();
        }

        public void SetPosition(int x, int y)
        {
            throw new NotImplementedException();
        }
    }
}
