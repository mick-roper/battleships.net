using Battleships.Entities;
using System;
using System.Collections.Generic;
using System.Reflection;
using System.Text;
using Xunit;

namespace Battleships.Tests.Entities
{
    public class GameBoardTests
    {
        [Fact]
        public void ctor_builds_tile_dictionary()
        {
            const BindingFlags flags = BindingFlags.GetField | BindingFlags.Instance | BindingFlags.NonPublic;

            var board = new GameBoard();

            var tileDict = typeof(GameBoard).GetField("tiles", flags).GetValue(board) as IDictionary<Tuple<char, char>, Tile>;

            Assert.NotNull(tileDict);

            var xVals = new[] { 'A', 'B', 'C', 'D', 'E', 'F', 'G', 'H', 'I', 'J' };
            var yVals = new[] { '0', '1', '2', '3', '4', '5', '6', '7', '8', '9' };

            for (int x = 0; x < xVals.Length; x++)
            {
                for (int y = 0; y < yVals.Length; y++)
                {
                    var tuple = new Tuple<char, char>(xVals[x], yVals[y]);

                    Assert.Equal(Tile.Sea, tileDict[tuple]);
                }
            }
        }
    }
}
