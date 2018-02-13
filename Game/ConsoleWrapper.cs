using System;
using System.Collections.Generic;
using System.Text;

namespace Battleship
{
    class ConsoleWrapper : IRenderer, IInputHandler
    {
        readonly object syncRoot = new object();

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

        public void SetPosition(int x, int y)
        {
            lock (syncRoot)
            {
                Console.SetCursorPosition(x, y);
            }
        }

        public void Write(string data)
        {
            lock (syncRoot)
            {
                Console.Write(data); 
            }
        }
    }
}
