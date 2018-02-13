using System;

namespace Battleship
{
    interface IRenderer
    {
        int Width { get; }
        int Height { get; }
        void ChangeCursorVisibility(bool visible);
        void SetColour(ConsoleColor colour);
        void ResetColour();
        void SetPosition(int x, int y);
        void Draw(string data);
        void Clear();
        void Commit();
    }
}
