using Battleships.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace Battleships.Scenes
{
    abstract class GridScene : Scene
    {
        const byte BOUNDARY = 10;

        public GridScene(IGame game) : base(game)
        {
        }

        protected void RenderGrid(Grid grid, int left, int top, IRenderer renderer)
        {
            var renderState = GridRenderState.Blank;

            const byte MAX_X = BOUNDARY * 2 + 1, MAX_Y = BOUNDARY * 2 + 1;

            for (byte y = 0; y < MAX_Y; y++)
            {
                for (byte x = 0; x < MAX_X; x++)
                {
                    renderState = ComputeRenderState(x, y);

                    char charToDraw = ComputeCharToDraw(renderState, grid, Grid.ToXChar((byte)(x - 1)), Grid.ToYChar((byte)(y - 1))); //need -1 since we're offsetting by one character

                    renderer.Draw(charToDraw, left + x, top + y);
                }
            }
        }

        private static GridRenderState ComputeRenderState(byte x, byte y)
        {
            if (x == 0 && y == 0) // check if we're in the top left corner
            {
                return GridRenderState.Blank;
            }
            else if (x == 0)
            {
                return IsEven(y) ? GridRenderState.Blank : GridRenderState.Axis_Y;
            }
            else if (y == 0)
            {
                return IsEven(x) ? GridRenderState.Blank : GridRenderState.Axis_X;
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

        private char ComputeCharToDraw(GridRenderState renderState, Grid grid, char x, char y)
        {
            switch (renderState)
            {
                case GridRenderState.Blank:
                    {
                        return ' ';
                    }
                case GridRenderState.Axis_X:
                    {
                        return x;
                    }
                case GridRenderState.Axis_Y:
                    {
                        return y;
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

        private static bool IsEven(byte n)
        {
            return n % 2 == 0;
        }

        enum GridRenderState
        {
            Blank,
            Axis_X,
            Axis_Y,
            Grid_Vertical,
            Grid_Horizontal,
            Grid_Corner,
            Tile
        }
    }
}
