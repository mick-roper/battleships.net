using System;
using System.Collections.Generic;
using System.Text;

namespace Game
{
    public class Grid
    {
        const byte NUMBER_OFFSET = 48;
        const byte ALPHA_OFFSET = 65;

        readonly Cell[,] cells = new Cell[10, 10];

        public Grid()
        {
            for (int x = 0; x < cells.GetLength(0); x++) // start at 65
            {
                for (int y = 0; y < cells.GetLength(1); y++)
                {
                    cells[x, y] = new Cell((char)(x + ALPHA_OFFSET), (char)(y + NUMBER_OFFSET));
                }
            }
        }

        public class Cell
        {
            public Cell(char x, char y)
            {
                X = x;
                Y = y;
                Content = '~';
            }

            public char X { get; }
            public char Y { get; }
            public char Content { get; }
        }
    }
}
