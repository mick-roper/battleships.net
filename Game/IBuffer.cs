namespace Battleship
{
    interface IBuffer
    {
        char this[int col, int row] { get; }

        char[,] Buffer { get; }

        int Width { get; }

        int Height { get; }

        void Flip();
        bool IsChanged(int col, int row);
    }
}