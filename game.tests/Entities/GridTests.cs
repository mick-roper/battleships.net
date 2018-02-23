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

        [Fact]
        public void ctor_builds_tile_dictionary()
        {
            const BindingFlags flags = BindingFlags.GetField | BindingFlags.Instance | BindingFlags.NonPublic;

            var board = new Grid();

            var tileDict = typeof(Grid).GetField("tiles", flags).GetValue(board) as IDictionary<Coordinate, Tile>;

            Assert.NotNull(tileDict);

            var xVals = new[] { 'A', 'B', 'C', 'D', 'E', 'F', 'G', 'H', 'I', 'J' };
            var yVals = new[] { '0', '1', '2', '3', '4', '5', '6', '7', '8', '9' };

            Coordinate coord = new Coordinate();

            for (byte x = 0; x < xVals.Length; x++)
            {
                for (byte y = 0; y < yVals.Length; y++)
                {
                    coord.X = xVals[x];
                    coord.Y = yVals[y];

                    Assert.Equal(Tile.Sea, tileDict[coord]);
                }
            }
        }
    }
}
