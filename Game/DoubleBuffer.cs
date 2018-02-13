using System;
using System.Collections.Generic;
using System.Text;

namespace Battleship
{
    class DoubleBuffer : IBuffer
    {
        readonly char[,] buffer1, buffer2;

        bool selector = false;

        public DoubleBuffer(int width, int height)
        {
            buffer1 = new char[width, height];
            buffer2 = new char[width, height];
        }

        public char[,] Buffer { get { return selector ? buffer1 : buffer2; } }

        public void Flip()
        {
            selector = !selector;
        }
    }
}
