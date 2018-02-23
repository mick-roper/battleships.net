using Battleships.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace Battleships.Scenes
{
    abstract class GridScene : Scene
    {
        const byte BOUNDARY = 10;
        const char X_AXIS_OFFSET = 'A';
        const char Y_AXIS_OFFSET = 'Y';

        public GridScene(IGame game) : base(game)
        {
        }

        protected void RenderGrid(Grid grid, int left, int top, IRenderer renderer)
        {
            var renderState = GridRenderState.None;

            const byte MAX_X = BOUNDARY * 2 + 1, MAX_Y = BOUNDARY * 2 + 1;

            for (byte y = 0; y < MAX_Y; y++)
            {
                for (byte x = 0; x < MAX_X; x++)
                {
                    renderState = ComputeRenderState(x, y);

                    char charToDraw = ComputeCharToDraw(renderState, grid, Grid.ToXChar(x), Grid.ToYChar(y));

                    renderer.Draw(charToDraw, left + x, top + y);
                }
            }
        }

        private char ComputeCharToDraw(GridRenderState renderState, Grid grid, char x, char y)
        {
            switch (renderState)
            {
                case GridRenderState.None:
                    {
                        return ' ';
                    }
                case GridRenderState.Axis_X:
                    {
                        return (char)(x + X_AXIS_OFFSET);
                    }
                case GridRenderState.Axis_Y:
                    {
                        return (char)(y + Y_AXIS_OFFSET);
                    }
                case GridRenderState.Grid_Corner:
                    {
                        return '+';
                    }
                case GridRenderState.Grid_Horizontal:
                    {
                        return '-';
                    }
                case GridRenderState.Grid_Vertical:
                    {
                        return '|';
                    }
                case GridRenderState.Tile:
                    {
                        var tile = grid.GetTileAt(x, y);
                        return TileMap.GetCharacterFor(tile);
                    }
                default:
                    throw new NotSupportedException($"{nameof(renderState)} {renderState} is not supported");
            }
        }

        private static GridRenderState ComputeRenderState(byte x, byte y)
        {
            if (x == 0 && y == 0) // check if we're in the top left corner
            {
                return GridRenderState.None;
            }
            else if (x == 0)
            {
                return GridRenderState.Axis_X;
            }
            else if (y == 0)
            {
                return GridRenderState.Axis_Y;
            }
            else if (IsEven(x) && IsEven(y))
            {
                return GridRenderState.Grid_Corner;
            }
            else if (IsEven(x)) // even check
            {
                return GridRenderState.Grid_Vertical;
            }
            else if (IsEven(y)) // even check
            {
                return GridRenderState.Grid_Horizontal;
            }

            // if we get this far, we're rendering a 'tile'
            return GridRenderState.Tile;
        }

        private static bool IsEven(byte n)
        {
            return n % 2 == 0;
        }

        enum GridRenderState
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
