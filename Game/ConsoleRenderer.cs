using System;
using System.Collections.Generic;
using System.Text;

namespace Battleship
{
    class ConsoleRenderer : IRenderer
    {
        readonly IBuffer buffer;

        int x = 0, y = 0;

        public ConsoleRenderer(IBuffer buffer)
        {
            this.buffer = buffer ?? throw new ArgumentNullException(nameof(buffer));
        }

        public int Width => buffer.Width;

        public int Height => buffer.Height;

        public void ChangeCursorVisibility(bool visible) => Console.CursorVisible = visible;

        public void Commit()
        {
            for (int row = 0; row < Height; row++)
            {
                for (int col = 0; col < Width; col++)
                {
                    if (buffer.IsChanged(col, row))
                    {
                        Console.SetCursorPosition(col, row);

                        Console.Write(buffer[col, row]);
                    }
                }
            }

            buffer.Flip();
        }

        public void Draw(string data)
        {
            for (int i = 0; i < data.Length; i++)
            {
                char c = data[i];

                if (x > Width)
                {
                    x = 0;
                    y += 1;
                }

                if (y > Height)
                {
                    throw new InvalidOperationException("data is too large to fit in the buffer");
                }

                buffer.Buffer[x++, y] = c;
            }
        }

        public void ResetColour() => Console.ResetColor();

        public void SetColour(ConsoleColor colour) => Console.ForegroundColor = colour;

        public void SetPosition(int x, int y)
        {
            this.x = x;
            this.y = y;
        }
    }
}
