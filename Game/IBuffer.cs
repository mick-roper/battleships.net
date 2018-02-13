namespace Battleship
{
    interface IBuffer
    {
        char[,] Buffer { get; }

        void Flip();
    }
}