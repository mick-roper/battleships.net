using System;
using System.Collections.Generic;
using System.Text;

namespace Battleships.Entities
{
    class GameBoard
    {
        const char X_AXIS_OFFSET = 'A', Y_AXIS_OFFSET = '0';

        readonly IDictionary<Tuple<char, char>, Tile> tiles = new Dictionary<Tuple<char, char>, Tile>(BOUNDARY * BOUNDARY);

        const byte BOUNDARY = 10;

        public GameBoard()
        {
            for (byte y = 0; y < BOUNDARY; y++)
            {
                for (byte x = 0; x < BOUNDARY; x++)
                {
                    var t = new Tuple<char, char>(ToXChar(x), ToYChar(y));
                    tiles[t] = Tile.Sea;
                }
            }
        }

        public void Render(int left, int top, IRenderer renderer)
        {
            var renderState = BoardRenderState.None;

            const byte MAX_X = BOUNDARY * 2 + 1, MAX_Y = BOUNDARY * 2 + 1;

            for (byte y = 0; y < MAX_Y; y++)
            {
                for (byte x = 0; x < MAX_X; x++)
                {
                    renderState = ComputeRenderState(x, y);

                    char charToDraw = ComputeCharToDraw(renderState, ToXChar(x), ToYChar(y));

                    renderer.Draw(charToDraw, left + x, top + y);
                }
            }
        }

        private char ComputeCharToDraw(BoardRenderState renderState, char x, char y)
        {
            switch (renderState)
            {
                case BoardRenderState.None:
                    {
                        return ' ';
                    }
                case BoardRenderState.Axis_X:
                    {
                        return (char)(x + X_AXIS_OFFSET);
                    }
                case BoardRenderState.Axis_Y:
                    {
                        return (char)(y + Y_AXIS_OFFSET);
                    }
                case BoardRenderState.Grid_Corner:
                    {
                        return '+';
                    }
                case BoardRenderState.Grid_Horizontal:
                    {
                        return '-';
                    }
                case BoardRenderState.Grid_Vertical:
                    {
                        return '|';
                    }
                case BoardRenderState.Tile:
                    {
                        var tile = tiles[new Tuple<char, char>(x, y)];
                        return TileMap.GetCharacterFor(tile);
                    }
                default:
                    throw new NotSupportedException($"{nameof(renderState)} {renderState} is not supported");
            }
        }

        private static BoardRenderState ComputeRenderState(byte x, byte y)
        {
            if (x == 0 && y == 0) // check if we're in the top left corner
            {
                return BoardRenderState.None;
            }
            else if (x == 0)
            {
                return BoardRenderState.Axis_X;
            }
            else if (y == 0)
            {
                return BoardRenderState.Axis_Y;
            }
            else if (IsEven(x) && IsEven(y))
            {
                return BoardRenderState.Grid_Corner;
            }
            else if (IsEven(x)) // even check
            {
                return BoardRenderState.Grid_Vertical;
            }
            else if (IsEven(y)) // even check
            {
                return BoardRenderState.Grid_Horizontal;
            }

            // if we get this far, we're rendering a 'tile'
            return BoardRenderState.Tile;
        }

        private static bool IsEven(byte n)
        {
            return n % 2 == 0;
        }

        private static char ToXChar(byte x)
        {
            return (char)(x + X_AXIS_OFFSET);
        }

        private static char ToYChar(byte y)
        {
            return (char)(y + Y_AXIS_OFFSET);
        }

        enum BoardRenderState
        {
            None,
            Axis_X,
            Axis_Y,
            Grid_Vertical,
            Grid_Horizontal,
            Grid_Corner,
            Tile
        }
    }
}
