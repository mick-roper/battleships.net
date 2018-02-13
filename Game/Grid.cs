using System.Text;

namespace Battleship
{
    public class Grid
    {
        const byte DIM = 10;
        const byte NUMBER_OFFSET = 48;
        const byte ALPHA_OFFSET = 65;

        readonly Cell[,] cells = new Cell[DIM, DIM];

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

        public Cell this[int row, int column]
        {
            get { return cells[column, row]; }
        }

        public int Height => DIM;
        public int Width => DIM;

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
