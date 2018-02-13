using System;
using System.Collections.Generic;
using System.Text;

namespace Battleship
{
    interface IRenderer
    {
        void ChangeCursorVisibility(bool visible);
        void SetColour(ConsoleColor colour);
        void ResetColour();
        void SetPosition(int x, int y);
        void Write(string data);
        void Clear();
    }
}
