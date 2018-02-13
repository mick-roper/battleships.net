using System;
using System.Collections.Generic;
using System.Text;

namespace Battleship
{
    class ConsoleWrapper : IRenderer, IInputHandler
    {
        readonly object syncRoot = new object();

        int minX = 0, minY = 0;

        public int Width => Console.WindowWidth;

        public int Height => Console.WindowHeight;

        public void ChangeCursorVisibility(bool visible)
        {
            lock (syncRoot)
            {
                Console.CursorVisible = visible;
            }
        }

        public void Clear()
        {
            lock (syncRoot)
            {
                Console.Clear();
            }
        }

        public string ReadInput()
        {
            return Console.ReadLine();
        }

        public void ResetColour()
        {
            lock (syncRoot)
            {
                Console.ResetColor();
            }
        }

        public void SetColour(ConsoleColor colour)
        {
            lock (syncRoot)
            {
                Console.ForegroundColor = colour;
            }
        }

        public void SetMinBounds(int x, int y)
        {
            lock (syncRoot)
            {
                minX = x;
                minY = y; 
            }
        }

        public void SetPosition(int x, int y)
        {
            lock (syncRoot)
            {
                x += minX;
                y += minY;

                Console.SetCursorPosition(x, y);
            }
        }

        public void Draw(string data)
        {
            lock (syncRoot)
            {
                Console.Write(data); 
            }
        }

        public void Draw(char character)
        {
            lock (syncRoot)
            {
                Console.Write(character);
            }
        }
    }
}
