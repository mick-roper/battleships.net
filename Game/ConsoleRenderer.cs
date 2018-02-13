using System;
using System.Collections.Generic;
using System.Text;

namespace Battleship
{
    public class ConsoleRenderer : IRenderer
    {
        readonly object sync = new object();

        readonly StringBuilder renderer;

        char[,] canvas;

        int x = 0, y = 0;

        public ConsoleRenderer(int width, int height)
        {
            Width = width;
            Height = height;

            canvas = new char[Width, Height];
            renderer = new StringBuilder(width * height + width); // need some padding for \n characters
        }

        public int Width { get; }

        public int Height { get; }

        public void ChangeCursorVisibility(bool visible)
        {
            lock (sync)
            {
                Console.CursorVisible = visible;
            }
        }

        public void Clear()
        {
            lock (sync)
            {
                Array.Clear(canvas, 0, canvas.Length);
            }
        }

        public void Commit()
        {
            renderer.Clear();

            for (int x = 0; x < Width; x++)
            {
                for (int y = 0; y < Height; y++)
                {
                    renderer.Append(canvas[x, y]);
                }

                renderer.Append('\n');
            }

            string data = renderer.ToString();

            lock (sync)
            {
                Console.SetCursorPosition(0, 0);
                Console.Write(data);
            }

            Clear();
        }

        public void Draw(string data)
        {
            char c;

            for (int n = 0; n < data.Length; n++)
            {
                c = data[n];

                if (x > Width) // overflow to the next row
                {
                    y += 1;
                }

                if (y > Height)
                {
                    throw new InvalidOperationException("y is out of bounds");
                }

                canvas[x, y] = c;

                x += 1;
            }
        }

        public void ResetColour()
        {
            lock (sync)
            {
                Console.ResetColor();
            }
        }

        public void SetColour(ConsoleColor colour)
        {
            lock (sync)
            {
                Console.ForegroundColor = colour;
            }
        }

        public void SetPosition(int x, int y)
        {
            if (x > Width) throw new ArgumentException("value is out of bounds", nameof(x));
            if (y > Height) throw new ArgumentException("value is out of bounds", nameof(y));

            this.x = x;
            this.y = y;
        }
    }
}
