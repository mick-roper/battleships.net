using System;
using System.Collections.Generic;
using System.Text;

namespace Battleship
{
    class DoubleBuffer : IBuffer
    {
        readonly int width, height;

        readonly char[,] buffer1, buffer2;

        bool selector = false;

        public DoubleBuffer(int width, int height)
        {
            this.width = width;
            this.height = height;

            buffer1 = new char[width, height];
            buffer2 = new char[width, height];
        }

        public char this[int col, int row] => Buffer[col, row];

        public char[,] Buffer { get { return selector ? buffer1 : buffer2; } }

        public int Width => width;

        public int Height => height;

        public void Flip()
        {
            selector = !selector;
        }

        public bool IsChanged(int col, int row)
        {
            return buffer1[col, row] != buffer2[col, row];
        }
    }
}
