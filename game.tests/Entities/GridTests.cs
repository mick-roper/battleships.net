using Battleships.Entities;
using Moq;
using System;
using System.Collections.Generic;
using System.Reflection;
using System.Text;
using Xunit;

namespace Battleships.Tests.Entities
{
    public class GridTests
    {
        readonly Mock<IRenderer> mockRenderer = new Mock<IRenderer>();

        readonly char[] xVals = new[] { 'A', 'B', 'C', 'D', 'E', 'F', 'G', 'H', 'I', 'J' };
        readonly char[] yVals = new[] { '0', '1', '2', '3', '4', '5', '6', '7', '8', '9' };

        [Fact]
        public void ctor_builds_tile_dictionary()
        {
            const BindingFlags flags = BindingFlags.GetField | BindingFlags.Instance | BindingFlags.NonPublic;

            var grid = new Grid();

            var tileDict = typeof(Grid).GetField("tiles", flags).GetValue(grid) as IDictionary<Coordinate, Tile>;

            Assert.NotNull(tileDict);

            Coordinate coord = new Coordinate();

            for (byte x = 0; x < xVals.Length; x++)
            {
                for (byte y = 0; y < yVals.Length; y++)
                {
                    coord.X = xVals[x];
                    coord.Y = yVals[y];

                    Assert.Equal(Tile.Water, tileDict[coord]);
                }
            }
        }

        [Fact]
        public void GetTileAt_returns_the_correct_tile()
        {
            const Tile EXPECT = Tile.Water;

            var grid = new Grid();

            var r = new Random(unchecked((int)DateTime.Now.Ticks));

            var x = xVals[r.Next(xVals.Length)];
            var y = yVals[r.Next(yVals.Length)];

            var t = grid.GetTileAt(x, y);

            Assert.Equal(EXPECT, t);
        }
    }
}
